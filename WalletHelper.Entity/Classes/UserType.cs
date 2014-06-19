
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHelper.Entity
{
    public class UserType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public UserType()
        {
            Users = new List<User>();
        }
    }

}
