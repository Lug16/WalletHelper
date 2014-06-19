
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity
{
    public class NotificationType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserNotification> UserNotifications { get; set; }

        public NotificationType()
        {
            UserNotifications = new List<UserNotification>();
        }
    }

}
