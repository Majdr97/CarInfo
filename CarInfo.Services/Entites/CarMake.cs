namespace CarInfo.Services.Entites;

using System.Text.Json.Serialization;

public class CarMakeResponse
{
    [JsonPropertyName("Count")]
    public int Count { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("SearchCriteria")]
    public string? SearchCriteria { get; set; }

    [JsonPropertyName("Results")]
    public List<CarMake>? CarMakeList { get; set; }
}

public class CarMake
{
    [JsonPropertyName("Make_ID")]
    public int MakeID { get; set; }

    [JsonPropertyName("Make_Name")]
    public string MakeName { get; set; } = null!;
}