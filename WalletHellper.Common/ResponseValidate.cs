
namespace WalletHelper.Common
{
    /// <summary>
    /// Interfaz para los objetos de respuestas para los metodos de validacion
    /// </summary>
    public interface IResponseValidate
    {
        /// <summary>
        /// Indica si la validacion es correcta
        /// </summary>
        bool IsValid { get; set; }
        /// <summary>
        /// Mensaje con el error por una validacion incorrecta, en caso contrario retorna <c>string.Empty</c>
        /// </summary>
        string Message { get; set; }
    }

    /// <summary>
    /// Objeto de respuesta para los metodos de validacion
    /// </summary>
    public class ResponseValidate:IResponseValidate
    {
        /// <summary>
        /// Indica si la validacion es correcta
        /// </summary>
        public bool IsValid
        {
            get;
            set;
        }

        /// <summary>
        /// Mensaje con el error por una validacion incorrecta, en caso contrario retorna <c>string.Empty</c>
        /// </summary>
        public string Message
        {
            get;
            set;
        }
    }
}
