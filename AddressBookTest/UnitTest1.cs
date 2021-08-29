using CompleteAddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChekConnection()
        {
            AddressBookRepo addressbookrepo = new AddressBookRepo();
            bool result = addressbookrepo.EstablishConnection();
            bool expect = true;
            Assert.AreEqual(result, expect);
        }
        [TestMethod]
        public void GivenAddressBookDB_WhenRetrieve_ThenReturnContactsFromDataBase()
        {
            AddressBookRepo addressbookrepo = new AddressBookRepo();
            int result = addressbookrepo.RetrieveContactFromPerticularAddressBook();
            int expect = 11;
            Assert.AreEqual(result, expect);
        }
        [TestMethod]
        public void GivenAddressBooks_WhenEnterFirstName_ThenShouldUpdateContactInAddressBook()
        {
            bool expected = true;
            AddressBookRepo addrepo = new AddressBookRepo();
            AddressBookModel addmodel = new AddressBookModel();

            AddressBookModel editModel = new AddressBookModel();
            editModel.First_Name = "Balu";
            editModel.Last_Name = "Nagireddy";
            editModel.City = "Hyderbad";
            editModel.State = "Telengana";
            editModel.Email = "balureddy@gmail.com";
            editModel.BookName = "address001";
            editModel.AddressbookType = "office";
            bool result = addrepo.EditContactUsingFirstName(editModel);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GivenContactInsertDate_ThenReturnTotalEmployeeBetweenRange()
        {
            AddressBookRepo addrepo = new AddressBookRepo();
            int count = addrepo.getContactDataWithGivenDate();
            int expected = 10;
            Assert.AreEqual(expected, count);
        }
        [TestMethod]
        public void GivenAddressBook_returnNumberOf_ContactsFromPerticularCityOrState()
        {
            AddressBookRepo addrepo = new AddressBookRepo();
            int count = addrepo.RetrieveContactFromPerticularCityOrState();
            int expected = 7;
            Assert.AreEqual(expected, count);
        }
        [TestMethod]
        public void GivenAddressBooks_AddNewRecord_ThenShouldAddContactInAddressBook()
        {
            bool expected = true;
            AddressBookRepo addrepo = new AddressBookRepo();
            AddressBookModel addModel = new AddressBookModel();
            addModel.First_Name = "Mahesh";
            addModel.Last_Name = "Babu";
            addModel.City = "Hyderbad";
            addModel.State = "Telengana";
            addModel.Email = "mahesh@gmail.com";
            addModel.BookName = "address001";
            addModel.AddressbookType = "office";
            addModel.idate = new System.DateTime(2010, 11, 02);
            bool result = addrepo.EditContactUsingFirstName(addModel);
            Assert.AreEqual(expected, result);
        }
        
        // Calculating required time to adding new contact in database
        [TestMethod]
        public void GivenData_WhenAddedInDatabase_ThenCalculateRequiredTime()
        {
            AddressBookRepo addrepo = new AddressBookRepo();
            AddressBookModel addModel = new AddressBookModel()
            {
                First_Name = "rakesh",
                Last_Name = "ak",
                Address = "annanagar",
                City = "chennai",
                State = "Tammilnadu",
                Email = "mkda@gmail.com",
                BookName = "address002",
                AddressbookType = "office",
                Zip = "145236",
                Phone_Number = "7852143690",
                idate = new DateTime(2010, 11, 02)
            };
            DateTime startTime = DateTime.Now;
            addrepo.AddContact(addModel);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine($"Duration taken for insertion is {0}", (stopTime - startTime));
        }
    }
}
