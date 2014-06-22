using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletHelper.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }

        public override string UserName
        {
            get
            {
                return base.UserName;
            }
            set
            {
                base.UserName = value;
            }
        }

        public override string Email
        {
            get
            {
                return base.Email;
            }
            set
            {
                base.Email = value;
            }
        }
    }

    public class AuthorizationContext : IdentityDbContext<ApplicationUser>
    {
        public AuthorizationContext()
            : base("WalletHelper.Authorization.Database")
        {

        }
    }

}
