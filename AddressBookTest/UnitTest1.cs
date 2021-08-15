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
            int expect = 10;
            Assert.AreEqual(result, expect);
        }
    }
}
