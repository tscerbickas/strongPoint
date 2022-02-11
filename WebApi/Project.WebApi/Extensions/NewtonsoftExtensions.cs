using Newtonsoft.Json;

namespace Project.WebApi.Extensions;

public static class NewtonsoftExtensions
{
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}
