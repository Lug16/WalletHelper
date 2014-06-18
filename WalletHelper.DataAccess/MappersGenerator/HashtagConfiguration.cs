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
    internal class HashtagConfiguration : EntityTypeConfiguration<Hashtag>
    {
        public HashtagConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Hashtag");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Tag).HasColumnName("Tag").IsRequired().HasMaxLength(50);
            Property(x => x.UserId).HasColumnName("User_Id").IsRequired();

            HasRequired(a => a.User).WithMany(b => b.Hashtags).HasForeignKey(c => c.UserId);
        }
    }

}
