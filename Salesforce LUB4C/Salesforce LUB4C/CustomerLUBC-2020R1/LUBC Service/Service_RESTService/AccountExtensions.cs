//------------------------------------------------------------------------------
// COMMENT OUT THE CODE IN THE ACCOUNT.SVC CLASS and IACCOUNT.SVC CLASS
//------------------------------------------------------------------------------

namespace Mdm.AccountService.ServiceREST
{
    using System.Linq;
    using Mdm.AccountService.Contracts;
    using Profisee.Services.Sdk.AcceleratorFramework;
    using System;
    using Profisee.MasterDataMaestro.Services.DataContracts;
    using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
    using MdmAttribute = Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices.Attribute;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Profisee.Services.Sdk.Common;
    using System.Configuration;
    using System.Text;
    using System.Security.Principal;
    using Profisee.MasterDataMaestro.Services.MessageContracts;
    using Profisee.Services.Sdk.Common.Contracts.DataContext;

    /// <remarks>
    /// This class provides the implementation of service contract associated with the MDS model.  Note that this
    /// class is defined as 'partial'. Custom operations should be defined in the <see cref="IAccount"/>
    /// class file located in this same directory.
    ///  
    /// This file is generated initially but it is generated only once. The Service Builder will not overwrite this
    /// file if it exists because it is intended to house any custom operations that you may need to add to
    /// the service contract. If you remove or rename this class before running the Service Builder it will generate
    /// an updated class definition. You may then reapply any custom service operations from your prior version.
    /// </remarks>
    public partial class Account : IAccount
	{
        private readonly string maestroUri = ConfigurationManager.AppSettings.Get("ProfiseeURI");
        private readonly string clientId = ConfigurationManager.AppSettings.Get("ServiceAccountClientId"); 
        private readonly string returnAttributes = ConfigurationManager.AppSettings.Get("Lookup.Return.Attributes");
        private readonly string loggingLevel = ConfigurationManager.AppSettings.Get("EventLogging");

        public String HelloWorld(String name)
		{

            LogMessage($"Hello World for LUBC Service Used", "Verbose");

            return String.Format("Hello, {0}. you\'ve reached the Account RESTful service.", name);
		}

