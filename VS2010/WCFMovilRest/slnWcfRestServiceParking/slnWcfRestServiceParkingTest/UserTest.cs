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
    public class UserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void UserFindTest()
        {
            // Prueba de OBTENER un alumno vía HTTP GET

            string strURL = "http://localhost:3643/Users.svc/Users";
            string strID = "3";
            HttpWebRequest reqObtener = (HttpWebRequest)WebRequest
               .Create(strURL + "/" + strID);
            reqObtener.Method = "GET";
            HttpWebResponse resObtener = (HttpWebResponse)reqObtener.GetResponse();
            StreamReader readerObtener = new StreamReader(resObtener.GetResponseStream());
            string userJsonObtener = readerObtener.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            User userCreado = js.Deserialize<User>(userJsonObtener);

            Assert.AreEqual("Orlando upd", userCreado.name);
            Assert.AreEqual("omcr1905@gmail.com", userCreado.email);
        }

        [TestMethod]
        public void ValidateUserTest()
        {
            // Prueba de OBTENER un alumno vía HTTP GET

            string strURL = "http://localhost:3643/Users.svc/ValidateUser";
            string strmail = "rcarril";
            string strpassword = "1234";
            HttpWebRequest reqObtener = (HttpWebRequest)WebRequest
               .Create(strURL + "/" + strmail + "/" + strpassword); //
            reqObtener.Method = "GET";
            HttpWebResponse resObtener = (HttpWebResponse)reqObtener.GetResponse();
            StreamReader readerObtener = new StreamReader(resObtener.GetResponseStream());
           
            string userJsonObtener = readerObtener.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            User userCreado = js.Deserialize<User>(userJsonObtener);

            Assert.AreEqual("Carril", userCreado.lastName);
            Assert.AreEqual("rcarril@gmail.com", userCreado.email);
        }

        [TestMethod]
        public void UserCrearTest()
        {
           User objUser = new User
            {
                email = "01prueba@gmail.com",
                lastName = "GUTIERREZ",
                name = "Juan",
                userID = 99,
                registerDate = DateTime.Now,
                status = true,
                password = "1234"
            };
            JavaScriptSerializer jsx = new JavaScriptSerializer();
            string  postdata = jsx.Serialize(objUser);
            byte[] data = Encoding.UTF8.GetBytes(postdata);

            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:3643/Users.svc/Users");

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

            Assert.AreEqual("0", userCreado);

        }
    }
}
