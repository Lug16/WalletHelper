using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Threading;
using WalletHelper.Entity.Enums;

namespace WalletHelper.Business
{
    public class ResourceReacher
    {
        private static string _selectedBaseName = string.Empty;
        private static ResourceManager _resourceManager = null;
        private CultureInfo _culture = Thread.CurrentThread.CurrentCulture;

        public ResourceReacher(ResourceTypes resourceType)
            : this(resourceType, null)
        {
        }

        public ResourceReacher(ResourceTypes resourceType, CultureInfo culture)
        {
            if (culture != null) _culture = culture;
            _selectedBaseName = GetBaseNameString(resourceType);
        }

        public string GetString(string field)
        {
            try
            {
                return ResourceManager.GetString(field, _culture);
            }
            catch (MissingManifestResourceException miss)
            {
                return ResourceManager.GetString(field, new CultureInfo("en"));
            }
        }

        public static string GetString(string field, ResourceTypes baseName)
        {
            try
            {
                return ResourceManager.GetString(field, Thread.CurrentThread.CurrentCulture);
            }
            catch (MissingManifestResourceException miss)
            {
                return ResourceManager.GetString(field, new CultureInfo("en"));
            }
        }

        private static string GetBaseNameString(ResourceTypes resourceType)
        {
            switch (resourceType)
            {
                case ResourceTypes.Web:
                    return "WalletHelper.Business.Resources.Web";
                case ResourceTypes.Messages:
                    return "WalletHelper.Business.Resources.Messages";
            }
            return string.Empty;
        }

        [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(_resourceManager, null))
                {
                    ResourceManager temp = new global::System.Resources.ResourceManager(_selectedBaseName, typeof(ResourceReacher).Assembly);
                    _resourceManager = temp;
                }
                return _resourceManager;
            }
        }
    }
}
