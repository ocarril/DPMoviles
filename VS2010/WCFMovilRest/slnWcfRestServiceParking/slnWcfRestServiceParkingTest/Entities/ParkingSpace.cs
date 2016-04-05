using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParkingTest
{
    public class ParkingSpace
    {
        public int parkingSpaceID { get; set; }
        public int parkingLotID { get; set; }
        public string shortName { get; set; }
        public bool status { get; set; }

    }
}