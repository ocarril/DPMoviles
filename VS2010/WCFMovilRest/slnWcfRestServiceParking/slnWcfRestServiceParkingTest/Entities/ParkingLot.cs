using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParkingTest
{
    public class ParkingLot
    {
        public ParkingLot()
        {
            objProvider = new Provider();
            objDisctrict = new Disctrict();
            lstParkingSpace = new List<ParkingSpace>();
        }

        public int parkingLotID { get; set; }
        public int providerID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int districtId { get; set; }
        public string description { get; set; }
        public string urlPicture { get; set; }
        public double longitud { get; set; }
        public double latitude { get; set; }
        public string LocalPhone { get; set; }
        public string openTime { get; set; }
        public string closeTime { get; set; }
        public double priceHour { get; set; }
        public bool status { get; set; }

        public Provider objProvider { get; set; }
        public Disctrict objDisctrict { get; set; }
        public List<ParkingSpace> lstParkingSpace { get; set; }
    }
}