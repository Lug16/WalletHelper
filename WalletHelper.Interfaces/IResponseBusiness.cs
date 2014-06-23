using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletHelper.Interfaces
{
    /// <summary>
    /// Interfaz que ofrece los atributos para las respuestas de la capa de negocio.
    /// </summary>
    /// <typeparam name="T">Entidad a retornar</typeparam>
    public interface IResponseBusiness<T> where T : new()
    {
        /// <summary>
        /// Entidad a retornar
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        T Entity { get; set; }
        /// <summary>
        /// Indica si se produjo un error
        /// </summary>
        /// <value>
        ///   <c>true</c> si hay error; de lo contrario, <c>false</c>.
        /// </value>
        bool IsError { get; set; }
        /// <summary>
        /// Mensaje del error o vacio si no hay error.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }
    }
}
