// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastSessionDate { get; set; }
        public int LastDeviceUsedId { get; set; }
        public int CityId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }

        public virtual ICollection<Hashtag> Hashtags { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PaymentMethodDetail> PaymentMethodDetails { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<UserNotification> UserNotifications { get; set; }
        public virtual ICollection<UserReference> UserReferences_UserId { get; set; }
        public virtual ICollection<UserReference> UserReferences_UserReferenceId { get; set; }

        public virtual City City { get; set; }
        public virtual Status Status { get; set; }
        public virtual UserType UserType { get; set; }

        public User()
        {
            Hashtags = new List<Hashtag>();
            Payments = new List<Payment>();
            PaymentMethodDetails = new List<PaymentMethodDetail>();
            Schedules = new List<Schedule>();
            UserNotifications = new List<UserNotification>();
            UserReferences_UserId = new List<UserReference>();
            UserReferences_UserReferenceId = new List<UserReference>();
        }
    }

}
