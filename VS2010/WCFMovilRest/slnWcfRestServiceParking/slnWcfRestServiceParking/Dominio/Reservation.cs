using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class Reservation
    {
        public Reservation()
        {
            objParkingSpace = new ParkingSpace();
        }

        [DataMember]
        public int reservationID { get; set; }
        [DataMember]
        public int parkingSpaceID { get; set; }
        [DataMember]
        public int userID { get; set; }
        [DataMember]
        public DateTime dateReservation { get; set; }
        [DataMember]
        public string startParking { get; set; }
        [DataMember]
        public string finishParking { get; set; }
        [DataMember]
        public bool status { get; set; }

        [DataMember]
        public ParkingSpace objParkingSpace { get; set; }
    }
}