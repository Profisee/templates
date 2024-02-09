using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Profisee.LUB4CService.DataContracts;
using Profisee.MasterDataMaestro.Services.DataContracts;
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using Profisee.MasterDataMaestro.Services.MessageContracts;
using Profisee.Services.Sdk.AcceleratorFramework;
using Profisee.Services.Sdk.Common.Contracts.DataContext;
using MdmAttribute = Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices.Attribute;

namespace Profisee.LUB4CService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class LookupBeforeCreate : ILookupBeforeCreate
	{
		public LUB4CResponse PerformLookup(LUB4CRequest request)
		{
			var response = new LUB4CResponse
			{
				Errors = new List<MaestroError>(),
				Messages = new List<string>(),
				MatchedMembers = new List<DataContracts.MatchMember>()
			};

			try
			{
				// connect to Maestro and get the necessary data structures
				var maestroUri = ConfigurationManager.AppSettings.Get("MaestroUri");
				var source = new MdmSource();
				source.Connect(maestroUri);
				var model = source.GetModel(request.DataContext.Model);
				var entity = model.GetEntity(request.DataContext.Entity);
				var matchingStrategy = model.GetMatchingStrategy(request.DataContext.MatchingStrategy);

				// validate the matching strategy
				if (matchingStrategy.EntityId.Name != request.DataContext.Entity)
					response.Errors.Add(new MaestroError { Code = "LUB4C.InvalidEntity", Description = $"Matching Strategy Entity ({matchingStrategy.EntityId.Name}) does not match Request Entity ({request.DataContext.Entity})", ErrorType = ErrorType.Error });
				if (matchingStrategy.VersionId.Name != request.DataContext.Version)
					response.Errors.Add(new MaestroError { Code = "LUB4C.InvalidVersion", Description = $"Matching Strategy Version ({matchingStrategy.VersionId.Name}) does not match Request Version ({request.DataContext.Version})", ErrorType = ErrorType.Error });
				if (response.Errors.Count > 0)
					return response;

				// make sure all attributes in the matching strategy have values
				var missingAttributes = FindMissingMatchAttributes(request.MatchAttributes, matchingStrategy);
				if (missingAttributes.Count > 0)
					response.Messages.Add($"The following Attributes were not received: {string.Join(", ", missingAttributes)}");
				foreach (var missingAttr in missingAttributes)
					request.MatchAttributes.Add(new MatchAttribute {Name = missingAttr, Value = string.Empty});

				// create the member based on the data received in the request
				var member = new Member {MemberId = new MemberIdentifier(), Attributes = new Collection<MdmAttribute>()};
				foreach (var matchAttribute in request.MatchAttributes)
					member.Attributes.Add(new MdmAttribute {Identifier = new Identifier {Name = matchAttribute.Name}, Value = matchAttribute.Value});

				// perform the fuzzy matching and get the results
				var matchRequest = new GetMemberMatchesRequest
				{
					StrategyId = matchingStrategy.Identifier,
					IncludeMatchesInMemberGroups = false,
					Members = new List<Member> { member },
				};
				var matchResults = model.GetMemberMatches(matchRequest);

				// add errors from the matching operation to the error collection
				foreach (var operationError in matchResults.OperationResult.Errors)
					response.Errors.Add(operationError);

				// add any matched results to the process
				if (matchResults.Members.Count > 0)
				{
					response.Messages.Add($"There were {matchResults.Members[0].MatchedMembers.Count} matched members found.");
					var memberCodes = matchResults.Members[0].MatchedMembers.Take(20).Select(m => m.Code).ToList();
					string filter = $"[Code] in ('{string.Join("', '", memberCodes)}')";
					response.Messages.Add($"Filter: [{filter}]");
					var bec = new BrowseEntityContext
					{
						PageNumber = 1,
						PageSize = 1000,
						Filter = filter,
					};
					//var matchedMembers = entity.GetMembers(request.DataContext.Version, bec, request.ReturnAttributes, false);
					var matchedMembers = entity.GetMemberCollection(request.DataContext.Version, bec, request.ReturnAttributes, false);
					response.Messages.Add($"matchedMembers.Count: {matchedMembers.Count}");

					foreach (var mem in matchedMembers)
					{
						var resultMember = matchResults.Members[0].MatchedMembers.FirstOrDefault(mm => mm.Code.Equals(mem.MemberId.Code, StringComparison.InvariantCultureIgnoreCase));

						var responseMember = new MatchMember { MatchScore = resultMember.Score, Attributes = new Collection<DataContracts.MemberAttribute>() };
						foreach (var attrName in request.ReturnAttributes)
						{
							var attr = mem.Attributes.FirstOrDefault(a => a.Name.Equals(attrName));
							if (attr == null)
								responseMember.Attributes.Add(new MemberAttribute {Name = attrName, Value = null});
							else
								responseMember.Attributes.Add(new MemberAttribute {Name = attrName, Value = attr.Value});
						}
						response.MatchedMembers.Add(responseMember);
					}
				}
			}
			catch (Exception ex)
			{
				response.Errors.Add(new MaestroError { Code = "LUB4C.Error", Description = ex.ToString(), ErrorType = ErrorType.Error });
			}

			return response;
		}

		private List<string> FindMissingMatchAttributes(Collection<MatchAttribute> matchAttributes, MatchingStrategy strategy)
		{
			var missingAttributes = new List<string>();

			foreach (var attributeSet in strategy.ColumnSets)
			{
				foreach (var attr in attributeSet.Columns)
				{
					var matchAttribute = matchAttributes.FirstOrDefault(m => m.Name.Equals(attr.AttributeId.Name));
					if (matchAttribute == null)
						missingAttributes.Add(attr.AttributeId.Name);
				}
			}

			return missingAttributes;
		}
	}
}
