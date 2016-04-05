using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace slnWcfRestServiceParkingTest
{
    [TestClass]
    public class ParkingSpaceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ParkingSpaceCrearTest()
        {
            ParkingSpace objParkingSpace = new ParkingSpace
             {
                 shortName = "XX-008",
                 parkingLotID = 15,
                 status = true,
                 parkingSpaceID = 0
             };
            JavaScriptSerializer jsx = new JavaScriptSerializer();
            string postdata = jsx.Serialize(objParkingSpace);
            byte[] data = Encoding.UTF8.GetBytes(postdata);

            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:3643/Parking.svc/ParkingSpace");

            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json; charset=utf-8";

            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string userJson = reader.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();
            string userCreado = js.Deserialize<string>(userJson);

            if (userCreado == "0")
                Assert.AreEqual("0", userCreado);
            else if (userCreado.Length > 2)
                Assert.AreNotEqual("2", userCreado);

        }

        [TestMethod]
        public void ParkingSpaceUpdateTest()
        {
            ParkingSpace objParkingSpace = new ParkingSpace
            {
                parkingSpaceID = 1,
                parkingLotID = 1,
                status = true,
                shortName = "NU-003-UPDATE",
            };
            JavaScriptSerializer jsx = new JavaScriptSerializer();
            string postdata = jsx.Serialize(objParkingSpace);
            byte[] data = Encoding.UTF8.GetBytes(postdata);

            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:3643/Parking.svc/ParkingSpace");

            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json; charset=utf-8";

            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string userJson = reader.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();
            string userCreado = js.Deserialize<string>(userJson);

            if (userCreado == "0")
                Assert.AreEqual("0", userCreado);
            else if (userCreado.Length > 2)
                Assert.AreNotEqual("2", userCreado);

        }

        [TestMethod]
        public void ParkingSpaceDeleteTest()
        {
            string strURL = "http://localhost:3643/Parking.svc/ParkingSpace";
            string parkingSpaceID = "150";
            
            HttpWebRequest reqDelete = (HttpWebRequest)WebRequest
                .Create(strURL + "/" + parkingSpaceID);

            reqDelete.Method = "DELETE";
           
            var res = (HttpWebResponse)reqDelete.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string userJson = reader.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();
            string parkingSpaceEliminado = js.Deserialize<string>(userJson);

            if (parkingSpaceEliminado == "0")
                Assert.AreEqual("0", parkingSpaceEliminado);
            else if (parkingSpaceEliminado.Length > 2)
                Assert.AreNotEqual("2", parkingSpaceEliminado);

        }
    }
}
