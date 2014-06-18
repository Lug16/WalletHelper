using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using WalletHelper.Common;
using WalletHelper.DataAccess;
using WalletHelper.Entity.Enums;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

namespace WalletHelper.Business
{
    /// <summary>
    /// Objeto de negocio Payment
    /// </summary>
    public class Payment : BaseBusiness, IPayment
    {
        #region Constructores
        public Payment(MessageLanguageFrontEnd language) : base(language) { }
        #endregion

        #region Metodos publicos
        /// <summary>
        ///  Guarda un ingreso/egreso.
        /// </summary>
        /// <param name="payment">Entidad a guardar</param>
        /// <returns><c>IResponseBusiness<Entity.Payment></c></returns>
        /// <exception cref="System.ArgumentNullException">payment</exception>
        [LogException]
        public IResponseBusiness<Entity.Payment> Save(Entity.Payment payment)   
        {
            if (payment == null)
                throw new ArgumentNullException("payment");

            IResponseBusiness<Entity.Payment> response = new ResponseBusiness<Entity.Payment>();
            response.Entity = null;
            response.IsError = true;
            IResponseValidate validatePayment = ValidatePayment(payment);

            if (validatePayment.IsValid)
            {
                WalletHelperContext ctx = new WalletHelperContext();
                ctx.Payments.Add(payment);
                try
                {
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException cex)
                {
                    response.Message = this.ResourceMessages.GetString("PaymentSaveDbUpdateConcurrencyException");
                }
                catch (DbUpdateException uex)
                {
                    response.Message = this.ResourceMessages.GetString("PaymentSaveDbUpdateException");
                }
                catch (DbEntityValidationException eex)
                {
                    response.Message = this.ResourceMessages.GetString("PaymentSaveDbEntityValidationException");
                }
                catch (NotSupportedException sex)
                {
                    response.Message = this.ResourceMessages.GetString("PaymentSaveNotSupportedException");
                }
                catch (ObjectDisposedException dex)
                {
                    response.Message = this.ResourceMessages.GetString("PaymentSaveObjectDisposedException");
                }
                catch (InvalidOperationException iex)
                {
                    response.Message = this.ResourceMessages.GetString("PaymentSaveInvalidOperationException");
                }
                finally
                {
                    response.Entity = payment;
                    response.IsError = false;
                    response.Message = string.Empty;
                    ctx.Dispose();
                    Trace.Flush();
                }
            }
            else
                response.Message = validatePayment.Message;

            return response;
        }

        /// <summary>
        /// Valida un ingreso/egreso
        /// </summary>
        /// <param name="payment">Entidad a validar</param>
        /// <returns>
        ///   <c>IResponseValidate</c>
        /// </returns>
        /// <exception cref="System.ArgumentNullException">payment</exception>
        public IResponseValidate ValidatePayment(Entity.Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException("payment");

            IResponseValidate validate = new ResponseValidate();
            validate.Message = string.Empty;

            if (payment.Date == null)
                validate.Message = this.ResourceMessages.GetString("PaymentDateNull");
            if (string.IsNullOrEmpty(payment.Description))
                validate.Message = this.ResourceMessages.GetString("PaymentDescriptionEmpty");
            if (payment.PaymentMethodDetail == null)
                validate.Message = this.ResourceMessages.GetString("PaymentPaymentMethodDetailNull");
            if (payment.PaymentType <= 0)
                validate.Message = this.ResourceMessages.GetString("PaymentPaymentType");
            if (payment.User == null)
                validate.Message = this.ResourceMessages.GetString("PaymentUserNull");
            if (payment.Value == 0)
                validate.Message = this.ResourceMessages.GetString("PaymentValueIsZero");

            validate.IsValid = string.IsNullOrEmpty(validate.Message);
            
            return validate;
        }
        #endregion
    }
}