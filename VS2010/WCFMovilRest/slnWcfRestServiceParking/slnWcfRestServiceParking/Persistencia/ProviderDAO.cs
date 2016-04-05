using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using slnWcfRestServiceParking.Dominio;

namespace slnWcfRestServiceParking.Persistencia
{
    public class ProviderDAO
    {
         private string cadenaConexion = null;

         public ProviderDAO()
        {
            cadenaConexion = UtilConexion.ObtenerConexion();
        }

        public Provider getProvider(string providerID)
        {
            Provider objprovider = null;
            try
            {

                using (ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var lstReser = from rs in SQLDC.providers
                                   where rs.providerID == (string.IsNullOrEmpty(providerID) ? 
                                                            0 : 
                                                            Convert.ToInt32(providerID))
                                   select rs;

                    foreach (provider objProvider in lstReser)
                    {
                        objprovider = new Provider();
                        objprovider.providerID = objProvider.providerID;
                        objprovider.userID = objProvider.userID;
                        objprovider.status = objProvider.status;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objprovider;
        }
        
        public string registerProvider(Provider objProvider)
        {
            string objMesaje = "-1";
            try
            {
                using (ParkingDataClassesDataContext sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    provider objprovider = new provider
                    {
                        userID = objProvider.userID,
                        status = true,
                    };
                    sql.providers.InsertOnSubmit(objprovider);
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

        public string updateProvider(Provider objProvider)
        {
            string objMesaje = "-1";
            try
            {
                using (var sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var objprovider = sql.providers.Single(x => 
                                                    x.providerID == objProvider.providerID);
                    
                    objprovider.userID = objProvider.userID;
                    objprovider.status = true;
                    objprovider.providerID = objProvider.providerID;

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

        public string deleteProvider(string providerID)
        {
            string objMesaje = "-1";
            try
            {
                using (var sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var objprovider = sql.providers.Single(x =>
                                                x.providerID == (string.IsNullOrEmpty(providerID) ? 
                                                                    0 : 
                                                                    Convert.ToInt32(providerID)));

                    sql.providers.DeleteOnSubmit(objprovider);
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