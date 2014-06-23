using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletHelper.Interfaces
{
    public interface IValidate<T>
    {
        IResponseValidate Validate(T entity);
    }
}
