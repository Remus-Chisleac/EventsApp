using EventsApp.Logic.Attributes;
using EventsApp.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Adapters
{
    public class DataBaseAdapter<T> : DataAdapter<T> where T : struct
    {
        string _connectionString; // CSV file path
        public DataBaseAdapter(string filePath) : base(filePath)
        {
            _connectionString = AppDataInfo.ValidatePath(filePath);
        }

        public override void Add(T item)
        {
            
        }

        public override void Clear()
        {
            
        }

        public override void Connect()
        {
            
        }

        public override bool Contains(Identifier id)
        {
            return true;
        }

        public override void Delete(Identifier id)
        {
            
        }

        public override T Get(Identifier id)
        {
            return new T();
        }

        public override List<T> GetAll()
        {
            return new List<T>();
        }

        public override void Update(Identifier id, T item)
        {
            
        }
    }
}
