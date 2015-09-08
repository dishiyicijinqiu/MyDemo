using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entity
{
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class UserInfo
    {
        [DataMember]
        public string UserNo { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserPassWord { get; set; }
    }
}
