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
    public class Status
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Status()
        {
            Payments = new List<Payment>();
            Users = new List<User>();
        }
    }

}
