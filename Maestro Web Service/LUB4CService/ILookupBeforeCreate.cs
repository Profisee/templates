using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Profisee.LUB4CService.DataContracts;

namespace Profisee.LUB4CService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface ILookupBeforeCreate
	{
		[OperationContract]
		LUB4CResponse PerformLookup(LUB4CRequest request);
	}
}
