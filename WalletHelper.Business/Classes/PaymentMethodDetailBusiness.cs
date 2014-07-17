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
    public class PaymentMethodDetail : BaseBusiness,IDataContract<Entity.PaymentMethodDetail>, IValidate<Entity.PaymentMethodDetail>
    {
        public PaymentMethodDetail(Entity.User user) : base(user) { }

        internal PaymentMethodDetail(Entity.User user, WalletHelperContext context): base(user, context) { }

        /// <summary>
        /// Obtiene el detalle del método de pago por defecto de un usuario. Método de pago con ID=0.
        /// </summary>
        /// <returns></returns>
        public Entity.PaymentMethodDetail GetDefault()
        {
            Entity.PaymentMethodDetail ret = null;
            var query = from q in _context.PaymentMethodDetails
                        where q.User.Id == this._user.Id &&
                        q.PaymentMethodId == 0 // TODO No debe ir este cero quemado
                        select q;
            ret = query.FirstOrDefault();
            return ret;
        }

        /// <summary>
        /// Guarda un método de pago.
        /// </summary>
        /// <param name="entity">Método de pago.</param>
        /// <returns><c>Interfaces.IResponseBusiness<Entity.PaymentMethodDetail></c></returns>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        [LogException]
        public IResponseBusiness<Entity.PaymentMethodDetail> Insert(Entity.PaymentMethodDetail entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            IResponseBusiness<Entity.PaymentMethodDetail> response = new ResponseBusiness<Entity.PaymentMethodDetail>()
            {
                Entity = null,
                IsError = true,
                Message = string.Empty
            };

            IResponseValidate validatePayment = Validate(entity);

            if (validatePayment.IsValid)
            {
                _context.PaymentMethodDetails.Add(entity);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException cex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetailSaveDbUpdateConcurrencyException");
                }
                catch (DbUpdateException uex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetailSaveDbUpdateException");
                }
                catch (DbEntityValidationException eex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetailSaveDbEntityValidationException");
                }
                catch (NotSupportedException sex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetailSaveNotSupportedException");
                }
                catch (ObjectDisposedException dex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetailSaveObjectDisposedException");
                }
                catch (InvalidOperationException iex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetailSaveInvalidOperationException");
                }
                finally
                {
                    if (string.IsNullOrEmpty(response.Message))
                    {
                        response.Entity = entity;
                        response.IsError = false;
                    }
                }
            }
            else
                response.Message = validatePayment.Message;

            return response;
        }

        public Interfaces.IResponseBusiness<Entity.PaymentMethodDetail> Update(Entity.PaymentMethodDetail entity)
        {
            throw new System.NotImplementedException();
        }

        public Interfaces.IResponseBusiness<Entity.PaymentMethodDetail> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Obtiene un método de pagun especifico de un cliente
        /// </summary>
        /// <param name="id">ID del método de pago.</param>
        /// <returns><c>Entity.PaymentMethodDetail</c></returns>
        public Entity.PaymentMethodDetail GetById(int id)
        {
            Entity.PaymentMethodDetail ret = null;
            var query = from q in _context.PaymentMethodDetails
                        where q.UserId == this._user.Id &&
                        q.Id == id
                        select q;
            ret = query.FirstOrDefault();
            return ret;
        }

        /// <summary>
        /// Obtiene todos los métodos de pago de un usuario.
        /// </summary>
        /// <returns><c>IEnumerable<Entity.PaymentMethodDetail></c></returns>
        public IEnumerable<Entity.PaymentMethodDetail> GetAll()
        {
            IList<Entity.PaymentMethodDetail> ret = new List<Entity.PaymentMethodDetail>();
            var query = from q in _context.PaymentMethodDetails
                        where q.UserId == this._user.Id
                        select q;
            ret = query.ToArray();
            return ret;
        }

        /// <summary>
        /// Valida una entidad <c>Entity.PaymentMethodDetail</c>.
        /// </summary>
        /// <param name="entity">Entidad.</param>
        /// <returns><c>IResponseValidate</c></returns>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        public IResponseValidate Validate(Entity.PaymentMethodDetail entity)
        {
            if (entity==null)
                throw new ArgumentNullException("entity");

            IResponseValidate validate = new ResponseValidate();
            validate.Message = string.Empty;

            if (string.IsNullOrEmpty(entity.Name))
                validate.Message += this._resourceReacher.GetString("PaymentMethodDetailNameEmpty");
            if (entity.PaymentMethodId<=0)
                validate.Message += _resourceReacher.GetString("PaymentMethodDetailPaymentMethodInvalid");
            if (entity.UserId!=this._user.Id)
                validate.Message += _resourceReacher.GetString("PaymentMethodDetailUserInvalid");

            validate.IsValid = string.IsNullOrEmpty(validate.Message);

            return validate;
        }
    }
}