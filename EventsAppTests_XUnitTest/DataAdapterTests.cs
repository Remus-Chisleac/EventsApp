using Xunit;
using EventsApp.Logic.Adapters;
using EventsApp.Logic.Attributes;
using EventsApp.Logic.Entities;
using System.Collections.Generic;
using System.Reflection;
namespace EventsAppTests_XUnitTest.DataAdapters
{
    public class DataAdapterTests
    {
        [Fact]
        public void DataAdapter_Constructor_SetsKey()
        {
            string key = "testKey";

            var dataAdapter = new DataAdapterStub(key);

            var fieldInfo = typeof(DataAdapterStub).GetField("_key", BindingFlags.NonPublic | BindingFlags.Instance);
            var actualKey = (string)fieldInfo.GetValue(dataAdapter);

            Assert.Equal(key, actualKey);
        }

        private class DataAdapterStub : DataAdapter<int>
        {
            private string _key;

            public DataAdapterStub(string key) : base(key)
            {
                _key = key;
            }

            public override void Add(int item)
            {
                throw new System.NotImplementedException();
            }

            public override void Clear()
            {
                throw new System.NotImplementedException();
            }

            public override bool Contains(Identifier id)
            {
                throw new System.NotImplementedException();
            }

            public override void Connect()
            {
                throw new System.NotImplementedException();
            }

            public override void Delete(Identifier id)
            {
                throw new System.NotImplementedException();
            }

            public override int Get(Identifier id)
            {
                throw new System.NotImplementedException();
            }

            public override System.Collections.Generic.List<int> GetAll()
            {
                throw new System.NotImplementedException();
            }

            public override void Update(Identifier id, int item)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
