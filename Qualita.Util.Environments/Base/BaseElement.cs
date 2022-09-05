using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Qualita.Util.Environments.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsKey = true, IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }
    }
}
