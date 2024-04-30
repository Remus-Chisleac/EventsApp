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
        public void GetIdentifier_NoDBConnection_ReturnsCorrectIdentifier()
        {
            // Arrange
            TestStruct testObj = new TestStruct { Id = 0, Name = "Test" };
            Identifier expectedIdentifier = new Identifier(new Dictionary<string, object> { });

            // Act
            Identifier identifier = testObj.GetIdentifier();

            // Assert
            Assert.Equal(expectedIdentifier, identifier);
        }

        [Fact]
        public void GetTableName_NoDBConnection_ReturnsNull()
        {
            // Arrange
            TestStruct testObj = new TestStruct();

            // Act
            string tableName = testObj.GetTableName();

            // Assert
            Assert.Null(tableName);

        }
    }
}
