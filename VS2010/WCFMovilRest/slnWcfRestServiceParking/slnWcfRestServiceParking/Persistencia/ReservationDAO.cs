using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using slnWcfRestServiceParking.Dominio;

namespace slnWcfRestServiceParking.Persistencia
{
    public class ReservationDAO
    {
        private string cadenaConexion = null;

        public ReservationDAO()
        {
            cadenaConexion = UtilConexion.ObtenerConexion();
        }

        public Reservation getReservation(string reservationID)
        {
            Reservation objreservation = null;
            try
            {

                using (ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var lstReser = from rs in SQLDC.reservations
                                   where rs.reservationID == (string.IsNullOrEmpty(reservationID) ? 0 : Convert.ToInt32(reservationID))
                                   select rs;

                    foreach (reservation objReservation in lstReser)
                    {
                        objreservation = new Reservation();
                        objreservation.parkingSpaceID = objReservation.parkingSpaceID;
                        objreservation.dateReservation = objReservation.dateReservation;
                        objreservation.finishParking = objReservation.finishParking;
                        objreservation.reservationID = objReservation.reservationID;
                        objreservation.startParking = objReservation.startParking;
                        objreservation.userID = objReservation.userID;
                        objreservation.status = objReservation.status;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objreservation;
        }
        
        public string registerReservation(Reservation objReservation)
        {
            string objMesaje = "-1";
            try
            {
                using (ParkingDataClassesDataContext sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    reservation objreservation = new reservation
                    {
                        dateReservation = DateTime.Now,
                        startParking = objReservation.startParking,
                        finishParking = objReservation.finishParking,
                        parkingSpaceID = objReservation.parkingSpaceID,
                        userID = objReservation.userID,
                        status = true,
                    };
                    sql.reservations.InsertOnSubmit(objreservation);
                    sql.SubmitChanges();
                    objMesaje = "0";
                };
            }
            catch (Exception ex)
            {
                objMesaje = ex.Message;
            }
            return objMesaje;
        }

        public string updteReservation(Reservation objReservation)
        {
            string objMesaje = "-1";
            try
            {
                using (var sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var objreservation = sql.reservations.Single(x => x.reservationID == objReservation.reservationID);
                    
                    objreservation.dateReservation = DateTime.Now;
                    objreservation.startParking = objReservation.startParking;
                    objreservation.finishParking = objReservation.finishParking;
                    objreservation.parkingSpaceID = objReservation.parkingSpaceID;
                    objreservation.userID = objReservation.userID;
                    objreservation.status = true;
                    objreservation.reservationID = objReservation.reservationID;

                    sql.SubmitChanges();
                    objMesaje = "0";
                };
            }
            catch (Exception ex)
            {
                objMesaje = ex.Message;
            }
            return objMesaje;
        }

        public string deleteReservation(string reservationID)
        {
            string objMesaje = "-1";
            try
            {
                using (var sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var objreservation = sql.reservations.Single(x => 
                                                x.reservationID == (string.IsNullOrEmpty(reservationID)?0:Convert.ToInt32(reservationID)));

                    sql.reservations.DeleteOnSubmit(objreservation);
                    sql.SubmitChanges();
                    objMesaje = "0";
                };
            }
            catch (Exception ex)
            {
                objMesaje = ex.Message;
            }
            return objMesaje;
        }
    
    }
}