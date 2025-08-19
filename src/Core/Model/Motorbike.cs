namespace motorbikes_rent_api.Core.Model;

public class Motorbike
{
    public Guid ID { get; set; }
    public int Year { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
}