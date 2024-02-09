using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Profisee.MasterDataMaestro.Services.DataContracts;
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using Profisee.Services.Sdk.AcceleratorFramework;

namespace Profisee.LUB4CService.DataContracts
{
	[DataContract]
	public class LUB4CResponse
	{
		[DataMember]
		public List<string> Messages { get; set; }

		[DataMember]
		public List<MaestroError> Errors { get; set; }

		[DataMember]
		public List<MatchMember> MatchedMembers { get; set; }

	}

	[DataContract]
	public class MatchMember
	{
		[DataMember]
		public double MatchScore { get; set; }

		[DataMember]
		public Collection<MemberAttribute> Attributes { get; set; }
	}

	[DataContract]
	public class MemberAttribute
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public object Value { get; set; }
	}
}