using CashControl.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControlSolution.Domain.Entities
{
    public class OptionRole
    {
        [Key]
        public int OptionRoleId { get; set; }

        [Required]
        public int MenuOption_MenuOptionId { get; set; }

        [Required]
        public int Role_RoleId { get; set; }

        public int Order { get; set; }
        [ForeignKey("MenuOption_MenuOptionId")] 
        public MenuOption MenuOption { get; set; }
    }
}
