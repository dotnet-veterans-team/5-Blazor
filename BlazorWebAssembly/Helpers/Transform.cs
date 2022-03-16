using System.Dynamic;

namespace BlazorWebAssembly.Helpers
{
    public static class Transform
    {
        public static object KeyValListToObject(List<KeyVal<string, string>>? keyValsList)
        {
            dynamic item = new ExpandoObject();
            var dItem = item as IDictionary<String, object>;


            foreach (var prop in keyValsList)
            {
                dItem.Add(prop.Name, prop.Value);
            }

            return item;
        }

    }
}
