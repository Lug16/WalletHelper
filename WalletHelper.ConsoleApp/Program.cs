using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletHelper.Entity;

namespace WalletHelper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WalletHelper.DataAccess.WalletHelperContext context = new DataAccess.WalletHelperContext();

            var status = new Status() { Description = "Updated" };

            context.Status.Add(status);
            context.SaveChanges();
        }
    }
}
