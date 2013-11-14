using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletHelper.Entity
{
    /// <summary>
    /// This class handles the Detail of any Payment
    /// </summary>
    public class PaymentMethodDetail
    {
        /// <summary>
        /// Unique ObjectId that identifies the record
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the payment method exam: MyCheck
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Any number to reference de payment
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        public string UserId { get; set; }
    }
}
