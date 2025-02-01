namespace CarInfo.Models;

public class CarModelViewModel
{
    public int Count { get; set; }
    public string Message { get; set; } = null!;
    public string? SearchCriteria { get; set; }
    public List<CarModel>? CarModelList { get; set; }
}

public class CarModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int ModelID { get; set; }
    public string ModelName { get; set; } = null!;
}