namespace ConfigServices
{
    public class IniFileConfigService : IConfigService
    {
        public string FilePath { get; set; }

        public string GetValue(string name)
        {
            var filePath = File.ReadAllLines(FilePath);

            var kv = filePath
                .Select(e => e.Split('='))
                .Select(strs => new
                {
                    Name = strs[0],
                    Value = strs[1]
                })
                .SingleOrDefault(kv => kv.Name == name);

            if (kv != null)
            {
                return kv.Value;
            }
            else
            {
                return null;
            }
        }
    }
}
