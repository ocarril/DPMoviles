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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IParking" in both code and config file together.
    [ServiceContract]
    public interface IParking
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "getParkingLots/",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        List<ParkingLot> getParkingLots();

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "getParkingLot/{parkingLotID}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ParkingLot getParkingLot(string parkingLotID);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "getParkingPlaceByLot/{parkingLotID}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        List<ParkingSpace> getParkingPlaceByLot(string parkingLotID);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "getReservationByUser/{email}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        List<Reservation> getReservationByUser(string email);
    }
}
