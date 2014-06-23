using System.Linq;
using WalletHelper.DataAccess;

namespace WalletHelper.Business
{
    public class Status
    {
        /// <summary>
        /// Obtiene el estado por defecto. Estado con ID=0.
        /// </summary>
        /// <returns><c>Entity.Status</c></returns>
        public Entity.Status GetDefault()
        {
            WalletHelperContext ctx = new WalletHelperContext();
            Entity.Status ret = null;
            try
            {
                var query = from q in ctx.Status
                            where q.Id == 0 // TODO No debe ir este cero quemado
                            select q;
                ret = query.FirstOrDefault();
            }
            finally
            {
                ctx.Dispose();
            }
            return ret;
        }
    }
}
