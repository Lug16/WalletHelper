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
    // City
    internal class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".City");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.CountryId).HasColumnName("Country_Id").IsRequired().HasMaxLength(2);

            // Foreign keys
            HasRequired(a => a.Country).WithMany(b => b.Cities).HasForeignKey(c => c.CountryId); // FK_City_Country
        }
    }

}
