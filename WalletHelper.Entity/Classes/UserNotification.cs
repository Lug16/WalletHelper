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
    public class UserNotification
    {
        public int Id { get; set; }
        public int DayHour { get; set; }
        public int Status { get; set; }
        public int NotificationTypeId { get; set; }
        public int UserId { get; set; }

        public virtual NotificationType NotificationType { get; set; }
        public virtual User User { get; set; }
    }

}
