//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WalletHelper.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentMethodDetail
    {
        public PaymentMethodDetail()
        {
            this.Payment = new HashSet<Payment>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public int PaymentMethod_Id { get; set; }
        public int User_Id { get; set; }
    
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual User User { get; set; }
    }
}
