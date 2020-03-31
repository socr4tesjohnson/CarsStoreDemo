namespace Services.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public CarTypeModel Type { get; set; }
        public CarColorModel Color { get; set; }
        public CarMakeModel Make { get; set; }
    }
}
