using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class Province
    {
        public Province()
        {
            objDepartment = new Department();
            lstDisctrict = new List<Disctrict>();
        }
        [DataMember]
        public int provinceId { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int departmentId { get; set; }

        [DataMember]
        public Department objDepartment { get; set; }
        [DataMember]
        public List<Disctrict> lstDisctrict { get; set; }
    }
}