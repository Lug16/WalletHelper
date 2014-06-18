// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity.Classes
{
    public partial class ScheduledPayment
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
