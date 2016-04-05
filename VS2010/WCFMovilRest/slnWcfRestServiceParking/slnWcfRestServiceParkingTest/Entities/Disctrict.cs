using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParkingTest
{
    public class Disctrict
    {
        public Disctrict()
        {
            objProvince = new Province();
        }

        public int disctrictId { get; set; }
        public string name { get; set; }
        public int provinceId { get; set; }

        public Province objProvince { get; set; }
    }
}