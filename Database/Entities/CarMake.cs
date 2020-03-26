using System.Collections.Generic;

namespace PerksDemo.Entities
{
    public class CarMake : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Car> Cars { get; set; }
    }
}