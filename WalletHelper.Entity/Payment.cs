using System;
using WalletHelper.Entity.Enums;

namespace WalletHelper.Entity 
{
    /// <summary>
    /// This class contains the information of the Payment (E/I)
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Unique ObjectId that identifies the record
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Date when the record is created
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Detail of the record
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Value of the payment
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// If is the record of an scheduled payment
        /// </summary>
        public bool IsScheduled { get; set; }

        /// <summary>
        /// Indicates if the type of the payment [Expense / Income]
        /// </summary>
        public PaymentTypes PaymentType { get; set; }

        /// <summary>
        /// Indicates the Id of the ScheduledPayment
        /// </summary>
        public string ScheduledPaymentId { get; set; }

        /// <summary>
        /// Indicates the detail of the payment
        /// </summary>
        public PaymentMethodDetail PaymentMethodDetail { get; set; }

        /// <summary>
        /// ObjectId of the user
        /// </summary>
        public string UserId { get; set; }
    }
}
