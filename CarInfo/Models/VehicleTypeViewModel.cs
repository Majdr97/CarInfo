namespace CarInfo.Models;

public class VehicleTypeViewModel
{
    public int Count { get; set; }
    public string Message { get; set; } = null!;
    public string? SearchCriteria { get; set; }
    public List<VehicleType>? VehicleTypeList { get; set; }
}

public class VehicleType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}