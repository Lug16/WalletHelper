using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using WalletHelper.Common;
using WalletHelper.DataAccess;
using WalletHelper.Entity.Enums;
using WalletHelper.Interfaces;

namespace WalletHelper.Business
{
    /// <summary>
    /// Objeto de negocio Payment
    /// </summary>
    public class Payment : IDataContract<Entity.Payment>, IValidate<Entity.Payment>,IPayment
    {
        private ResourceReacher _resourceReacher = new ResourceReacher(ResourceTypes.Messages);
        private Entity.User _user = new Entity.User();

        public Payment(Entity.User user)
        {
            this._user = user;
        }

        [LogException]
        public IResponseBusiness<Entity.Payment> Insert(Entity.Payment entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            IResponseBusiness<Entity.Payment> response = new ResponseBusiness<Entity.Payment>()
            {
                Entity = null,
                IsError = true,
                Message = string.Empty
            };

            IResponseValidate validatePayment = Validate(entity);

            if (validatePayment.IsValid)
            {
                WalletHelperContext ctx = new WalletHelperContext();
                ctx.Payments.Add(entity);
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
                        response.Entity = entity;
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
        /// Crea un movimiento a partir de una captura de imagen
        /// </summary>
        /// <param name="capture">Entidad que contiene la imagen capturada</param>
        /// <returns><c>IResponseBusiness<Entity.Payment></c></returns>
        /// <exception cref="System.ArgumentNullException">capture</exception>
        public IResponseBusiness<Entity.Payment> InsertCapture(Entity.Capture capture)
        {
            if (capture == null)
                throw new ArgumentNullException("capture");

            IResponseBusiness<Entity.Payment> response = new ResponseBusiness<Entity.Payment>()
            {
                Entity = null,
                IsError = true,
                Message = string.Empty
            };
            WalletHelperContext ctx = new WalletHelperContext();
            Entity.Payment payment = null;

            if (capture.Payment == null) //Se crea Payment con valores por defecto
            {
                capture.Payment = new Entity.Payment(); // Se instancia Payment para que la validación de la captura no de error por la falta de Payment
                Business.Capture captureBusiness = new Business.Capture();
                IResponseValidate validateCapture = captureBusiness.Validate(capture);
                if (validateCapture.IsValid)
                {
                    PaymentMethodDetail paymentMethodDetailBusiness = new PaymentMethodDetail(this._user);
                    Status statusBusiness = new Status();

                    payment = new Entity.Payment();
                    payment.Date = DateTime.Now;
                    payment.Description = string.Empty;
                    payment.IsScheduled = false;
                    payment.PaymentMethodDetail = paymentMethodDetailBusiness.GetDefault();
                    payment.PaymentType = (int)Entity.Enums.PaymentTypes.None;
                    payment.Status = statusBusiness.GetDefault();
                    payment.User = this._user;
                    payment.Value = 0;
                    payment.Captures.Add(capture);
                    capture.Payment = payment;
                    
                    ctx.Payments.Add(payment);
                }
                else
                    response.Message = validateCapture.Message;
            }
            else
            {
                payment = capture.Payment;
                ctx.Captures.Add(capture);
            }

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

            return response;
        }

        public IResponseBusiness<Entity.Payment> Update(Entity.Payment entity)
        {
            throw new NotImplementedException();
        }

        public IResponseBusiness<Entity.Payment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entity.Payment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.Payment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResponseValidate Validate(Entity.Payment entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            IResponseValidate validate = new ResponseValidate();
            validate.Message = string.Empty;

            if (entity.Date == null)
                validate.Message += _resourceReacher.GetString("PaymentDateNull");
            if (string.IsNullOrEmpty(entity.Description))
                validate.Message += _resourceReacher.GetString("PaymentDescriptionEmpty");
            if (entity.PaymentMethodDetail == null)
                validate.Message += _resourceReacher.GetString("PaymentPaymentMethodDetailNull");
            if (entity.PaymentType <= 0)
                validate.Message += _resourceReacher.GetString("PaymentPaymentType");
            if (entity.User == null)
                validate.Message += _resourceReacher.GetString("PaymentUserNull");
            if (entity.Value == 0)
                validate.Message += _resourceReacher.GetString("PaymentValueIsZero");
            if (entity.User.Id!=this._user.Id)
                validate.Message += _resourceReacher.GetString("PaymentUserInvalid");

            validate.IsValid = string.IsNullOrEmpty(validate.Message);

            return validate;
        }

        public IEnumerable<Entity.Payment> GetPaymentsDay()
        {
            WalletHelperContext ctx = new WalletHelperContext();
            IList<Entity.Payment> ret = new List<Entity.Payment>();
            try
            {
                var query = from q in ctx.Payments
                            where q.User.Id == this._user.Id &&
                            q.Date.Day == DateTime.Now.Day &&
                            q.Date.Month == DateTime.Now.Month &&
                            q.Date.Year == DateTime.Now.Year
                            select q;
                ret = query.ToArray();
            }
            finally
            {
                ctx.Dispose();
            }
            return ret;
        }

        public IEnumerable<Entity.Payment> GetPayments(DateTime begin, DateTime end)
        {
            WalletHelperContext ctx = new WalletHelperContext();
            IList<Entity.Payment> ret = new List<Entity.Payment>();
            try
            {
                var query = from q in ctx.Payments
                            where q.User.Id == this._user.Id && 
                            q.Date >= begin &&
                            q.Date <= end
                            select q;
                ret = query.ToArray();
            }
            finally
            {
                ctx.Dispose();
            }
            return ret;
        }

        /// <summary>
        /// Obtiene los movimientos según el filtro PaymentValues.
        /// </summary>
        /// <param name="paymentValues">Filtro aplicar a los movimientos.</param>
        /// <returns></returns>
        public IEnumerable<Entity.PaymentValue> GetPaymentValues(PaymentValues paymentValues)
        {
            WalletHelperContext ctx = new WalletHelperContext();
            IList<Entity.PaymentValue> ret = new List<Entity.PaymentValue>();
            DateTime day = DateTime.Now.Date;
            DateTime week = DateTime.Now.AddDays(-7).Date;
            DateTime month = DateTime.Now.AddMonths(-1).Date;
            DateTime quarter = DateTime.Now.AddMonths(-3).Date;
            DateTime semester = DateTime.Now.AddMonths(-6).Date;
            DateTime annual = DateTime.Now.AddYears(-1).Date;

            try
            {
                var query = from q in ctx.Payments
                            where q.User.Id == this._user.Id &&
                            (q.Date >= (paymentValues == PaymentValues.Month ? month :
                                        paymentValues == PaymentValues.Quarter ? quarter :
                                        paymentValues == PaymentValues.Semester ? semester :
                                        paymentValues == PaymentValues.Week ? week :
                                        paymentValues == PaymentValues.Annual ? annual :
                                        day) &&
                              q.Date <= day)
                            group q by q.PaymentType into g
                            select new Entity.PaymentValue
                            {
                                PaymentType = (PaymentTypes)g.Key,
                                Value = g.Sum(v => v.Value)
                            };
                ret = query.ToArray();
            }
            finally
            {
                ctx.Dispose();   
            }
            return ret;
        }
    }
}