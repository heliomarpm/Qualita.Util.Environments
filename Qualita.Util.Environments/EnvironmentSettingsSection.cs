using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Qualita.Util.Environments
{
    [ExcludeFromCodeCoverage]
    public class EnvironmentSettingsSection : ConfigurationSection
    {

        [ConfigurationProperty("useEnvironKey", IsRequired = true)]
        public string UseEnvironKey
        {
            get => (string)this["useEnvironKey"];
            set => this["useEnvironKey"] = value;
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(Elements.EnvironElement), AddItemName = "environ")]
        public Base.BaseElementCollection<Elements.EnvironElement> Environments
        {
            get => this[""] as Base.BaseElementCollection<Elements.EnvironElement>;
        }
    }
}
