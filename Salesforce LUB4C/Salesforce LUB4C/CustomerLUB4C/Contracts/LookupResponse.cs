using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Mdm.Profisee_Customer360Service.Contracts
{
	[DataContract]
	public class LookupResponse
	{
		[DataMember]
		public bool Success { get; set; }

		[DataMember]
		public string ErrorMessage { get; set; }

		[DataMember]
		public List<MemberDataContracts.CustomerMember> Matches { get; set; }
	}
}