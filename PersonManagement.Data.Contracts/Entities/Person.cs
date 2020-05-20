using System.ComponentModel.DataAnnotations;

namespace PersonManagement.Data.Contracts.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Zipcode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int ColorId { get; set; }

        public virtual Color Color { get; set; }
    }
}