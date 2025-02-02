using Newtonsoft.Json;

namespace CarInfo.Services.Entites;

public class CarModelResponse
{
    [JsonProperty("Count")]
    public int Count { get; set; }

    [JsonProperty("Message")]
    public string Message { get; set; } = null!;

    [JsonProperty("SearchCriteria")]
    public string? SearchCriteria { get; set; }

    [JsonProperty("Results")]
    public List<CarModel>? CarModelList { get; set; }
}

public class CarModel
{
    [JsonProperty("Make_ID")]
    public int MakeID { get; set; }

    [JsonProperty("Make_Name")]
    public string MakeName { get; set; } = null!;

    [JsonProperty("Model_ID")]
    public int ModelID { get; set; }

    [JsonProperty("Model_Name")]
    public string ModelName { get; set; } = null!;
}