using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletHelper.Interfaces
{
    public interface IDataContract<T> where T:new()
    {
        IResponseBusiness<T> Insert(T entity);

        IResponseBusiness<T> Update(T entity);

        IResponseBusiness<T> Delete(int id);

        T GetById(int id);

        IEnumerable<T> GetAll();
    }
}
