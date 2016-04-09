using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class DocParkingLot
    {
        public DocParkingLot()
        {

        }

        [DataMember]
        public int start { get; set; }
        [DataMember]
        public int num_found { get; set; }
        [DataMember]
        public int numFound { get; set; }
       
        [DataMember]
        public List<ParkingLot> lstParkingLot { get; set; }
    }
}