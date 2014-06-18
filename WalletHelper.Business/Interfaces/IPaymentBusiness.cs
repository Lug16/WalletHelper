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
        IResponseBusiness<Entity.PaymentMethodDetail> Save(Entity.Payment payment);
        /// <summary>
        /// Valida un ingreso/egreso
        /// </summary>
        /// <param name="payment">Entidad a validar</param>
        /// <returns><c>IResponseValidate</c></returns>
        IResponseValidate ValidatePayment(Entity.Payment payment);
    }
}
