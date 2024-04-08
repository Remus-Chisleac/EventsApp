namespace EventsApp.Logic.Attributes
{
    public class PrimaryKeyAttribute : Attribute
    {
        public string Key { get; private set; }

        public PrimaryKeyAttribute(string key)
        {
            Key = key;
        }
    }
}
