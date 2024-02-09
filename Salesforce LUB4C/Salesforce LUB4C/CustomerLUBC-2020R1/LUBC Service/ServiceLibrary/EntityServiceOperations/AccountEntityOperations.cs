//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Profisee SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdm.AccountService.ServiceLibrary
{
	using Mdm.AccountService.Contracts;
	using Mdm.AccountService.Contracts.MemberDataContracts;
	using Mdm.AccountService.ServiceLibrary.MemberAdapters;
    using Profisee.MasterDataMaestro.Services.DataContracts;
    using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
    using Profisee.Services.Sdk.AcceleratorFramework;
    using Profisee.Services.Sdk.Common.Contracts.DataContext;
    using System;
	using System.Collections.Generic;
    using System.Collections.ObjectModel;

	public partial class Account : BaseModelService, IAccount
	{
		private const String AccountEntityName = "AccountLead";

		private static Identifier AccountEntityId = new Identifier { Name = AccountEntityName, Id = new Guid("fdb3706e-c4c2-4dea-b7d3-e7045f03d531") };

		private MdmEntity<AccountMember,AccountMemberAdapter> AccountEntity = null;

		private Collection<Identifier> AccountAttributes = new Collection<Identifier> 
		{
			new Identifier { Name = "Name", Id = new Guid("a3bc7c43-cdb3-4d7f-a3db-48658100e8ec") },
			new Identifier { Name = "Code", Id = new Guid("881962d3-fc3e-4445-9781-50889166ff6e") },
			new Identifier { Name = "MatchEmail", Id = new Guid("8b32361a-554b-4ef4-8a01-9890c6bbadfc") },
			new Identifier { Name = "MatchPhone", Id = new Guid("e836a112-3e6c-410e-a425-e2e0fa1be5ef") },
			new Identifier { Name = "MatchScore", Id = new Guid("74bd0654-4a4c-478f-ad1e-b3bba5f6d044") },
			new Identifier { Name = "StdAddressLine1", Id = new Guid("06b74a49-ff62-4abc-b12b-a486293b4ec4") },
			new Identifier { Name = "StdCity", Id = new Guid("529eed9d-eb49-4800-8464-d180fe905858") },
			new Identifier { Name = "StdPostalCode", Id = new Guid("37a83877-661d-40dd-a01d-09383ee2017c") },
			new Identifier { Name = "StdStateProvince", Id = new Guid("458dc7e1-6169-4e40-8303-683756b390e1") },
			new Identifier { Name = "SourceCode", Id = new Guid("42d1852e-6f8c-4d71-bc69-a7b1b125bcda") },
		};

		private object _AccountLocker = new object();

		private void AccountEntityInitialize()
		{
			lock (_AccountLocker)
			{
				if ((this.AccountEntity == null))
				{
					this.AccountEntity = base.Model.GetEntity<AccountMember, AccountMemberAdapter>(Account.AccountEntityId);
				}
			}
		}

		public AccountMember GetAccountMember(String memberCode)
		{
			this.AccountEntityInitialize();
			return this.AccountEntity.GetMember<AccountMember>(versionName, memberCode, AccountAttributes);
		}
		
        public Collection<AccountMember> GetAccountMembers(BrowseEntityContext browseContext)
        {
            this.AccountEntityInitialize();
            return this.AccountEntity.GetMembers<AccountMember>(versionName, browseContext, AccountAttributes);
        }
        
        public Collection<AccountMember> GetAccountMembersUsingIds(Collection<MemberIdentifier> memberIds)
        {
            this.AccountEntityInitialize();
            return this.AccountEntity.GetMembers<AccountMember>(versionName, memberIds, AccountAttributes);
        }
        
        	}
}
