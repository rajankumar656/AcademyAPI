using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyAPI.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey("Customer")]
        public int Cust_Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        

    }
}
