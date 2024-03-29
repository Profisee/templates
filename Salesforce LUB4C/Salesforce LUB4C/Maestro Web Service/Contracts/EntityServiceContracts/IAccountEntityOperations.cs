//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Maestro SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdm.Profisee_Customer360Service.Contracts.EntityServiceContracts
{
    using Mdm.Profisee_Customer360Service.Contracts.MemberDataContracts;
    using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
	using Profisee.Services.Sdk.Common.Contracts.DataContext;
    using System;
	using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ServiceModel;
    
    [System.ServiceModel.ServiceContract(SessionMode=SessionMode.Allowed)]
    public interface IAccountEntityOperations
    {

	    [System.ServiceModel.OperationContract()]
        AccountMember GetAccountMember(String versionName, String memberCode);
        
		[System.ServiceModel.OperationContract()]
        Collection<AccountMember> GetAccountMembers(String versionName, BrowseEntityContext browseContext);
        
        [System.ServiceModel.OperationContract()]
        Collection<AccountMember> GetAccountMembersUsingIds(String versionName, Collection<MemberIdentifier> memberIds);
        
        [System.ServiceModel.OperationContract()]
        Collection<Error> AddAccountMember(String versionName, AccountMember member);
        
        [System.ServiceModel.OperationContract()]
        Collection<Error> AddAccountMemberWithIdReturn(String versionName, AccountMember member, out MemberIdentifier memberId);
        
        [System.ServiceModel.OperationContract()]
        Collection<Error> AddAccountMembers(String versionName, Collection<AccountMember> members);
        
		[System.ServiceModel.OperationContract()]
        Collection<Error> AddAccountMembersWithIdReturn(String versionName, Collection<AccountMember> member, out Collection<MemberIdentifier> memberIds);

        	}
}
