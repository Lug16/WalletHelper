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
    // UserReference
    internal class UserReferenceConfiguration : EntityTypeConfiguration<UserReference>
    {
        public UserReferenceConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserReference");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserReferenceId).HasColumnName("UserReference_Id").IsRequired();
            Property(x => x.UserId).HasColumnName("User_Id").IsRequired();
            Property(x => x.Date).HasColumnName("Date").IsRequired();

            // Foreign keys
            HasRequired(a => a.User_UserReferenceId).WithMany(b => b.UserReferences_UserReferenceId).HasForeignKey(c => c.UserReferenceId); // FK_UserReference_ReferencedUser
            HasRequired(a => a.User_UserId).WithMany(b => b.UserReferences_UserId).HasForeignKey(c => c.UserId); // FK_UserReference_SponsorUser
        }
    }

}
