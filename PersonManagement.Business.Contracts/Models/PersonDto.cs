namespace PersonManagement.Business.Contracts.Models
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public int ColorId { get; set; }

        public ColorDto Color { get; set; }
    }
}