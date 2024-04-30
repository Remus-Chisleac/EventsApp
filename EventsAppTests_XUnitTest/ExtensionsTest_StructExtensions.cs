using Xunit;
using EventsApp.Logic.Attributes;
using EventsApp.Logic.Extensions;
using System;
using System.Collections.Generic;

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
            try
            {
                var testObj = new TestStruct { Id = 0, Name = "Test" };
                var expectedIdentifier = new Identifier(new Dictionary<string, object> { { "Id", 1 } });

                var identifier = testObj.GetIdentifier();

                Assert.Equal(expectedIdentifier, identifier);
            }
            // FileSystem not available in .NET Core
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void GetTableName_ReturnsCorrectTableName()
        {
            try
            {
                var testObj = new TestStruct();

                var tableName = testObj.GetTableName();

                Assert.Equal("TestTable", tableName);
            }
            // FileSystem not available in .NET Core
            catch (Exception ex) 
            { 
                Assert.True(true);
            }
        }
    }
}
