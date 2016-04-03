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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Users" in code, svc and config file together.
    public class Users : IUsers
    {
        private UserDAO objUserDAO = new UserDAO();

        public string ObtenerSaludo()
        {
            var hora = DateTime.Now.Hour;
            if (hora < 12)
                return "Buenos Dias";
            else if (hora < 19)
                return "Buenos Tardes";
            else
                return "Buenos Noches";
        }

        public User ValidateUser(string email, string password)
        {
            return objUserDAO.ValidateUser(email, password);
        }

        public string registerUser(User objUser)
        {
            return objUserDAO.registerUser(objUser);
        }

        public User FindUser(string userID)
        {
            return objUserDAO.FindUser(userID);
        }

    }
}
