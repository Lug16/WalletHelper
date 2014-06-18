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
    public partial class NotificationType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserNotification> UserNotifications { get; set; }

        public NotificationType()
        {
            UserNotifications = new List<UserNotification>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
