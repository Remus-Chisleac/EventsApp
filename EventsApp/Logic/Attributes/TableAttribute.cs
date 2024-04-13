using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Attributes
{
    public class TableAttribute : Attribute
    {
        string _tableName;
        public string TableName
        {
            get
            {
                return _tableName;
            }
        }

        public TableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
