using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WalletHelper.Common;
using WalletHelper.Entity.Enums;

namespace WalletHelper.Business.Test
{
    [TestClass]
    public class PaymentTest
    {
        /// <summary>
        /// Se prueba que se devuelva un error en el método Payment.
        /// </summary>
        [TestMethod]
        public void SaveErrorTestMethod()
        {
            IResponseBusiness<Entity.Payment> valueReturned = null;
            IPayment paymentBusiness = new Business.Payment(MessageLanguageFrontEnd.Spanish);

            Entity.Payment payment = new Entity.Payment()
            {
                Date = DateTime.Now,
                Description = "Prueba",
                PaymentType = (int)PaymentTypes.Income,
                Value = 10,
                PaymentMethodDetail = new Entity.PaymentMethodDetail(),
                User= new Entity.User()
            };

            valueReturned = paymentBusiness.Save(payment);
            Assert.IsTrue(valueReturned.IsError);
        }

        /// <summary>
        /// Se prueba que no se retorne filas vacias para el método GetPaymentsDay.
        /// </summary>
        [TestMethod]
        public void GetPaymentsDayNotNullTestMethod()
        {
            IList<Entity.Payment> valueReturned = null;
            IPayment paymentBusiness = new Business.Payment(MessageLanguageFrontEnd.Spanish);

            valueReturned = paymentBusiness.GetPaymentsDay();
            Assert.IsNotNull(valueReturned);
        }
    }
}
