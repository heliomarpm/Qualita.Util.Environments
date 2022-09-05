using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Qualita.Util.Environments.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseElementCollection<T> : ConfigurationElementCollection where T : BaseElement
    {
        public BaseElementCollection() : base(StringComparer.OrdinalIgnoreCase)
        { }

        protected override ConfigurationElement CreateNewElement()
        {
            return Activator.CreateInstance<T>();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((T)element).Key;
        }

        public T this[int index] => (T)BaseGet(index);

        public new T this[string key] => (T)BaseGet(key);
    }
}
