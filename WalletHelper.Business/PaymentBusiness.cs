using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using WalletHelper.Common;
using WalletHelper.DataAccess;

namespace WalletHelper.Business
{
    /// <summary>
    /// Objeto de negocio Payment
    /// </summary>
    public class Payment : BaseBusiness, IPayment
    {
        /// <summary>
        /// Guarda un ingreso/egreso
        /// </summary>
        /// <param name="payment">Entidad a guardar</param>
        /// <returns><c>IResponseBusiness<Entity.Payment></c></returns>
        public IResponseBusiness<Entity.Payment> Save(Entity.Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException("payment");

            IResponseBusiness<Entity.Payment> response = new ResponseBusiness<Entity.Payment>();
            IResponseValidate validatePayment = ValidatePayment(payment);

            if (validatePayment.IsValid)
            {
                WalletHelperContext ctx = new WalletHelperContext();
                ctx.Payment.Add(payment);
                try
                {
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException cex)
                { }
                catch (DbUpdateException uex)
                { }
                catch (DbEntityValidationException eex)
                { }
                catch (NotSupportedException sex)
                { }
                catch (ObjectDisposedException dex)
                { }
                catch (InvalidOperationException iex)
                { }
            }

            return response;
        }

        /// <summary>
        /// Valida un ingreso/egreso
        /// </summary>
        /// <param name="payment">Entidad a validar</param>
        /// <returns><c>IResponseValidate</c></returns>
        public IResponseValidate ValidatePayment(Entity.Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException("payment");

            IResponseValidate validate = new ResponseValidate();
            validate.Message = string.Empty;

            if (payment.Date == null)
                validate.Message = "";
            if (payment.Description == null)
                validate.Message = "";
            if (payment.PaymentMethodDetail == null)
                validate.Message = "";
            if (payment.PaymentType <= 0)
                validate.Message = "";
            if (payment.ScheduledPayment == null)
                validate.Message = "";
            if (payment.User == null)
                validate.Message = "";
            if (payment.Value == 0)
                validate.Message = "";

            validate.IsValid = string.IsNullOrEmpty(validate.Message);

            return validate;
        }
    }
}