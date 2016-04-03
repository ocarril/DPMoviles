using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace slnWcfRestServiceParking.Persistencia
{
    public static class UtilConexion
    {
        public static string ObtenerConexion()
        {
            return ConfigurationManager.ConnectionStrings["DB_9FA6E8_parkingResBDConnectionString"].ToString();
        }
    }
}