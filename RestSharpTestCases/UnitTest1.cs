using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTestCases
{
    public class Address
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }

    [TestClass]
    public class RestTestCase
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:3000");
        }

        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/address", Method.GET);

            IRestResponse response = client.Execute(request);
            return response;
        }

        //Retrive all Contacts from Json_Server using Rest_api.
        [TestMethod]
        public void OnCallingGETApi_ReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Address> dataResponse = JsonConvert.DeserializeObject<List<Address>>(response.Content);
            Assert.AreEqual(4, dataResponse.Count);

            foreach (Address e in dataResponse)
            {
                System.Console.WriteLine("id: " + e.id + " Fname: " + e.firstName + " " + e.lastName);
            }
        }
        /// adding multiple contact to json_server using restSharp_api
        [TestMethod]
        public void givenContact_OnPost_ShouldReturnAddedContact()
        {
            List<Address> addressList = new List<Address>();
            addressList.Add(new Address { firstName= "Vivek", lastName="Reddy", address="ongl", contact="9678541230", state= "TN", zip="654543" });
            addressList.Add(new Address { firstName = "Ajay", lastName = "Kumar", address = "konda", contact = "9641541230", state = "TS", zip = "500047" });
            addressList.Add(new Address { firstName = "Powan", lastName = "star", address = "Amaravthi", contact = "9688541230", state = "AP", zip = "523441" });
            addressList.Add(new Address { firstName = "Swati", lastName = "Ba", address = "peta", contact = "9667541230", state = "WB", zip = "456789" });

            addressList.ForEach(addressData =>
            {
                RestRequest request = new RestRequest("/address", Method.POST);
                JObject jObjectBody = new JObject();
                jObjectBody.Add("firstName", addressData.firstName);
                jObjectBody.Add("lastName", addressData.lastName);
                jObjectBody.Add("address", addressData.address);
                jObjectBody.Add("contact", addressData.contact);
                jObjectBody.Add("state", addressData.state);
                jObjectBody.Add("zip", addressData.zip);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                Address dataResorce = JsonConvert.DeserializeObject<Address>(response.Content);
                Assert.AreEqual(addressData.firstName, dataResorce.firstName);
                Assert.AreEqual(addressData.lastName, dataResorce.lastName);
                Console.WriteLine(response.Content);
            });

            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Address> dataResorce = JsonConvert.DeserializeObject<List<Address>>(response.Content);
            Assert.AreEqual(8, dataResorce.Count);
        }
    }
}
