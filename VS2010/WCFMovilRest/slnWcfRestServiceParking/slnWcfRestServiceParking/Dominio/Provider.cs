using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class Provider
    {
        public Provider()
        {
            objUser = new User();
            lstParkingLot = new List<ParkingLot>();
        }

        [DataMember]
        public int providerID { get; set; }
        [DataMember]
        public int userID { get; set; }
        [DataMember]
        public bool status { get; set; }

        [DataMember]
        public User objUser { get; set; }
        [DataMember]
        public List<ParkingLot> lstParkingLot { get; set; }
    }
}