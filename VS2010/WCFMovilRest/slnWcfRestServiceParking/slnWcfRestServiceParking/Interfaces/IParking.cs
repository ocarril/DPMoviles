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
        #region /* Tabla : ParkingLot*/

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "getParkingLotsD/",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        DocParkingLot getParkingLotsD();

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

        #endregion

        #region /* Tabla : Reservation*/

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "getReservation/{reservationID}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        Reservation getReservation(string reservationID);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   UriTemplate = "Reservation",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string registerReservation(Reservation objReservation);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                   UriTemplate = "Reservation",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string updateReservation(Reservation objReservation);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                   UriTemplate = "Reservation/{reservationID}",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string deleteReservation(string reservationID);

        #endregion

        #region /* Tabla : ParkingSpace*/

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "ParkingSpace/{parkingSpaceID}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ParkingSpace getParkingSpace(string parkingSpaceID);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   UriTemplate = "ParkingSpace",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string registerParkingSpace(ParkingSpace objParkingSpace);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                   UriTemplate = "ParkingSpace",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string updateParkingSpace(ParkingSpace objParkingSpace);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                   UriTemplate = "ParkingSpace/{parkingSpaceID}",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string deleteParkingSpace(string parkingSpaceID);

        #endregion

        #region /* Tabla : Provider*/

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "Provider/{providerID}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        Provider getProvider(string providerID);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   UriTemplate = "Provider",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string registerProvider(Provider objProvider);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                   UriTemplate = "Provider",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string updateProvider(Provider objProvider);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                   UriTemplate = "Provider/{providerID}",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json)]
        string deleteProvider(string providerID);

        #endregion
    }
}
