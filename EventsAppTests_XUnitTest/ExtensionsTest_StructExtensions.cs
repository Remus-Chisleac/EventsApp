using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppTests_XUnitTest
{
    public class ExtensionsTest_StructExtensions
    {

        public struct TestStruct
        { 
            [PrimaryKey]
            public int Id { get; set; }

            [Table("TestTable")]
            public string Name { get; set; }
        }

        [Fact]
        public void GetIdentifier_ReturnsCorrectIdentifier()
        {
            var testObj = new TestStruct { Id = 1, Name = "Test" };
            var expectedIdentifier = new Identifier(new Dictionary<string, object> { { "Id", 1 } });

            var identifier = testObj.GetIdentifier();

            Assert.Equal(expectedIdentifier, identifier);
        }

        [Fact]
        public void GetTableName_ReturnsCorrectTableName()
        {
            var testObj = new TestStruct();

            var tableName = testObj.GetTableName();

            Assert.Equal("TestTable", tableName);
        }
    }
}
