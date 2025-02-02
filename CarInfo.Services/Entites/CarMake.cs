namespace CarInfo.Services.Entites;

using Newtonsoft.Json;

public class CarMakeResponse
{
    [JsonProperty("Count")]
    public int Count { get; set; }

    [JsonProperty("Message")]
    public string Message { get; set; } = null!;

    [JsonProperty("SearchCriteria")]
    public string? SearchCriteria { get; set; }

    [JsonProperty("Results")]
    public List<CarMake>? CarMakeList { get; set; }
}

public class CarMake
{
    [JsonProperty("Make_ID")]
    public int MakeID { get; set; }

    [JsonProperty("Make_Name")]
    public string MakeName { get; set; } = null!;
}