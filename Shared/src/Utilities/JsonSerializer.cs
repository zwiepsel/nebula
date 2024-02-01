using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Nebula.Shared.Utilities;

public static class JsonSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.Preserve
    };

    public static string Serialize<TValue>(TValue value)
    {
        return System.Text.Json.JsonSerializer.Serialize(value, Options);
    }

    public static Task SerializeAsync<TValue>(Stream utf8Json, TValue value, CancellationToken cancellationToken = default)
    {
        return System.Text.Json.JsonSerializer.SerializeAsync(utf8Json, value, Options, cancellationToken);
    }

    public static TValue Deserialize<TValue>(string json)
    {
        return System.Text.Json.JsonSerializer.Deserialize<TValue>(json, Options)!;
    }

    public static ValueTask<TValue> DeserializeAsync<TValue>(Stream utf8Json, CancellationToken cancellationToken = default)
    {
        return System.Text.Json.JsonSerializer.DeserializeAsync<TValue>(utf8Json, Options, cancellationToken)!;
    }
}