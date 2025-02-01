namespace CarInfo.Models;

public class CarMakeViewModel
{
    public int Count { get; set; }
    public string Message { get; set; } = null!;
    public object? SearchCriteria { get; set; }
    public List<CarMake>? CarMakeList { get; set; }
}

public class CarMake
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}