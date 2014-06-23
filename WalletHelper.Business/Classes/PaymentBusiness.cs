using PostSharp.Patterns.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using WalletHelper.Common;
using WalletHelper.DataAccess;
using WalletHelper.Entity.Enums;
using WalletHelper.Interfaces;

namespace WalletHelper.Business
{
    /// <summary>
    /// Objeto de negocio Payment
    /// </summary>
    public class Payment : IDataContract<Entity.Payment>, IValidate<Entity.Payment>
    {
        private ResourceReacher _resourceReacher = new ResourceReacher(ResourceTypes.Messages, new System.Globalization.CultureInfo("es"));
        private WalletHelperContext ctx = new WalletHelperContext();

        public IResponseBusiness<Entity.Payment> Insert(Entity.Payment entity)
        {
            int? id = null;

            if (entity == null)
                throw new ArgumentNullException("payment");

            IResponseBusiness<Entity.Payment> response = new ResponseBusiness<Entity.Payment>()
            {
                Entity = null,
                IsError = true,
                Message = string.Empty
            };

            IResponseValidate validatePayment = Validate(entity);

            if (validatePayment.IsValid)
            {
                ctx.Payments.Add(entity);
                try
                {
                    ctx.SaveChanges();
                    id = entity.Id;
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

        public bool Update(Entity.Payment entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
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
                throw new ArgumentNullException("payment");

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
                            where q.Date.Day == DateTime.Now.Day &&
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
                            where q.Date >= begin &&
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
    }
}