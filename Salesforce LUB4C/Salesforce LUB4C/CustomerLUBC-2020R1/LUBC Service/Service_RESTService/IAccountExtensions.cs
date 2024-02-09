using System;
using Mdm.AccountService.Contracts.MemberDataContracts; 
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Mdm.AccountService.Contracts;
using Profisee.MasterDataMaestro.Services.DataContracts;

namespace Mdm.AccountService.ServiceREST
{
	
	/// <remarks>
	/// This interface contains custom operations defined for the <see cref="Service"/>.
	/// The implementation of this interface should be created in the AccountExtensions file
	/// in the same directory as this file.
	/// </remarks>
	[ServiceContract()]
	public interface IAccountExtensions
	{
        // TODO: Add any custom service operation you need here. Here's a sample!
        [WebInvoke(Method = "POST", UriTemplate = "/HelloWorld/{name}")]
        [OperationContract]
        String HelloWorld(string name);

        [WebInvoke(Method = "POST", UriTemplate = "/LookUpBeforeCreate")]
        //[CorsEnabled]
        [OperationContract]
        LookUpBeforeCreateResponse LookUpBeforeCreate(LookUpBeforeCreateRequest request);
    }
}

