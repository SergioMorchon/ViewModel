using System.Collections.Generic;
using System.Reflection;

namespace ViewModel
{
    public abstract class ComputedBindableBase : BindableBase
    {
        public ComputedBindableBase()
        {
            var properties = new Dictionary<string, HashSet<string>>();
            foreach (var property in this.GetType().GetTypeInfo().DeclaredProperties)
            {
                var computedAttribute = property.GetCustomAttribute<PropertySourceAttribute>();
                if (computedAttribute == null) {
                    continue;
                }

                foreach (var sourceName in computedAttribute.Sources)
                {
                    if (!properties.ContainsKey(sourceName)) {
                        properties[sourceName] = new HashSet<string>();
                    }

                    properties[sourceName].Add(property.Name);
                }
            }

            PropertyChanged += (sender, e) => {
                if (properties.ContainsKey(e.PropertyName)) {
                    foreach (var computedPropertyName in properties[e.PropertyName])
                    {
                        RaisePropertyChanged(computedPropertyName);
                    }
                }
            };
        }
    }
}