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
    // User
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".User");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AspNetUserId).HasColumnName("AspNetUser_Id").IsRequired().HasMaxLength(128);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
            Property(x => x.Surname).HasColumnName("Surname").IsRequired().HasMaxLength(50);
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(70);
            Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();
            Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            Property(x => x.LastSessionDate).HasColumnName("LastSessionDate").IsOptional();
            Property(x => x.LastDeviceUsedId).HasColumnName("LastDeviceUsed_Id").IsRequired();
            Property(x => x.CityId).HasColumnName("City_Id").IsRequired();
            Property(x => x.StatusId).HasColumnName("Status_Id").IsRequired();
            Property(x => x.TypeId).HasColumnName("Type_Id").IsRequired();

            // Foreign keys
            HasRequired(a => a.City).WithMany(b => b.Users).HasForeignKey(c => c.CityId); // FK_User_City
            HasRequired(a => a.Status).WithMany(b => b.Users).HasForeignKey(c => c.StatusId); // FK_User_Status
            HasRequired(a => a.UserType).WithMany(b => b.Users).HasForeignKey(c => c.TypeId); // FK_User_UserType
        }
    }

}
