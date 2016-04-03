using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using slnWcfRestServiceParking.Dominio;

namespace slnWcfRestServiceParking.Persistencia
{
    public class UserDAO
    {
        private string cadenaConexion = null;
        
        public UserDAO()
        {
            cadenaConexion = UtilConexion.ObtenerConexion();
        }

        public User ValidateUser(string pEmail, string pPassword)
        {
            User objUser = null;
            try
            {
                using (ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var usuario = from result in SQLDC.users
                                  where result.password == pPassword &&
                                        result.email.IndexOf(pEmail) > -1
                                  select result;

                    foreach (var item in usuario)
                    {
                        objUser = new User
                        {
                            email = item.email,
                            lastName = item.lastName,
                            name = item.name,
                            password = item.password,
                            registerDate = item.registerDate.HasValue ? item.registerDate.Value : DateTime.Now,
                            status = item.status,
                            userID = item.userID
                        };
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser;
        }

        public User FindUser(string userID)
        {
            User objUser = null;
            try
            {
                using (ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var usuario = from result in SQLDC.users
                                  where result.userID == Convert.ToInt32(userID)
                                  select result;

                    foreach (var item in usuario)
                    {
                        objUser = new User
                        {
                            email = item.email,
                            lastName = item.lastName,
                            name = item.name,
                            password = item.password,
                            registerDate = item.registerDate.HasValue ? item.registerDate.Value : DateTime.Now,
                            status = item.status,
                            userID = item.userID
                        };
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser;
        }

        public string registerUser(User objUser)
        {
            string objMesaje = "-1";
            try
            {
                using (ParkingDataClassesDataContext sql = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    user objuser = new user
                    {
                        email = objUser.email,
                        lastName = objUser.lastName,
                        name = objUser.name,
                        password = objUser.password,
                        registerDate = DateTime.Now,
                        status = true,
                    };
                    sql.users.InsertOnSubmit(objuser);
                    sql.SubmitChanges();
                    objMesaje = "0";
                };
            }
            catch (Exception ex)
            {
                objMesaje = "2";
            }
            return objMesaje;
        }
       
    }
}