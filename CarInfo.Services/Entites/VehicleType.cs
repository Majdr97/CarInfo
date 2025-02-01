namespace CarInfo.Services.Entites;

using System.Text.Json.Serialization;

public class VehicleTypeResponse
{
    [JsonPropertyName("Count")]
    public int Count { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("SearchCriteria")]
    public string? SearchCriteria { get; set; }

    [JsonPropertyName("Results")]
    public List<VehicleType>? VehicleTypeList { get; set; }
}

public class VehicleType
{
    public int VehicleTypeId { get; set; }
    public string VehicleTypeName { get; set; } = null!;
}