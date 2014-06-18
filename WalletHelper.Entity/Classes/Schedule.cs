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
    public partial class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PeriodTypeId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<ScheduledPayment> ScheduledPayments { get; set; }

        public virtual User User { get; set; }

        public Schedule()
        {
            ScheduledPayments = new List<ScheduledPayment>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
