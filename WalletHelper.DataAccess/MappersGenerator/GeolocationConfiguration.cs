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
    // Geolocation
    internal class GeolocationConfiguration : EntityTypeConfiguration<Geolocation>
    {
        public GeolocationConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Geolocation");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Latitude).HasColumnName("Latitude").IsRequired().HasPrecision(4,4);
            Property(x => x.Longitude).HasColumnName("Longitude").IsRequired().HasPrecision(4,4);
            Property(x => x.LocationName).HasColumnName("LocationName").IsOptional().HasMaxLength(100);
            Property(x => x.PaymentId).HasColumnName("Payment_Id").IsRequired();

            // Foreign keys
            HasRequired(a => a.Payment).WithMany(b => b.Geolocations).HasForeignKey(c => c.PaymentId); // FK_Geolocation_Payment
        }
    }

}
