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
    public partial class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
