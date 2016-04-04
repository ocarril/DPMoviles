using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class Department
    {
        public Department()
        {
            lstProvince = new List<Province>();
        }

        [DataMember]
        public int departmentId { get; set; }
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public List<Province> lstProvince { get; set; }
    }
}