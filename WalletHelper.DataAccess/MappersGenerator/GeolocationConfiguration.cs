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
    internal class GeolocationConfiguration : EntityTypeConfiguration<Geolocation>
    {
        public GeolocationConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Geolocation");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Geo).HasColumnName("Geo").IsRequired();
            Property(x => x.LocationName).HasColumnName("LocationName").IsOptional().HasMaxLength(100);
            Property(x => x.PaymentId).HasColumnName("Payment_Id").IsRequired();

            HasRequired(a => a.Payment).WithMany(b => b.Geolocations).HasForeignKey(c => c.PaymentId);
        }
    }

}
