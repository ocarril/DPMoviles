﻿using System;
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
    public class ReservationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ReservationCrearTest()
        {
            Reservation objReservation = new Reservation
             {
                 dateReservation = DateTime.Now,
                 startParking = DateTime.Now.AddHours(2),
                 finishParking = DateTime.Now.AddHours(5),
                 userID = 3,
                 parkingSpaceID = 85,
                 status = true,
                 reservationID = 0
             };
            JavaScriptSerializer jsx = new JavaScriptSerializer();
            string postdata = jsx.Serialize(objReservation);
            byte[] data = Encoding.UTF8.GetBytes(postdata);

            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:3643/Parking.svc/Reservation");

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
        public void ReservationUpdateTest()
        {
            Reservation objReservation = new Reservation
            {
                dateReservation = DateTime.Now,
                startParking = DateTime.Now.AddHours(3),
                finishParking = DateTime.Now.AddHours(6),
                userID = 3,
                parkingSpaceID = 99,
                status = true,
                reservationID = 96
            };
            JavaScriptSerializer jsx = new JavaScriptSerializer();
            string postdata = jsx.Serialize(objReservation);
            byte[] data = Encoding.UTF8.GetBytes(postdata);

            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:3643/Parking.svc/Reservation");

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
        public void ReservationDeleteTest()
        {
            string strURL = "http://localhost:3643/Parking.svc/Reservation";
            string reserveID = "97";
            
            HttpWebRequest reqDelete = (HttpWebRequest)WebRequest
                .Create(strURL + "/" + reserveID);

            reqDelete.Method = "DELETE";
           
            var res = (HttpWebResponse)reqDelete.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string userJson = reader.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();
            string reservationEliminado = js.Deserialize<string>(userJson);

            if (reservationEliminado == "0")
                Assert.AreEqual("0", reservationEliminado);
            else if (reservationEliminado.Length > 2)
                Assert.AreNotEqual("2", reservationEliminado);

        }
    }
}
