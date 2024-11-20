namespace WebAPIBlazor.Components.Extensions
{
    public class ObjectTransporter
    {
        public Dictionary<string, object> StoredData = new();

        public void AddData(string key, object target)
        {
            if (StoredData.ContainsKey(key))
            {
                StoredData.Remove(key);
                StoredData.Add(key, target);
            }
            else
            {
                StoredData.Add(key, target);
            }
        }

        public object RetrieveData(string key)
        {
            var data = StoredData.First(x => x.Key.Equals(key)).Value;
            return data;
        }
    }
}
