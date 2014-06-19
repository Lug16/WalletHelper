
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity
{
    public class ScheduledPayment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal? Value { get; set; }
        public int PaymentType { get; set; }
        public int ScheduleId { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual Schedule Schedule { get; set; }

        public ScheduledPayment()
        {
            Value = 0m;
            Payments = new List<Payment>();
        }
    }

}
