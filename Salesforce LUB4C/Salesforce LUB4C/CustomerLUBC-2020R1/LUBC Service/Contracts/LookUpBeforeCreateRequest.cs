using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Mdm.AccountService.Contracts
{
    [DataContract]
    public class LookUpBeforeCreateRequest
    {

        [DataMember]
        public string StrategyName { get; set; }

        [DataMember]
        public Collection<MatchAttribute> MatchAttributes { get; set; }
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