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
    internal class ScheduledPaymentConfiguration : EntityTypeConfiguration<ScheduledPayment>
    {
        public ScheduledPaymentConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ScheduledPayment");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(140);
            Property(x => x.Value).HasColumnName("Value").IsOptional().HasPrecision(19,4);
            Property(x => x.PaymentType).HasColumnName("PaymentType").IsRequired();
            Property(x => x.ScheduleId).HasColumnName("Schedule_Id").IsRequired();

            HasRequired(a => a.Schedule).WithMany(b => b.ScheduledPayments).HasForeignKey(c => c.ScheduleId);
        }
    }

}
