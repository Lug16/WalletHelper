﻿using WalletHelper.Interfaces;
namespace WalletHelper.Common
{
    /// <summary>
    /// Objeto que contiene una respuesta de la capa de negocio.
    /// </summary>
    /// <typeparam name="T">Entidad a retornar</typeparam>
    public class ResponseBusiness<T> : IResponseBusiness<T> where T : new()
    {

        /// <summary>
        /// Entidad a retornar
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public T Entity
        {
            get;
            set;
        }

        /// <summary>
        /// Indica si se produjo un error
        /// </summary>
        /// <value>
        ///   <c>true</c> si hay error; de lo contrario, <c>false</c>.
        /// </value>
        public bool IsError
        {
            get;
            set;
        }

        /// <summary>
        /// Mensaje del error o vacio si no hay error.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get;
            set;
        }
    }
}
