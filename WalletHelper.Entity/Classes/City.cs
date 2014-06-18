// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity.Classes
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual Country Country { get; set; }

        public City()
        {
            Users = new List<User>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
