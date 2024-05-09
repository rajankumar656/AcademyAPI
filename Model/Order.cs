using System.ComponentModel.DataAnnotations;

namespace AcademyAPI.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string Email { get; set; }

        //[Required]
        //public int Cust_Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

       // public Customer Customer { get; set; }

    }
}
