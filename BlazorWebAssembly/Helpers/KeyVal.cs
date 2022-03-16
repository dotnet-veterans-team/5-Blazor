namespace BlazorWebAssembly.Helpers
{
    public class KeyVal<Key, Val>
    {
        public Key Name { get; set; }
        public Val Value { get; set; }

        public KeyVal() { }

        public KeyVal(Key key, Val val)
        {
            this.Name = key;
            this.Value = val;
        }
    }
}
