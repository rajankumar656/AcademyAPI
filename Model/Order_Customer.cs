namespace AcademyAPI.Model
{
    public class Order_Customer
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

       
    }
}
