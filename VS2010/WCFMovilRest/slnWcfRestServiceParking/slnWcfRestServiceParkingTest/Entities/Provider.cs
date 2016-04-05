using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParkingTest
{
    public class Provider
    {
        public Provider()
        {
            objUser = new User();
            lstParkingLot = new List<ParkingLot>();
        }

        public int providerID { get; set; }
        public int userID { get; set; }
        public bool status { get; set; }

        public User objUser { get; set; }
        public List<ParkingLot> lstParkingLot { get; set; }
    }
}