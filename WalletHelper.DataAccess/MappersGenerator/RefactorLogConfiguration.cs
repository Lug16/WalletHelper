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
    internal class RefactorLogConfiguration : EntityTypeConfiguration<RefactorLog>
    {
        public RefactorLogConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".__RefactorLog");
            HasKey(x => x.OperationKey);

            Property(x => x.OperationKey).HasColumnName("OperationKey").IsRequired();
        }
    }

}
