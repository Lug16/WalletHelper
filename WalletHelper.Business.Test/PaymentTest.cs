using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WalletHelper.Entity.Enums;
using WalletHelper.Interfaces;

namespace WalletHelper.Business.Test
{
    [TestClass]
    public class PaymentTest
    {
        public PaymentTest() { }

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
        /// Se prueba que siempre se devuelva al menos un item en la lista, filtrado por día.
        /// </summary>
        [TestMethod]
        public void GetPaymentValuesDayTestMethod()
        {
            IEnumerable<Entity.PaymentValue> valueReturned = null;
            IPayment paymentBusiness = new Payment(new Entity.User() { Id = 12 });

            valueReturned = paymentBusiness.GetPaymentValues(PaymentValues.Day);
            Assert.IsNotNull(valueReturned);
        }

        /// <summary>
        /// Se prueba que se devuelva un error en el método Insert.
        /// </summary>
        [TestMethod]
        public void InsertErrorTestMethod()
        {
            IResponseBusiness<Entity.Payment> valueReturned = null;
            IDataContract<Entity.Payment> paymentBusiness = new Business.Payment(new Entity.User());

            Entity.Payment payment = new Entity.Payment()
            {
                Date = DateTime.Now,
                Description = "Prueba",
                PaymentType = (int)PaymentTypes.Income,
                Value = 10,
                PaymentMethodDetail = new Entity.PaymentMethodDetail(),
                User= new Entity.User()
            };

            valueReturned = paymentBusiness.Insert(payment);
            Assert.IsTrue(valueReturned.IsError);
        }

        /// <summary>
        /// Se prueba que no se retorne filas vacias para el método GetPaymentsDay.
        /// </summary>
        [TestMethod]
        public void GetPaymentsDayNotNullTestMethod()
        {
            IEnumerable<Entity.Payment> valueReturned = null;
            var paymentBusiness = new Business.Payment(new Entity.User());

            valueReturned = paymentBusiness.GetPaymentsDay();
            Assert.IsNotNull(valueReturned);
        }

        /// <summary>
        /// Se prueba que se devuelva un error en el método InsertCapture.
        /// </summary>
        [TestMethod]
        public void InsertCaptureErrorTestMethod()
        {
            IResponseBusiness<Entity.Payment> valueReturned = null;
           Payment paymentBusiness = new Business.Payment(new Entity.User());

           Entity.Capture capture = new Entity.Capture()
           {
               Id = 0,
               Image = System.Text.Encoding.UTF8.GetBytes(new char[] { 'z', 'a' }),
               Payment = null,
               PaymentId = 0
           };

           valueReturned = paymentBusiness.InsertCapture(capture);
           Assert.IsTrue(valueReturned.IsError);
        }
    }
}
