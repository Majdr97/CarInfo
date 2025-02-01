namespace CarInfo.Services.Entites;

using System.Text.Json.Serialization;

public class CarModelResponse
{
    [JsonPropertyName("Count")]
    public int Count { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("SearchCriteria")]
    public string? SearchCriteria { get; set; }

    [JsonPropertyName("Results")]
    public List<CarModel>? CarModelList { get; set; }
}

public class CarModel
{
    [JsonPropertyName("Make_ID")]
    public int MakeID { get; set; }

    [JsonPropertyName("Make_Name")]
    public string MakeName { get; set; } = null!;

    [JsonPropertyName("Model_ID")]
    public int ModelID { get; set; }

    [JsonPropertyName("Model_Name")]
    public string ModelName { get; set; } = null!;
}