using System.Linq;
using WalletHelper.DataAccess;

namespace WalletHelper.Business
{
    public class Status:BaseBusiness
    {
        internal Status(Entity.User user, WalletHelperContext context)
            : base(user, context) { }

        /// <summary>
        /// Obtiene el estado por defecto. Estado con ID=0.
        /// </summary>
        /// <returns><c>Entity.Status</c></returns>
        public Entity.Status GetDefault()
        {
            Entity.Status ret = null;
            var query = from q in _context.Status
                        where q.Id == 0 // TODO No debe ir este cero quemado
                        select q;
            ret = query.FirstOrDefault();
            return ret;
        }
    }
}
