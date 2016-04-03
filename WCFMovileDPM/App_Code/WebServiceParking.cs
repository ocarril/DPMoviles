using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Descripción breve de WebServiceParking
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class WebServiceParking : System.Web.Services.WebService {

    public WebServiceParking () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }

    [WebMethod]
    public string validateUser(string pEmail, string pPassword)
    {
        var json = string.Empty;
        try
        {
            ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext();
            var usuario = from result in SQLDC.user
                          where result.password == pPassword &&
                                result.email == pEmail
                          select result;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            json = jss.Serialize(usuario);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return json;
    }

    //[WebMethod]
    //public int registerUser(string name, string lastname)
}
