using System;

namespace WalletHelper.Entity
{
    /// <summary>
    /// This class indicates the detail of a scheduled payment
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Unique ObjectId that identifies the record
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Creation date of the record
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// When the payment starts
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// When the payment ends
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Period of time of the scheduled record
        /// </summary>
        public PeriodType PeriodType { get; set; }

        /// <summary>
        /// ObjectId of the user
        /// </summary>
        public string UserId { get; set; }
    }
}
