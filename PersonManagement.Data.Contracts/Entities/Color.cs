using System.ComponentModel.DataAnnotations;

namespace PersonManagement.Data.Contracts.Entities
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}