﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class ParkingSpace
    {
        [DataMember]
        public int parkingSpaceID { get; set; }
        [DataMember]
        public int parkingLotID { get; set; }
        [DataMember]
        public string shortName { get; set; }
        [DataMember]
        public bool status { get; set; }
    }
}