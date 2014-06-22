using System.Globalization;
using System.Resources;
using WalletHelper.Common;
using WalletHelper.Entity.Enums;


namespace WalletHelper.Business
{
    /// <summary>
    /// Clase de negocio base
    /// </summary>
    public abstract class BaseBusiness
    {
        #region Atributos
        ResourceManager _resourceMessages;
        CultureInfo _cul;
        MessageLanguageFrontEnd _language;
        #endregion

        #region Propiedades
        /// <summary>
        /// Indica el idioma en que se devolveran los mensajes
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public MessageLanguageFrontEnd Language 
        { 
            get
            {
                return this._language;
            }
            set
            {
                this._language = value;
                InitLanguage();
            }
        }

        /// <summary>
        /// Recurso para los mensajes
        /// </summary>
        /// <value>
        /// The resource messages.
        /// </value>
        internal ResourceManager ResourceMessages
        {
            get
            {
                return this._resourceMessages;
            }
            set
            {
                this._resourceMessages = value;
            }
        }

        /// <summary>
        /// Cultura asignada.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        internal CultureInfo Culture
        {
            get
            {
                return this._cul;
            }
            set
            {
                this._cul = value;
            }
        }
        #endregion

        #region Constructores
        public BaseBusiness(MessageLanguageFrontEnd language)
        {
            this.Language = language;
        }
        #endregion

        #region Metodos Privados
        /// <summary>
        /// Inicializa idioma
        /// </summary>
        private void InitLanguage()
        {
            this._resourceMessages = new ResourceManager("WalletHelper.Business.Resources.Messages", typeof(BaseBusiness).Assembly);
            this._resourceMessages.IgnoreCase = true;
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
        #endregion
    }
}
