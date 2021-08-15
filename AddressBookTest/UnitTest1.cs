using CompleteAddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}