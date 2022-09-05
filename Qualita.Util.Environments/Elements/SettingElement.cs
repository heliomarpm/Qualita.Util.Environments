using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Qualita.Util.Environments.Elements
{
    [ExcludeFromCodeCoverage]
    public class SettingElement : Base.BaseElement
    {
        [ConfigurationProperty("value")]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}
