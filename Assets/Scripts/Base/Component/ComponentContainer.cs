using System.Collections.Generic;

namespace Base.Component
{
    public class ComponentContainer
    {
        private readonly Dictionary<string, object> _components;

        public ComponentContainer()
        {
            _components = new Dictionary<string, object>();
        }

        public void AddComponent(string componentKey, object component)
        {
            _components.Add(componentKey, component);
        }

        public object GetComponent(string componentKey)
        {
            if (!_components.ContainsKey(componentKey))
                return null;

            return _components[componentKey];
        }
    }
}