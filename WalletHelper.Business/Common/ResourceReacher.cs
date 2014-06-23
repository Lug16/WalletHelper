using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using WalletHelper.Entity.Enums;

namespace WalletHelper.Business
{
    public class ResourceReacher
    {
        private string _selectedBaseName = string.Empty;
        private ResourceManager _resourceManager = null;
        private CultureInfo _culture = Thread.CurrentThread.CurrentCulture;

        public ResourceReacher(ResourceTypes resourceType):this(resourceType,null)
        {
        }

        public ResourceReacher(ResourceTypes resourceType, CultureInfo culture)
        {
            if (culture != null) _culture = culture;
            _selectedBaseName = GetBaseNameString(resourceType);
            _resourceManager = new ResourceManager(_selectedBaseName, typeof(ResourceReacher).Assembly);
        }

        public string GetString(string field)
        {
            return _resourceManager.GetString(field, _culture);
        }

        public static string GetString(string field, CultureInfo info, ResourceTypes baseName)
        {
            var resourceManager = new ResourceManager(GetBaseNameString(baseName), typeof(ResourceReacher).Assembly);
            return resourceManager.GetString(field, info);
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
    }
}
