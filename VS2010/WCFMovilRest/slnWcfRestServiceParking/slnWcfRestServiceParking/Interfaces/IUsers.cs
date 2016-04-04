using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

using slnWcfRestServiceParking.Dominio;

namespace slnWcfRestServiceParking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsers" in both code and config file together.
    [ServiceContract]
    public interface IUsers
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string ObtenerSaludo();

        [OperationContract]
        [WebInvoke(Method = "PUT",
                   UriTemplate = "Users",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string registerUser(User objUser);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "ValidateUser/{email}/{password}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        User validateUser(string email, string password);
        
        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "Users/{userID}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        User findUser(string userID);
    }
}
