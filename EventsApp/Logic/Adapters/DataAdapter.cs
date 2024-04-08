using EventsApp.Logic.Attributes;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Adapters
{
    public abstract class DataAdapter<T> where T : struct
    {
        private string _key;

        public DataAdapter(string key)
        {
            _key = key;
        }

        public abstract void Connect();

        #region CRUD Operations
        public abstract void Clear();
        public abstract void Add(T item);
        public abstract T Get(Identifier id);
        public abstract List<T> GetAll();
        public abstract void Update(Identifier id, T item);
        public abstract void Delete(Identifier id);
        public abstract bool Contains(Identifier id);
        #endregion
    }
}
