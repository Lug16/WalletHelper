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
    // Recording
    internal class RecordingConfiguration : EntityTypeConfiguration<Recording>
    {
        public RecordingConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Recording");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Recording_).HasColumnName("Recording").IsRequired();
            Property(x => x.PaymentId).HasColumnName("Payment_Id").IsRequired();

            // Foreign keys
            HasRequired(a => a.Payment).WithMany(b => b.Recordings).HasForeignKey(c => c.PaymentId); // FK_Recording_Payment
        }
    }

}
