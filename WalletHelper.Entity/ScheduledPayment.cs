using WalletHelper.Entity.Enums;

namespace WalletHelper.Entity
{
    /// <summary>
    /// This class identifies the detail of a scheduled payment
    /// </summary>
    public class ScheduledPayment
    {
        /// <summary>
        /// Unique ObjectId that identifies the record
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Description of the payment
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Value of the payment
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Type of the payment
        /// </summary>
        public PaymentTypes PaymentType { get; set; }

        /// <summary>
        /// Identifier of the schedule
        /// </summary>
        public string ScheduleId { get; set; }
    }
}
