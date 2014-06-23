using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletHelper.Interfaces
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
}
