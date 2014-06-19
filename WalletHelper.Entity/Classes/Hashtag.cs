
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity
{
    public class Hashtag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual User User { get; set; }

        public Hashtag()
        {
            Payments = new List<Payment>();
        }
    }

}
