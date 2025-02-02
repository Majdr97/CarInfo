namespace CarInfo.Services.Entites;

using Newtonsoft.Json;

public class VehicleTypeResponse
{
    [JsonProperty("Count")]
    public int Count { get; set; }

    [JsonProperty("Message")]
    public string Message { get; set; } = null!;

    [JsonProperty("SearchCriteria")]
    public string? SearchCriteria { get; set; }

    [JsonProperty("Results")]
    public List<VehicleType>? VehicleTypeList { get; set; }
}

public class VehicleType
{
    public int VehicleTypeId { get; set; }
    public string VehicleTypeName { get; set; } = null!;
}