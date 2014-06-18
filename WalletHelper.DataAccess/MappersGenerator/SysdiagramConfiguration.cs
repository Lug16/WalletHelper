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
    // sysdiagrams
    internal class SysdiagramConfiguration : EntityTypeConfiguration<Sysdiagram>
    {
        public SysdiagramConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".sysdiagrams");
            HasKey(x => x.DiagramId);

            Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(128);
            Property(x => x.PrincipalId).HasColumnName("principal_id").IsRequired();
            Property(x => x.DiagramId).HasColumnName("diagram_id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Version).HasColumnName("version").IsOptional();
            Property(x => x.Definition).HasColumnName("definition").IsOptional();
        }
    }

}
