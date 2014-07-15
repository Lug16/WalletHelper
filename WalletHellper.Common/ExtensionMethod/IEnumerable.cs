using System.Collections.Generic;
using System.Linq;

namespace WalletHelper.Common.ExtensionMethod
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Realiza la paginación sobre una consulta.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="configPage">Configuración de la paginación.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, PagedQueryObject configPage)
        {
            return source.Skip((configPage.Page - 1) * configPage.Size).Take(configPage.Size);
        }

    }
}
