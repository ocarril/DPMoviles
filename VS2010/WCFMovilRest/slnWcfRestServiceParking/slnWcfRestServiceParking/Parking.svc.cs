using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using slnWcfRestServiceParking.Dominio;
using slnWcfRestServiceParking.Persistencia;

namespace slnWcfRestServiceParking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Parking" in code, svc and config file together.
    public class Parking : IParking
    {
        private ParkingLotDAO objParkingLotDAO = new ParkingLotDAO();

        public List<ParkingLot> getParkingLots()
        {
            return objParkingLotDAO.getParkingLots();
        }

        public ParkingLot getParkingLot(string ParkingLotID)
        {
            return objParkingLotDAO.getParkingLot(ParkingLotID);
        }

        public List<ParkingSpace> getParkingPlaceByLot(string parkingLotID)
        {
            return objParkingLotDAO.getParkingPlaceByLot(parkingLotID);
        }

        public List<Reservation> getReservationByUser(string pEmail)
        {
            return objParkingLotDAO.getReservationByUser(pEmail);
        }

    }
}
