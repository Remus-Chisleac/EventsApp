using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Attributes
{
    public struct Identifier
    {
        private Dictionary<string, object> _primaryKeys = new Dictionary<string, object>();

        public Dictionary<string, object> PrimaryKeys
        {
            get
            {
                return _primaryKeys;
            }
        }

        public Identifier(Dictionary<string, object> primaryKeys)
        {
            this._primaryKeys = primaryKeys;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Identifier identifier)
            {
                return this._primaryKeys.SequenceEqual(identifier._primaryKeys);
            }

            return false;
        }
    }
}
