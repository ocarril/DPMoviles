using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParkingTest
{
    public class Department
    {
        public Department()
        {
            lstProvince = new List<Province>();
        }

        public int departmentId { get; set; }
        public string name { get; set; }
        public List<Province> lstProvince { get; set; }
    }
}