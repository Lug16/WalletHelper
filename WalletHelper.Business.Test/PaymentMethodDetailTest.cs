using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalletHelper.Interfaces;

namespace WalletHelper.Business.Test
{
    [TestClass]
    public class PaymentMethodDetailTest
    {
        public PaymentMethodDetailTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Se prueba que se devuelva un error en el método Insert.
        /// </summary>
        [TestMethod]
        public void InsertErrorTestMethod()
        {
            IResponseBusiness<Entity.PaymentMethodDetail> valueReturned = null;
            IDataContract<Entity.PaymentMethodDetail> paymentMethodDetailBusiness = new Business.PaymentMethodDetail(new Entity.User());

            Entity.PaymentMethodDetail paymentMethodDetail = new Entity.PaymentMethodDetail()
            {
                Name = "CC",
                PaymentMethodId = 1,
                ReferenceNumber = string.Empty,
                User = new Entity.User()
            };

            valueReturned = paymentMethodDetailBusiness.Insert(paymentMethodDetail);
            Assert.IsTrue(valueReturned.IsError);
        }
    }
}
