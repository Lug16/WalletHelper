using WalletHelper.Entity.Enums;

namespace WalletHelper.Entity
{
    /// <summary>
    /// Entidad que representa el valor de un tipo de movimiento.
    /// </summary>
    public class PaymentValue
    {
        public PaymentTypes PaymentType { get; set; }
        public decimal Value { get; set; }
    }
}
