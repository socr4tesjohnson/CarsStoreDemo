using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerksDemo.Entities
{
    public class Car: IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public CarType CarType { get; set; }
        public CarMake CarMake { get; set; }
        public CarColor Color { get; set; }
    }
}
