using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Profisee.LUB4CService.DataContracts
{
	[DataContract]
	public class LUB4CRequest
	{
		[DataMember]
		public DataContext DataContext { get; set; }

		[DataMember]
		public Collection<MatchAttribute> MatchAttributes { get; set; }

		[DataMember]
		public Collection<string> ReturnAttributes { get; set; }
	}

	[DataContract]
	public class DataContext
	{
		[DataMember]
		public string Model { get; set; }

		[DataMember]
		public string Version { get; set; }

		[DataMember]
		public string Entity { get; set; }

		[DataMember]
		public string MatchingStrategy { get; set; }
	}

	[DataContract]
	public class MatchAttribute
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Value { get; set; }
	}
}