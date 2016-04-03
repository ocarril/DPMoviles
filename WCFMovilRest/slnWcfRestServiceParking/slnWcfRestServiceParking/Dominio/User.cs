using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace slnWcfRestServiceParking.Dominio
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int userID { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public DateTime registerDate { get; set; }
        [DataMember]
        public bool status { get; set; }
    }
}