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
    public class UserReference
    {
        public int Id { get; set; }
        public int UserReferenceId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public virtual User User_UserId { get; set; }
        public virtual User User_UserReferenceId { get; set; }
    }

}
