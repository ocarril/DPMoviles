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
        private ReservationDAO objReservationDAO = new ReservationDAO();
        private ParkingSpaceDAO objParkingSpaceDAO = new ParkingSpaceDAO();
        private ProviderDAO objProviderDAO = new ProviderDAO();

        #region /* Tabla : ParkingLot*/

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

        #endregion

        #region /* Tabla : Reservation*/

        public Reservation getReservation(string reservationID)
        {
            return objReservationDAO.getReservation(reservationID);
        }

        public string registerReservation(Reservation objReservation)
        {
            return objReservationDAO.registerReservation(objReservation);
        }

        public string updateReservation(Reservation objReservation)
        {
            return objReservationDAO.updteReservation(objReservation);
        }

        public string deleteReservation(string reservationID)
        {
            return objReservationDAO.deleteReservation(reservationID);
        }

        #endregion

        #region /* Tabla : ParkingSpace*/

        public ParkingSpace getParkingSpace(string parkingSpaceID)
        {
            return objParkingSpaceDAO.getParkingSpace(parkingSpaceID);
        }

        public string registerParkingSpace(ParkingSpace objParkingSpace)
        {
            return objParkingSpaceDAO.registerParkingSpace(objParkingSpace);
        }

        public string updateParkingSpace(ParkingSpace objParkingSpace)
        {
            return objParkingSpaceDAO.updteParkingSpace(objParkingSpace);
        }

        public string deleteParkingSpace(string parkingSpaceID)
        {
            return objParkingSpaceDAO.deleteParkingSpace(parkingSpaceID);
        }

        #endregion

        #region /* Tabla : Provider*/

        public Provider getProvider(string providerID)
        {
            return objProviderDAO.getProvider(providerID);
        }

        public string registerProvider(Provider objProvider)
        {
            return objProviderDAO.registerProvider(objProvider);
        }

        public string updateProvider(Provider objProvider)
        {
            return objProviderDAO.updateProvider(objProvider);
        }

        public string deleteProvider(string providerID)
        {
            return objProviderDAO.deleteProvider(providerID);
        }

        #endregion

    }
}