		public LookUpBeforeCreateResponse LookUpBeforeCreate(LookUpBeforeCreateRequest request)
        {

            var response = new LookUpBeforeCreateResponse
            {
                MatchedMembers = new List<MatchMember>()
            };

            try
            {
                var source = new MdmSource();
                source.Connect(maestroUri, clientId);

                var model = source.GetModel();
                LogMessage($"Matching Strategy:{request.StrategyName}", "Information");
                var matchingStrategy = model.GetMatchingStrategy(request.StrategyName);
                if (matchingStrategy == null)
                {
                    LogMessage($"No Match Strategy found with name: {request.StrategyName}", null, EventLogEntryType.Error);
                    return null;
                }
                var entity = model.GetEntity(matchingStrategy.EntityId);

                // make sure all attributes in the matching strategy have values
                var missingAttributes = FindMissingMatchAttributes(request.MatchAttributes, matchingStrategy);
                if (missingAttributes.Count > 0)
                {
                    LogMessage($"Missing Attributes in JSON request(case sensitive): {string.Join(", ", missingAttributes)}", null, EventLogEntryType.Error);
                    return null;
                }

                // create the member for LUBC based on the data received in the request
                var member = new Member { MemberId = new MemberIdentifier(), Attributes = new Collection<MdmAttribute>() };
                member.MemberId.Code = Guid.NewGuid().ToString();
                foreach (var matchAttribute in request.MatchAttributes)
                    member.Attributes.Add(new MdmAttribute { Identifier = new Identifier { Name = matchAttribute.Name }, Value = matchAttribute.Value });

                // perform the Lookup Before Create
                var matchRequest = new GetMemberMatchesRequest
                {
                    StrategyId = matchingStrategy.Identifier,
                    IncludeMatchesInMemberGroups = false,
                    Members = new List<Member> { member },
                    IsLookupBeforeCreate = true,
                };

                var matchResults = model.GetMemberMatches(matchRequest);

                // errors from the matching operation
                LogMessage($"Match Results\nMember Count: {matchResults.Members.Count}\nErrors: {matchResults.OperationResult.Errors.Count}", "Information");
                if (matchResults.OperationResult.Errors.Count > 0)
                {
                    var errMsg = new StringBuilder();
                    foreach (var err in matchResults.OperationResult.Errors)
                        errMsg.AppendLine($"Error {err.Code}: {err.Description}");
                    LogMessage($"matchResults errors:\n{errMsg}", null, EventLogEntryType.Error);
                }

                // populate match results
                if (matchResults.Members.Count > 0)
                {
                    var memberCodes = matchResults.Members[0].MatchedMembers.Take(20).Select(m => m.Code).ToList();
                    string filter = $"[Code] in ('{string.Join("', '", memberCodes)}')";
                    var bec = new BrowseEntityContext
                    {
                        PageNumber = 1,
                        PageSize = 1000,
                        Filter = filter,
                    };

                    LogMessage($"Match Results Member filter: {filter}", "Verbose");

                    // determine which attributes to return
                    var returnAttributeList = new Collection<string>();
                    returnAttributeList.AddRange(returnAttributes.Split(',').ToList());

                    var matchedMembers = entity.GetMdmMembers(bec, returnAttributeList);

                    foreach (var mem in matchedMembers)
                    {
                        var resultMember = matchResults.Members[0].MatchedMembers.FirstOrDefault(mm => mm.Code.Equals(mem.MemberId.Code, StringComparison.InvariantCultureIgnoreCase));
                        if (resultMember == null)
                            continue;
                        LogMessage($"Found member with Code: {mem.MemberId.Code}\nAttribute List Count: {returnAttributeList.Count}", "Information");

                        var responseMember = new MatchMember { Attributes = new Collection<MemberAttribute>() };
                        foreach (var attrName in returnAttributeList)
                        {
                            LogMessage($"Response attribute: {attrName}", "Verbose");
                            var attr = entity.LeafAttributes.FirstOrDefault(a => a.Name.Equals(attrName));
                            if (attr != null)
                            {
                                //Matching Result Attributes
                                if (attrName == "MatchScore")
                                    responseMember.Attributes.Add(new MemberAttribute { Name = attrName, Value = resultMember.Score });
                                else
                                { 
                                    var attrValue = attrName == "Name" ? mem.Name : mem.GetMemberValue(attrName);
                                    if (attrValue == null) { 
                                        responseMember.Attributes.Add(new MemberAttribute { Name = attrName, Value = null });
                                    }
                                    else
                                        responseMember.Attributes.Add(new MemberAttribute { Name = attrName, Value = attrValue });
                                }
                            }
                            else
                            {
                                LogMessage($"Return attribute {attrName} was not found in the entity {entity.Name}", null, EventLogEntryType.Error);
                                return null;
                            }
                        }
                        response.MatchedMembers.Add(responseMember);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, System.Diagnostics.EventLogEntryType.Error);
            }

            return response;
		}

        private List<string> FindMissingMatchAttributes(Collection<MatchAttribute> matchAttributes, MatchingStrategy strategy)
        {
            LogMessage($"Request Attribute Count: {matchAttributes.Count}", "Verbose");
            var missingAttributes = new List<string>();

            foreach (var attributeSet in strategy.ColumnSets)
            {

                LogMessage($"Matching Strategy AttributeSet: {attributeSet.Name}", "Verbose");

                foreach (var attr in attributeSet.Columns)
                {
                    var matchAttribute = matchAttributes.FirstOrDefault(m => m.Name.Equals(attr.AttributeId.Name));
                    if (matchAttribute == null)
                        missingAttributes.Add(attr.AttributeId.Name);
                }
            }

            return missingAttributes;
        }

        private void LogMessage(string msg, string eventLogLevel, EventLogEntryType entryType = EventLogEntryType.Information)
        {
            if ((loggingLevel != "Off" && 
                (eventLogLevel == loggingLevel || eventLogLevel == "Information"))
                || entryType == EventLogEntryType.Error)
                Logging.LogMessage($"MDMApi/SalesforceLUBC Service Information\n\n{msg}", entryType);
        }
    }
}

