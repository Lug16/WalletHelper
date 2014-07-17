using System;
using WalletHelper.DataAccess;
using WalletHelper.Entity.Enums;

namespace WalletHelper.Business
{
    public abstract class BaseBusiness:IDisposable
    {
        internal ResourceReacher _resourceReacher = new ResourceReacher(ResourceTypes.Messages);
        internal readonly WalletHelperContext _context;
        internal readonly Entity.User _user = new Entity.User();

        public BaseBusiness(Entity.User user)
        {
            this._user = user;
            this._context = new WalletHelperContext();
        }

        internal BaseBusiness(Entity.User user, WalletHelperContext context)
        {
            this._user = user;
            this._context = context;
        }

        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
