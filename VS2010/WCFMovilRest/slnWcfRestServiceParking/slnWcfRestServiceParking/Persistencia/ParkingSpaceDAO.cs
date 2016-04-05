using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using slnWcfRestServiceParking.Dominio;

namespace slnWcfRestServiceParking.Persistencia
{
    public class ParkingSpaceDAO
    {
        private string cadenaConexion = null;

        public ParkingSpaceDAO()
        {
            cadenaConexion = UtilConexion.ObtenerConexion();
        }

        public ParkingSpace getParkingSpace(string parkingSpaceID)
        {
            ParkingSpace objParkingSpace = null;
            using (ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext(cadenaConexion))
            {
                var result = from pl in SQLDC.parkingSpaces
                             where pl.parkingSpaceID == (string.IsNullOrEmpty(parkingSpaceID) ? 0 : Convert.ToInt32(parkingSpaceID))
                             select pl;

                foreach (parkingSpace parkSpa in result)
                {
                    objParkingSpace = new ParkingSpace();
                    objParkingSpace.parkingSpaceID = parkSpa.parkingSpaceID;
                    objParkingSpace.parkingLotID = parkSpa.parkingLotID;
                    objParkingSpace.shortName = parkSpa.shortName;
                    objParkingSpace.status = parkSpa.status;
                }
            }

            return objParkingSpace;
        }

        public string registerParkingSpace(ParkingSpace objParkingSpace)
        {
            string objMesaje = "-1";
            try
            {
                using (ParkingDataClassesDataContext sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    parkingSpace objparkingSpace = new parkingSpace
                    {
                        parkingSpaceID = objParkingSpace.parkingSpaceID,
                        parkingLotID = objParkingSpace.parkingLotID,
                        shortName = objParkingSpace.shortName,
                        status = true,
                    };
                    sql.parkingSpaces.InsertOnSubmit(objparkingSpace);
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

        public string updteParkingSpace(ParkingSpace objParkingSpace)
        {
            string objMesaje = "-1";
            try
            {
                using (var sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var objparkingSpace = sql.parkingSpaces.Single(x => x.parkingSpaceID == objParkingSpace.parkingSpaceID);
                    
                    objparkingSpace.parkingLotID = objParkingSpace.parkingLotID;
                    objparkingSpace.parkingSpaceID = objParkingSpace.parkingSpaceID;
                    objparkingSpace.shortName = objParkingSpace.shortName;
                    objparkingSpace.status = objParkingSpace.status;

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

        public string deleteParkingSpace(string parkingSpaceID)
        {
            string objMesaje = "-1";
            try
            {
                using (var sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var objparkingSpace = sql.parkingSpaces.Single(x =>
                                                x.parkingSpaceID == (string.IsNullOrEmpty(parkingSpaceID) ? 0 : 
                                                                    Convert.ToInt32(parkingSpaceID)));

                    sql.parkingSpaces.DeleteOnSubmit(objparkingSpace);
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