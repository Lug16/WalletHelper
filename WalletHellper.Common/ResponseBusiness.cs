
namespace WalletHelper.Common
{
    public interface IResponseBusiness<T> where T : new()
    {
        T Entity { get; set; }
        bool IsError { get; set; }
        string Message { get; set; }
    }

    public class ResponseBusiness<T> : IResponseBusiness<T> where T : new()
    {

        public T Entity
        {
            get;
            set;
        }

        public bool IsError
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}
