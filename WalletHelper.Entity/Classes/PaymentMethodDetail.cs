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
    public partial class PaymentMethodDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public int PaymentMethodId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual User User { get; set; }

        public PaymentMethodDetail()
        {
            Payments = new List<Payment>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
