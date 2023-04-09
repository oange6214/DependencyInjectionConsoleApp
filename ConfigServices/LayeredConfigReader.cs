namespace ConfigServices;
internal class LayeredConfigReader : IConfigReader
{
    private readonly  IEnumerable<IConfigService> _services;

    public LayeredConfigReader(IEnumerable<IConfigService> services)
    {
        _services = services;
    }

    public string GetValue(string name)
    {
        string value = null;

        foreach(var service in _services)
        {
            string newValue = service.GetValue(name);

            if (newValue != null)
            {
                // 最後一個不為 null 的值，就是最終值
                value = newValue;
            }
        }
        return value;
    }
}
