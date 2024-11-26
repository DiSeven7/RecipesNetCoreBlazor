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
            var data = StoredData.ContainsKey(key) ? StoredData.First(x => x.Key.Equals(key)).Value : null;
            return data;
        }

        public void RemoveData(string key)
        {
            if (StoredData.ContainsKey(key))
            {
                StoredData.Remove(key);
            }
        }
    }
}
