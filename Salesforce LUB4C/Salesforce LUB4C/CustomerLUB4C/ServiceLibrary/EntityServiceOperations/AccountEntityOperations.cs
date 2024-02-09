//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Maestro SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdm.Profisee_Customer360Service.ServiceLibrary
{
	using Mdm.Profisee_Customer360Service.Contracts;
	using Mdm.Profisee_Customer360Service.Contracts.MemberDataContracts;
	using Mdm.Profisee_Customer360Service.ServiceLibrary.MemberAdapters;
    using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
    using Profisee.Services.Sdk.AcceleratorFramework;
    using Profisee.Services.Sdk.Common.Contracts.DataContext;
    using System;
	using System.Collections.Generic;
    using System.Collections.ObjectModel;
	using System.Configuration;

	public partial class LookupBeforeCreate : BaseModelService, ILookupBeforeCreate
	{

		private const String AccountEntityName = "Account";

		private static Identifier AccountEntityId = new Identifier { Name = ConfigurationManager.AppSettings.Get("EntityName"), Id = new Guid("d294af6a-8112-417a-b474-47611da2ac23") };

		private MdmEntity<AccountMember,AccountMemberAdapter> AccountEntity = null;

		private Collection<Identifier> AccountAttributes = new Collection<Identifier> 
		{
			new Identifier { Name = "Name", Id = new Guid("93aac09b-2636-4cf3-8d4d-3374b53a20f2") },
			new Identifier { Name = "Code", Id = new Guid("9de876b6-04e6-4e2b-914a-df6af63351b5") },
			new Identifier { Name = "Account ID", Id = new Guid("8faa8c21-52e8-412a-867f-a2aece06e751") },
			new Identifier { Name = "BillingCity", Id = new Guid("814302fb-7c6e-474c-acd9-03d59a3f81d0") },
			new Identifier { Name = "BillingCountry", Id = new Guid("baed3794-6ada-4df5-9da8-57f7a65c6faa") },
			new Identifier { Name = "BillingStateProvince", Id = new Guid("48cac26b-c9d1-4213-9142-fe1294cb2e07") },
			new Identifier { Name = "BillingStreet", Id = new Guid("b04e810c-4176-4636-85ba-0d6ac2fff519") },
			new Identifier { Name = "BillingZipPostalCode", Id = new Guid("09a0bd13-6223-451a-8419-7342bf77c784") },
			new Identifier { Name = "Match Score", Id = new Guid("320d1157-4594-4e6c-af46-c8d2ff139152") },
			new Identifier { Name = "Phone", Id = new Guid("3f5d8b8f-6546-4e4f-9c0b-d27544c6f333") },
			new Identifier { Name = "Website", Id = new Guid("ec07f15d-a95b-41e9-a2bb-2a149ec5a117") },
		};

		private object _AccountLocker = new object();

		private void AccountEntityInitialize()
		{
			lock (_AccountLocker)
			{
				if ((this.AccountEntity == null))
				{
					this.AccountEntity = base.Model.GetEntity<AccountMember, AccountMemberAdapter>(LookupBeforeCreate.AccountEntityId);
				}
			}
		}

		public AccountMember GetAccountMember(String versionName, String memberCode)
		{
			this.AccountEntityInitialize();
			return this.AccountEntity.GetMember<AccountMember>(versionName, memberCode, AccountAttributes);
		}
		
        public Collection<AccountMember> GetAccountMembers(String versionName, BrowseEntityContext browseContext)
        {
            this.AccountEntityInitialize();
            return this.AccountEntity.GetMembers<AccountMember>(versionName, browseContext, AccountAttributes);
        }
        
        public Collection<AccountMember> GetAccountMembersUsingIds(String versionName, Collection<MemberIdentifier> memberIds)
        {
            this.AccountEntityInitialize();
            return this.AccountEntity.GetMembers<AccountMember>(versionName, memberIds, AccountAttributes);
        }
        
        public Collection<Error> AddAccountMember(String versionName, AccountMember member)
        {
            this.AccountEntityInitialize();
            return this.AccountEntity.AddMember<AccountMember>(versionName, member);
        }
        
        public Collection<Error> AddAccountMemberWithIdReturn(String versionName, AccountMember member, out MemberIdentifier memberId)
        {
            this.AccountEntityInitialize();
            return this.AccountEntity.AddMember<AccountMember>(versionName, member, out memberId);
        }
        
        public Collection<Error> AddAccountMembers(String versionName, Collection<AccountMember> members)
        {
            this.AccountEntityInitialize();
            return this.AccountEntity.AddMembers<AccountMember>(versionName, members);
        }

		   
        public Collection<Error> AddAccountMembersWithIdReturn(String versionName, Collection<AccountMember> member, out Collection<MemberIdentifier> memberIds)
        {
            this.AccountEntityInitialize();
            return this.AccountEntity.AddMembers<AccountMember>(versionName, member, out memberIds);
        }

			}
}
