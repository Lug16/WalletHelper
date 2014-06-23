using System.Globalization;
using System.Resources;
using WalletHelper.Entity;
using WalletHelper.Entity.Enums;

namespace WalletHelper.Business
{
    public interface IBaseBusiness
    {
        /// <summary>
        /// Indica el idioma en que se devolveran los mensajes.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        MessageLanguageFrontEnd Language { get; set; }
        /// <summary>
        /// Recurso para los mensajes.
        /// </summary>
        /// <value>
        /// The resource messages.
        /// </value>
        ResourceManager ResourceMessages { get; set; }
        /// <summary>
        /// Cultura asignada.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        CultureInfo Culture { get; set; }
        /// <summary>
        /// Usuario por el cual se filtran los datos.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        User User { get; set; }
    }
}
