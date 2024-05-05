using System.ComponentModel.DataAnnotations;

namespace AcademyAPI.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Cust_Name { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        //Relationship

        public List<Order_Customer> Orders_Customers { get; set; }
    }
}
