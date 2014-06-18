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
    // Schedule
    internal class ScheduleConfiguration : EntityTypeConfiguration<Schedule>
    {
        public ScheduleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Schedule");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Date).HasColumnName("Date").IsRequired();
            Property(x => x.StartDate).HasColumnName("StartDate").IsRequired();
            Property(x => x.EndDate).HasColumnName("EndDate").IsOptional();
            Property(x => x.PeriodTypeId).HasColumnName("PeriodType_Id").IsRequired();
            Property(x => x.UserId).HasColumnName("User_Id").IsRequired();

            // Foreign keys
            HasRequired(a => a.User).WithMany(b => b.Schedules).HasForeignKey(c => c.UserId); // FK_Schedule_User
        }
    }

}
