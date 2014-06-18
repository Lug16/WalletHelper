using System.Globalization;
using System.Resources;
using WalletHelper.Common;


namespace WalletHelper.Business
{
    /// <summary>
    /// Clase de negocio base
    /// </summary>
    public abstract class BaseBusiness
    {
        ResourceManager _res_man; 
        CultureInfo _cul; 

        /// <summary>
        /// Indica el idioma en que se devolveran los mensajes
        /// </summary>
        MessageLanguageFrontEnd Language { get; set; }

        public BaseBusiness()
        {

        }

        public BaseBusiness(MessageLanguageFrontEnd language)
        {
            this.Language = language;

            //Inicializa idioma
            switch (this.Language)
            {
                case MessageLanguageFrontEnd.English:
                    this._cul = CultureInfo.CreateSpecificCulture("en");
                    break;
                case MessageLanguageFrontEnd.Spanish:
                    this._cul = CultureInfo.CreateSpecificCulture("es");
                    break;
                default:
                    break;
            }
        }
    }
}
