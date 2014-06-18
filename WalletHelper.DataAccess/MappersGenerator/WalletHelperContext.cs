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
    public class WalletHelperContext : DbContext
    {
        public IDbSet<Capture> Captures { get; set; } // Capture
        public IDbSet<City> Cities { get; set; } // City
        public IDbSet<Country> Countries { get; set; } // Country
        public IDbSet<Geolocation> Geolocations { get; set; } // Geolocation
        public IDbSet<Hashtag> Hashtags { get; set; } // Hashtag
        public IDbSet<NotificationType> NotificationTypes { get; set; } // NotificationType
        public IDbSet<Payment> Payments { get; set; } // Payment
        public IDbSet<PaymentMethodDetail> PaymentMethodDetails { get; set; } // PaymentMethodDetail
        public IDbSet<Recording> Recordings { get; set; } // Recording
        public IDbSet<RefactorLog> RefactorLogs { get; set; } // __RefactorLog
        public IDbSet<Schedule> Schedules { get; set; } // Schedule
        public IDbSet<ScheduledPayment> ScheduledPayments { get; set; } // ScheduledPayment
        public IDbSet<Status> Status { get; set; } // Status
        public IDbSet<Sysdiagram> Sysdiagrams { get; set; } // sysdiagrams
        public IDbSet<User> Users { get; set; } // User
        public IDbSet<UserNotification> UserNotifications { get; set; } // UserNotification
        public IDbSet<UserReference> UserReferences { get; set; } // UserReference
        public IDbSet<UserType> UserTypes { get; set; } // UserType

        static WalletHelperContext()
        {
            Database.SetInitializer<WalletHelperContext>(null);
        }

        public WalletHelperContext()
            : base("Name=WalletHelper.Database")
        {
        }

        public WalletHelperContext(string connectionString) : base(connectionString)
        {
        }

        public WalletHelperContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CaptureConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new GeolocationConfiguration());
            modelBuilder.Configurations.Add(new HashtagConfiguration());
            modelBuilder.Configurations.Add(new NotificationTypeConfiguration());
            modelBuilder.Configurations.Add(new PaymentConfiguration());
            modelBuilder.Configurations.Add(new PaymentMethodDetailConfiguration());
            modelBuilder.Configurations.Add(new RecordingConfiguration());
            modelBuilder.Configurations.Add(new RefactorLogConfiguration());
            modelBuilder.Configurations.Add(new ScheduleConfiguration());
            modelBuilder.Configurations.Add(new ScheduledPaymentConfiguration());
            modelBuilder.Configurations.Add(new StatusConfiguration());
            modelBuilder.Configurations.Add(new SysdiagramConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserNotificationConfiguration());
            modelBuilder.Configurations.Add(new UserReferenceConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new CaptureConfiguration(schema));
            modelBuilder.Configurations.Add(new CityConfiguration(schema));
            modelBuilder.Configurations.Add(new CountryConfiguration(schema));
            modelBuilder.Configurations.Add(new GeolocationConfiguration(schema));
            modelBuilder.Configurations.Add(new HashtagConfiguration(schema));
            modelBuilder.Configurations.Add(new NotificationTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new PaymentConfiguration(schema));
            modelBuilder.Configurations.Add(new PaymentMethodDetailConfiguration(schema));
            modelBuilder.Configurations.Add(new RecordingConfiguration(schema));
            modelBuilder.Configurations.Add(new RefactorLogConfiguration(schema));
            modelBuilder.Configurations.Add(new ScheduleConfiguration(schema));
            modelBuilder.Configurations.Add(new ScheduledPaymentConfiguration(schema));
            modelBuilder.Configurations.Add(new StatusConfiguration(schema));
            modelBuilder.Configurations.Add(new SysdiagramConfiguration(schema));
            modelBuilder.Configurations.Add(new UserConfiguration(schema));
            modelBuilder.Configurations.Add(new UserNotificationConfiguration(schema));
            modelBuilder.Configurations.Add(new UserReferenceConfiguration(schema));
            modelBuilder.Configurations.Add(new UserTypeConfiguration(schema));
            return modelBuilder;
        }
    }
}
