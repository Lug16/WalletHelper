using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WalletHelper.Common;
using WalletHelper.Entity.Enums;
using WalletHelper.Interfaces;

namespace WalletHelper.Business.Test
{
    [TestClass]
    public class PaymentTest
    {
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
