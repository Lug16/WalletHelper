using System.Linq;
using WalletHelper.DataAccess;

namespace WalletHelper.Business
{
    public class PaymentMethodDetail
    {
        Entity.User _user = new Entity.User();

        public PaymentMethodDetail(Entity.User user)
        {
            this._user = user;
        }

        /// <summary>
        /// Obtiene el detalle del método de pago por defecto de un usuario. Método de pago con ID=0.
        /// </summary>
        /// <returns></returns>
        public Entity.PaymentMethodDetail GetDefault()
        {
            WalletHelperContext ctx = new WalletHelperContext();
            Entity.PaymentMethodDetail ret = null;
            try
            {
                var query = from q in ctx.PaymentMethodDetails
                            where q.User.Id == this._user.Id &&
                            q.PaymentMethodId == 0 // TODO No debe ir este cero quemado
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