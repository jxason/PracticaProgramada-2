namespace TareaGrupal.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string first_name { get; set; }

        public required string last_name { get; set; }

        public required string email { get; set; }
        public required string phone { get; set; }
        public required string address { get; set; }
    }
}
