//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Profisee SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdm.AccountService.Contracts.MemberDataContracts
{
    using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
    using Profisee.Services.Sdk.Common.Contracts.DataObjects;
    using System;
	using System.Collections.Generic;
    using System.Runtime.Serialization;

	// Only for Restful services that return a list of members...
    [CollectionDataContract]
    public class AccountMemberList : List<AccountMember>
    {
        public AccountMemberList() { }
        public AccountMemberList(List<AccountMember> members) : base(members) { }
    }

	[System.Runtime.Serialization.DataContract()]
	public class AccountMember : BaseMemberType
	{
				
		private string _MatchEmail;
				
		private string _MatchPhone;
				
		private Nullable<double> _MatchScore;
				
		private string _StdAddressLine1;
				
		private string _StdCity;
				
		private string _StdPostalCode;
				
		private string _StdStateProvince;
				
		private string _SourceCode;
		
		private AccountMember.NullificationMask _Nullify;

		public AccountMember()
		{
			_Nullify = new AccountMember.NullificationMask();
		}
				

		[System.Runtime.Serialization.DataMember()]
		public string MatchEmail
		{
			get 
			{
				return this._MatchEmail;
			}
			set
			{
				this._MatchEmail = value;
			}
		}


				

		[System.Runtime.Serialization.DataMember()]
		public string MatchPhone
		{
			get 
			{
				return this._MatchPhone;
			}
			set
			{
				this._MatchPhone = value;
			}
		}


				

		[System.Runtime.Serialization.DataMember()]
		public Nullable<double> MatchScore
		{
			get 
			{
				return this._MatchScore;
			}
			set
			{
				this._MatchScore = value;
			}
		}


				

		[System.Runtime.Serialization.DataMember()]
		public string StdAddressLine1
		{
			get 
			{
				return this._StdAddressLine1;
			}
			set
			{
				this._StdAddressLine1 = value;
			}
		}


				

		[System.Runtime.Serialization.DataMember()]
		public string StdCity
		{
			get 
			{
				return this._StdCity;
			}
			set
			{
				this._StdCity = value;
			}
		}


				

		[System.Runtime.Serialization.DataMember()]
		public string StdPostalCode
		{
			get 
			{
				return this._StdPostalCode;
			}
			set
			{
				this._StdPostalCode = value;
			}
		}


				

		[System.Runtime.Serialization.DataMember()]
		public string StdStateProvince
		{
			get 
			{
				return this._StdStateProvince;
			}
			set
			{
				this._StdStateProvince = value;
			}
		}


				

		[System.Runtime.Serialization.DataMember()]
		public string SourceCode
		{
			get 
			{
				return this._SourceCode;
			}
			set
			{
				this._SourceCode = value;
			}
		}


				
		[System.Runtime.Serialization.DataMember()]
		public AccountMember.NullificationMask Nullify
		{
			get
			{
				return this._Nullify;
			}
			set
			{
				this._Nullify = value;
			}
		}

		[System.Runtime.Serialization.DataContract()]
		public class NullificationMask
		{
							
			private bool _MatchEmail;
							
			private bool _MatchPhone;
							
			private bool _MatchScore;
							
			private bool _StdAddressLine1;
							
			private bool _StdCity;
							
			private bool _StdPostalCode;
							
			private bool _StdStateProvince;
							
			private bool _SourceCode;
			
		[System.Runtime.Serialization.DataMember()]
		public bool MatchEmail
		{
			get
			{
				return this._MatchEmail;
			}
			set
			{
				this._MatchEmail = value;
			}
		}


		[System.Runtime.Serialization.DataMember()]
		public bool MatchPhone
		{
			get
			{
				return this._MatchPhone;
			}
			set
			{
				this._MatchPhone = value;
			}
		}


		[System.Runtime.Serialization.DataMember()]
		public bool MatchScore
		{
			get
			{
				return this._MatchScore;
			}
			set
			{
				this._MatchScore = value;
			}
		}


		[System.Runtime.Serialization.DataMember()]
		public bool StdAddressLine1
		{
			get
			{
				return this._StdAddressLine1;
			}
			set
			{
				this._StdAddressLine1 = value;
			}
		}


		[System.Runtime.Serialization.DataMember()]
		public bool StdCity
		{
			get
			{
				return this._StdCity;
			}
			set
			{
				this._StdCity = value;
			}
		}


		[System.Runtime.Serialization.DataMember()]
		public bool StdPostalCode
		{
			get
			{
				return this._StdPostalCode;
			}
			set
			{
				this._StdPostalCode = value;
			}
		}


		[System.Runtime.Serialization.DataMember()]
		public bool StdStateProvince
		{
			get
			{
				return this._StdStateProvince;
			}
			set
			{
				this._StdStateProvince = value;
			}
		}


		[System.Runtime.Serialization.DataMember()]
		public bool SourceCode
		{
			get
			{
				return this._SourceCode;
			}
			set
			{
				this._SourceCode = value;
			}
		}

		}
	}
} 

