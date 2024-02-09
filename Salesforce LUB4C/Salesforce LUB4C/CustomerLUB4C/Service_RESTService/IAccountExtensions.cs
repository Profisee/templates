using System;
using Mdm.Profisee_Customer360Service.Contracts.MemberDataContracts; 
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Mdm.Profisee_Customer360Service.Contracts;
using Mdm.Profisee_Customer360Service.ServiceLibrary;

namespace Mdm.Profisee_Customer360Service.ServiceREST
{
    
    /// <remarks>
    /// This interface contains custom operations defined for the <see cref="LookupBeforeCreate"/>.
	/// The implementation of this interface should be created in the AccountExtensions file
    /// in the same directory as this file.
    /// </remarks>
    [ServiceContract()]
    public interface IAccountExtensions
    {
        // TODO: Add any custom service operation you need here. Here's a sample!
        [WebInvoke(Method = "GET", UriTemplate = "/HelloWorld/{name}")]
        [OperationContract]
        String HelloWorld(string name);

	    [WebInvoke(Method = "POST", UriTemplate = "/LookupBeforeCreate")]
	    [OperationContract]
	    Contracts.LookupResponse LookupBeforeCreate(LookupRequest request);
    }
}

