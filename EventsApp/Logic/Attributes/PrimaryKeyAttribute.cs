namespace EventsApp.Logic.Attributes
{
    public class PrimaryKeyAttribute : Attribute
    {
        public string Key { get; private set; } // This might get discarded later on, since we don't really need it

        public PrimaryKeyAttribute(string key)
        {
            Key = key;
        }
    }
}
