
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity
{
    public class Recording
    {
        public int Id { get; set; }
        public byte[] Recording_ { get; set; }
        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
    }

}
