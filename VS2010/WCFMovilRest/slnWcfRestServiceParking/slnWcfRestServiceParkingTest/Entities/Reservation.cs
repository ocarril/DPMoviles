using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParkingTest
{
    public class Reservation
    {
        public Reservation()
        {
            objParkingSpace = new ParkingSpace();
        }

        public int reservationID { get; set; }
        public int parkingSpaceID { get; set; }
        public int userID { get; set; }
        public DateTime dateReservation { get; set; }
        public string startParking { get; set; }
        public string finishParking { get; set; }
        public bool status { get; set; }

        public ParkingSpace objParkingSpace { get; set; }
    }
}