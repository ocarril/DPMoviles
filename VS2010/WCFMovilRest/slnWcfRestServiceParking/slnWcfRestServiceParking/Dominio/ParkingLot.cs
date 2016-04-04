using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class ParkingLot
    {
        public ParkingLot()
        {
            objProvider = new Provider();
            objDisctrict = new Disctrict();
            lstParkingSpace = new List<ParkingSpace>();
        }

        [DataMember]
        public int parkingLotID { get; set; }
        [DataMember]
        public int providerID { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public int districtId { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string urlPicture { get; set; }
        [DataMember]
        public double longitud { get; set; }
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public string LocalPhone { get; set; }
        [DataMember]
        public string openTime { get; set; }
        [DataMember]
        public string closeTime { get; set; }
        [DataMember]
        public double priceHour { get; set; }
        [DataMember]
        public bool status { get; set; }

        [DataMember]
        public Provider objProvider { get; set; }
        public Disctrict objDisctrict { get; set; }
        [DataMember]
        public List<ParkingSpace> lstParkingSpace { get; set; }
    }
}