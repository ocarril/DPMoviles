using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class Disctrict
    {
        public Disctrict()
        {
            objProvince = new Province();
        }

        [DataMember]
        public int disctrictId { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int provinceId { get; set; }

        [DataMember]
        public Province objProvince { get; set; }
    }
}