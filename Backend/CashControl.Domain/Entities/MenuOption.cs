using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControlSolution.Domain.Entities
{
    public class MenuOption
    {
        [Key]
        public int MenuOptionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Label { get; set; }

        [MaxLength(50)]
        public string? Icon { get; set; }

        [MaxLength(150)]
        public string? Route { get; set; }
    }
}
