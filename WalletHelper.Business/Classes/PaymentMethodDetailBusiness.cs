﻿using PostSharp.Patterns.Diagnostics;
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
    public class PaymentMethodDetail: IDataContract<Entity.PaymentMethodDetail>, IValidate<Entity.PaymentMethodDetail>
    {
        private ResourceReacher _resourceReacher = new ResourceReacher(ResourceTypes.Messages);
        Entity.User _user = new Entity.User();

        public PaymentMethodDetail(Entity.User user)
        {
            this._user = user;
        }

        /// <summary>
        /// Obtiene el detalle del método de pago por defecto de un usuario. Método de pago con ID=0.
        /// </summary>
        /// <returns></returns>
        public Entity.PaymentMethodDetail GetDefault()
        {
            WalletHelperContext ctx = new WalletHelperContext();
            Entity.PaymentMethodDetail ret = null;
            try
            {
                var query = from q in ctx.PaymentMethodDetails
                            where q.User.Id == this._user.Id &&
                            q.PaymentMethodId == 0 // TODO No debe ir este cero quemado
                            select q;
                ret = query.FirstOrDefault();
            }
            finally
            {
                ctx.Dispose();
            }
            return ret;
        }

        /// <summary>
        /// Guarda un método de pago.
        /// </summary>
        /// <param name="entity">Método de pago.</param>
        /// <returns><c>Interfaces.IResponseBusiness<Entity.PaymentMethodDetail></c></returns>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        [LogException]
        public Interfaces.IResponseBusiness<Entity.PaymentMethodDetail> Insert(Entity.PaymentMethodDetail entity)
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
                WalletHelperContext ctx = new WalletHelperContext();
                ctx.PaymentMethodDetails.Add(entity);
                try
                {
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException cex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetaulSaveDbUpdateConcurrencyException");
                }
                catch (DbUpdateException uex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetaulSaveDbUpdateException");
                }
                catch (DbEntityValidationException eex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetaulSaveDbEntityValidationException");
                }
                catch (NotSupportedException sex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetaulSaveNotSupportedException");
                }
                catch (ObjectDisposedException dex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetaulSaveObjectDisposedException");
                }
                catch (InvalidOperationException iex)
                {
                    response.Message = _resourceReacher.GetString("PaymentMethodDetaulSaveInvalidOperationException");
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
            WalletHelperContext ctx = new WalletHelperContext();
            Entity.PaymentMethodDetail ret = null;
            try
            {
                var query = from q in ctx.PaymentMethodDetails
                            where q.UserId == this._user.Id &&
                            q.Id == id
                            select q;
                ret = query.FirstOrDefault();
            }
            finally
            {
                ctx.Dispose();
            }
            return ret;
        }

        /// <summary>
        /// Obtiene todos los métodos de pago de un usuario.
        /// </summary>
        /// <returns><c>IEnumerable<Entity.PaymentMethodDetail></c></returns>
        public IEnumerable<Entity.PaymentMethodDetail> GetAll()
        {
            WalletHelperContext ctx = new WalletHelperContext();
            IList<Entity.PaymentMethodDetail> ret = new List<Entity.PaymentMethodDetail>();
            try
            {
                var query = from q in ctx.PaymentMethodDetails
                            where q.UserId == this._user.Id
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