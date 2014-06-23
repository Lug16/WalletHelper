using PostSharp.Patterns.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using WalletHelper.Common;
using WalletHelper.DataAccess;
using WalletHelper.Entity.Enums;

namespace WalletHelper.Business
{
    /// <summary>
    /// Objeto de negocio Payment
    /// </summary>
    public class Payment : IPayment
    {
        private ResourceReacher _resourceReacher = new ResourceReacher(ResourceTypes.Messages);

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

            IResponseBusiness<Entity.Payment> response = new ResponseBusiness<Entity.Payment>()
            {
                Entity = null,
                IsError = true,
                Message = string.Empty
            };
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
                    response.Message = _resourceReacher.GetString("PaymentSaveDbUpdateConcurrencyException");
                }
                catch (DbUpdateException uex)
                {
                    response.Message = _resourceReacher.GetString("PaymentSaveDbUpdateException");
                }
                catch (DbEntityValidationException eex)
                {
                    response.Message = _resourceReacher.GetString("PaymentSaveDbEntityValidationException");
                }
                catch (NotSupportedException sex)
                {
                    response.Message = _resourceReacher.GetString("PaymentSaveNotSupportedException");
                }
                catch (ObjectDisposedException dex)
                {
                    response.Message = _resourceReacher.GetString("PaymentSaveObjectDisposedException");
                }
                catch (InvalidOperationException iex)
                {
                    response.Message = _resourceReacher.GetString("PaymentSaveInvalidOperationException");
                }
                finally
                {
                    if (string.IsNullOrEmpty(response.Message))
                    {
                        response.Entity = payment;
                        response.IsError = false;
                    }
                    ctx.Dispose();
                }
            }
            else
                response.Message = validatePayment.Message;

            return response;
        }

        /// <summary>
        /// Obtiene los ingresos/egresos del dia.
        /// </summary>
        /// <returns><c>IList<Entity.Payment></c></returns>
        public IList<Entity.Payment> GetPaymentsDay()
        {
            WalletHelperContext ctx = new WalletHelperContext();
            IList<Entity.Payment> ret = new List<Entity.Payment>();
            try
            {
                var query = from q in ctx.Payments
                            where q.Date.Day == DateTime.Now.Day &&
                            q.Date.Month == DateTime.Now.Month &&
                            q.Date.Year == DateTime.Now.Year
                            select q;
                ret = query.ToList();
            }
            finally
            {
                ctx.Dispose();
            }
            return ret;
        }

        /// <summary>
        /// Obtiene los ingresos/egresos segun los filtros de fecha.
        /// </summary>
        /// <param name="begin">Fecha inicial.</param>
        /// <param name="end">Fecha final.</param>
        /// <returns><c>IList<Entity.Payment></c></returns>
        public IList<Entity.Payment> GetPayments(DateTime begin, DateTime end)
        {
            WalletHelperContext ctx = new WalletHelperContext();
            IList<Entity.Payment> ret = new List<Entity.Payment>();
            try
            {
                var query = from q in ctx.Payments
                            where q.Date>= begin &&
                            q.Date <= end
                            select q;
                ret = query.ToList();
            }
            finally
            {
                ctx.Dispose();
            }
            return ret;
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
                validate.Message += _resourceReacher.GetString("PaymentDateNull");
            if (string.IsNullOrEmpty(payment.Description))
                validate.Message += _resourceReacher.GetString("PaymentDescriptionEmpty");
            if (payment.PaymentMethodDetail == null)
                validate.Message += _resourceReacher.GetString("PaymentPaymentMethodDetailNull");
            if (payment.PaymentType <= 0)
                validate.Message += _resourceReacher.GetString("PaymentPaymentType");
            if (payment.User == null)
                validate.Message += _resourceReacher.GetString("PaymentUserNull");
            if (payment.Value == 0)
                validate.Message += _resourceReacher.GetString("PaymentValueIsZero");

            validate.IsValid = string.IsNullOrEmpty(validate.Message);
            
            return validate;
        }
        #endregion


       
    }
}