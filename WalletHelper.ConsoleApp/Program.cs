using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WalletHelper.Business;
using WalletHelper.Entity;

namespace WalletHelper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es");

            Console.WriteLine(Thread.CurrentThread.CurrentCulture);

            var global = new ResourceReacher(Entity.Enums.ResourceTypes.Web);

            var hello = global.GetString("UserName");

            Console.WriteLine(hello);

            Console.ReadLine();
        }
    }
}
