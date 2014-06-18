// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public byte[] Description { get; set; }
        public decimal Value { get; set; }
        public bool IsScheduled { get; set; }
        public int PaymentType { get; set; }
        public int ScheduledPaymentId { get; set; }
        public int PaymentMethodDetailId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int? HashtagId { get; set; }

        public virtual ICollection<Capture> Captures { get; set; }
        public virtual ICollection<Geolocation> Geolocations { get; set; }
        public virtual ICollection<Recording> Recordings { get; set; }

        public virtual Hashtag Hashtag { get; set; }
        public virtual PaymentMethodDetail PaymentMethodDetail { get; set; }
        public virtual ScheduledPayment ScheduledPayment { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }

        public Payment()
        {
            Date = System.DateTime.Now;
            Value = 0m;
            IsScheduled = false;
            Captures = new List<Capture>();
            Geolocations = new List<Geolocation>();
            Recordings = new List<Recording>();
        }
    }

}
