using System;
using System.Collections.Generic;
using WalletHelper.Common;

namespace WalletHelper.Business
{
    /// <summary>
    /// Interfaz que expone la funcionalidad de negocio para Payment
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// Guarda un ingreso/egreso
        /// </summary>
        /// <param name="payment">Entidad a guardar</param>
        /// <returns><c>IResponseBusiness<Entity.Payment></c></returns>
        IResponseBusiness<Entity.Payment> Save(Entity.Payment payment);
        /// <summary>
        /// Obtiene los ingresos/egresos del dia.
        /// </summary>
        /// <returns><c>IList<Entity.Payment></c></returns>
        IList<Entity.Payment> GetPaymentsDay();
        /// <summary>
        /// Obtiene los ingresos/egresos segun los filtros de fecha.
        /// </summary>
        /// <param name="begin">Fecha inicial.</param>
        /// <param name="end">Fecha final.</param>
        /// <returns><c>IList<Entity.Payment></c></returns>
        IList<Entity.Payment> GetPayments(DateTime begin, DateTime end);
        /// <summary>
        /// Valida un ingreso/egreso
        /// </summary>
        /// <param name="payment">Entidad a validar</param>
        /// <returns><c>IResponseValidate</c></returns>
        IResponseValidate ValidatePayment(Entity.Payment payment);
    }
}
