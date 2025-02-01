namespace CarInfo.Services.Extensions;

using Newtonsoft.Json;

public static class JSONExtensions
{
    public static bool TryParseJson<T>(this string @this, out T result)
    {
        bool success = true;
        var settings = new JsonSerializerSettings
        {
            Error = (sender, args) =>
            {
                success = false;
                args.ErrorContext.Handled = true;
            },
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };
        result = JsonConvert.DeserializeObject<T>(@this, settings);
        return success;
    }
}