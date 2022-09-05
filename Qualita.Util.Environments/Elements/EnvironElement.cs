using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;

namespace Qualita.Util.Environments.Elements
{
    [ExcludeFromCodeCoverage]
    public class EnvironElement : Base.BaseElement
    {
        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            base.DeserializeElement(reader, serializeCollectionKey);

            if (!string.IsNullOrEmpty(this.FileName))
            {
                if (!File.Exists(this.FileName))
                    throw new ConfigurationErrorsException($"O arquivo .config complementar, não foi carregado! \nVerifique se o caminho está acessivel \n{this.FileName}");


                using (Stream fs = new FileStream(this.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var settings = new XmlReaderSettings
                    {
                        IgnoreComments = true,
                        IgnoreProcessingInstructions = true,
                        IgnoreWhitespace = true,
                        CloseInput = true,
                        ConformanceLevel = ConformanceLevel.Fragment,
                    };

                    using (var xml = XmlReader.Create(fs, settings))
                    {
                        xml.IsStartElement();
                        if (xml.Name != reader.Name)
                            throw new ConfigurationErrorsException("O arquivo .config complementar, está incorreto!");

                        base.DeserializeElement(xml, serializeCollectionKey);
                    }
                }
            }
        }

        [ConfigurationProperty("name")]
        public string Name
        {
            get => (string)this["name"];
            set => this["name"] = value;
        }

        private string _file;
        [ConfigurationProperty("file")]
        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(_file))
                {
                    _file = (string)this["file"];

                    if (_file.Length > 2 && string.IsNullOrEmpty(Path.GetPathRoot(_file)))
                    {
                        _file = Path.Combine(Directory.GetCurrentDirectory(), _file);
                    }
                }

                return _file;
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public Base.BaseElementCollection<SettingElement> Settings => this[""] as Base.BaseElementCollection<SettingElement>;
    }
}
