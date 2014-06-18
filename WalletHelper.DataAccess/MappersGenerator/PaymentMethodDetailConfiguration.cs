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
    internal class PaymentMethodDetailConfiguration : EntityTypeConfiguration<PaymentMethodDetail>
    {
        public PaymentMethodDetailConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PaymentMethodDetail");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.ReferenceNumber).HasColumnName("ReferenceNumber").IsOptional().HasMaxLength(100);
            Property(x => x.PaymentMethodId).HasColumnName("PaymentMethod_Id").IsRequired();
            Property(x => x.UserId).HasColumnName("User_Id").IsRequired();

            HasRequired(a => a.User).WithMany(b => b.PaymentMethodDetails).HasForeignKey(c => c.UserId);
        }
    }

}
