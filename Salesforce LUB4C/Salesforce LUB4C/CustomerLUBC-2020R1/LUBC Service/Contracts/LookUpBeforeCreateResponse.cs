using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Mdm.AccountService.Contracts
{
    [DataContract]
    public class LookUpBeforeCreateResponse
    {
        [DataMember]
        public List<MatchMember> MatchedMembers { get; set; }

    }

    [DataContract]
    public class MatchMember
    {
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