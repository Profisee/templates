using System;

using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Mdm.Profisee_Customer360Service.Contracts;

using Profisee.MasterDataMaestro.Services.DataContracts;

namespace Mdm.Profisee_Customer360Service.ServiceREST
{
    
    /// <remarks>
    /// This interface contains custom operations defined for the <see cref="Service"/>.
	/// The implementation of this interface should be created in the CustomerExtensions file
    /// in the same directory as this file.
    /// </remarks>
    [ServiceContract()]
    public interface ICustomerExtensions
    {
        // TODO: Add any custom service operation you need here. Here's a sample!
        [SwaggerWcf.Attributes.SwaggerWcfPath("HelloWorld", "Hello world endpoint.")]
        [WebInvoke(Method = "GET", UriTemplate = "/HelloWorld/{name}")]
        [OperationContract]
        String HelloWorld(string name);

     
        [WebInvoke(Method = "POST", UriTemplate = "/Lookup")]
        [OperationContract]
        LookupResponse Lookup(LookUpRequest request);


        [WebInvoke(Method = "POST", UriTemplate = "/LookupBeforeCreate")]
        [OperationContract]
        Contracts.LookupResponse LookupBeforeCreate(LookupRequest request);
    }

    [System.Runtime.Serialization.DataContract()]
    public class LookUpRequest
    {
        public string Entity { get; set; }
      
        public string MatchingStrategy { get; set; }
      
        public string Version { get; set; }
      
        public Collection<MatchAttribute> MatchAttributes { get; set; }
      
        public Collection<string> ReturnAttributes { get; set; }
    }

    [System.Runtime.Serialization.DataContract()]
    public class MatchAttribute
    {
        public string Name { get; set; }
   
        public string Value { get; set; }
    }


    [System.Runtime.Serialization.DataContract()]
    public class LookupResponse
    {
        public List<string> Messages { get; set; }

        public List<Error> Errors { get; set; }

        public List<MatchMember> MatchedMembers { get; set; }

    }

    [System.Runtime.Serialization.DataContract()]
    public class MatchMember
    {
        public double MatchScore { get; set; }
        
        public Collection<MemberAttribute> Attributes { get; set; }
    }

    [System.Runtime.Serialization.DataContract()]
    public class MemberAttribute
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }

}

