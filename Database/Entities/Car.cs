using Database.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Car : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [ForeignKey("CarTypeId")]
        virtual public CarType Type { get; set; }
        [ForeignKey("CarMakeId")]
        virtual public CarMake Make { get; set; }
        [ForeignKey("CarColorId")]
        virtual public CarColor Color { get; set; }
        
    }
}
