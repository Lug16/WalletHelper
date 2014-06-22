
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity
{
    public class Geolocation
    {
        public int Id { get; set; }
        public System.Data.Entity.Spatial.DbGeography Geo { get; set; }
        public string LocationName { get; set; }
        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
    }

}
