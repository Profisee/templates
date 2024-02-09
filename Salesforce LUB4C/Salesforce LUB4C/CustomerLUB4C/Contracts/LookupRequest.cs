using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Mdm.Profisee_Customer360Service.Contracts
{
	[DataContract]
	public class LookupRequest
	{
		[DataMember]
		public Dictionary<string, string> AttributeValues { get; set; }
	}
}