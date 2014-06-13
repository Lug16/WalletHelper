
namespace WalletHelper.Common
{
    public interface IResponseBusiness<T> where T : new()
    {
        T Entity { get; }
        bool IsError { get; }
        string Message { get; }
    }

    public class ResponseBusiness<T> : IResponseBusiness<T> where T : new()
    {

        public T Entity
        {
            get;
            internal set;
        }

        public bool IsError
        {
            get;
            internal set;
        }

        public string Message
        {
            get;
            internal set;
        }
    }
}
