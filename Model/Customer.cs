using System.ComponentModel.DataAnnotations;

namespace AcademyAPI.Model
{
    public class Customer
    {
        [Key]
        public int Cust_Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Required]
        public string Phone { get; set; }

        public List<Order> Orders { get; set; }
    }
}
