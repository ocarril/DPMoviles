using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParkingTest
{
    public class Province
    {
        public Province()
        {
            objDepartment = new Department();
            lstDisctrict = new List<Disctrict>();
        }
        public int provinceId { get; set; }
        public string name { get; set; }
        public int departmentId { get; set; }

        public Department objDepartment { get; set; }
        public List<Disctrict> lstDisctrict { get; set; }
    }
}