
namespace WalletHelper.Common
{
    /// <summary>
    /// Configuración para las consultas que requieren paginación
    /// </summary>
    public class PagedQueryObject
    {
        /// <summary>
        /// Página a mostrar.
        /// </summary>
        /// <value>
        /// Número de página a mostrar.
        /// </value>
        public int Page { get; set; }
        /// <summary>
        /// Tamaño de la página.
        /// </summary>
        /// <value>
        /// Cantidad de registros a mostrar en la página.
        /// </value>
        public int Size { get; set; }
    }
}
