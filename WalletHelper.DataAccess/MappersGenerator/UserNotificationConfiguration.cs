// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;
using WalletHelper.Entity.Classes;

namespace WalletHelper.DataAccess
{
    // UserNotification
    internal class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserNotification");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DayHour).HasColumnName("DayHour").IsRequired();
            Property(x => x.Status).HasColumnName("Status").IsRequired();
            Property(x => x.NotificationTypeId).HasColumnName("NotificationType_Id").IsRequired();
            Property(x => x.UserId).HasColumnName("User_Id").IsRequired();

            // Foreign keys
            HasRequired(a => a.NotificationType).WithMany(b => b.UserNotifications).HasForeignKey(c => c.NotificationTypeId); // FK_UserNotification_NotificationType
            HasRequired(a => a.User).WithMany(b => b.UserNotifications).HasForeignKey(c => c.UserId); // FK_UserNotification_User
        }
    }

}
