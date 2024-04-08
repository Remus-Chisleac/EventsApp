using EventsApp.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Extensions
{
    public static class StructExtensions
    {
        public static Identifier GetIdentifier(this ValueType obj)
        {
            Dictionary<string, object> primaryKeys = new Dictionary<string, object>();

            foreach (var field in obj.GetType().GetFields())
            {
                var primaryKeyAttribute = field.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).FirstOrDefault() as PrimaryKeyAttribute;

                if (primaryKeyAttribute != null)
                {
                    primaryKeys.Add(primaryKeyAttribute.Key, field.GetValue(obj));
                }
            }

            return new Identifier(primaryKeys);
        }
        
        // This is required since we can't force the generic type to be a struct
        // So, we can't access the GetIdentifiers method from the generic type
        // C# limitation <3
        public static Identifier GetIdentifier<T>(this T obj) where T : struct
        {
            Dictionary<string, object> primaryKeys = new Dictionary<string, object>();

            foreach (var field in obj.GetType().GetFields())
            {
                var primaryKeyAttribute = field.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).FirstOrDefault() as PrimaryKeyAttribute;

                if (primaryKeyAttribute != null)
                {
                    primaryKeys.Add(primaryKeyAttribute.Key, field.GetValue(obj));
                }
            }

            return new Identifier(primaryKeys);
        }
    }
}
