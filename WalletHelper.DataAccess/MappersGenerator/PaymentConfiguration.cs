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
using WalletHelper.Entity;

namespace WalletHelper.DataAccess
{
    internal class PaymentConfiguration : EntityTypeConfiguration<Payment>
    {
        public PaymentConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Payment");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Date).HasColumnName("Date").IsRequired();
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(300);
            Property(x => x.Value).HasColumnName("Value").IsRequired().HasPrecision(19,4);
            Property(x => x.IsScheduled).HasColumnName("IsScheduled").IsRequired();
            Property(x => x.PaymentType).HasColumnName("PaymentType").IsRequired();
            Property(x => x.ScheduledPaymentId).HasColumnName("ScheduledPayment_Id").IsOptional();
            Property(x => x.PaymentMethodDetailId).HasColumnName("PaymentMethodDetail_Id").IsRequired();
            Property(x => x.UserId).HasColumnName("User_Id").IsRequired();
            Property(x => x.StatusId).HasColumnName("Status_Id").IsRequired();
            Property(x => x.HashtagId).HasColumnName("Hashtag_Id").IsOptional();

            HasOptional(a => a.ScheduledPayment).WithMany(b => b.Payments).HasForeignKey(c => c.ScheduledPaymentId);
            HasRequired(a => a.PaymentMethodDetail).WithMany(b => b.Payments).HasForeignKey(c => c.PaymentMethodDetailId);
            HasRequired(a => a.User).WithMany(b => b.Payments).HasForeignKey(c => c.UserId);
            HasRequired(a => a.Status).WithMany(b => b.Payments).HasForeignKey(c => c.StatusId);
            HasOptional(a => a.Hashtag).WithMany(b => b.Payments).HasForeignKey(c => c.HashtagId);
        }
    }

}
