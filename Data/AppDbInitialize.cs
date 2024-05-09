using AcademyAPI.Model;

namespace AcademyAPI.Data;


public class AppDbInitialize
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            context.Database.EnsureCreated();

            //Customers
            //if (!context.Customers.Any())
            //{
            //    context.Customers.AddRange(new List<Customer>()
            //    {
            //        new Customer()
            //        {
            //            Name = "Rajan",
            //            Email = "raj@tee.com",
            //            Address = "123 Street",
            //            Phone = 1234567890
            //        },
            //        new Customer()
            //        {
            //            Name = "Shrey",
            //            Email = "shy@tee.com",
            //            Address = "abc Street",
            //            Phone = 1297654544
            //        },
            //        new Customer()
            //        {
            //            Name = "Rish",
            //            Email = "rish@tee.com",
            //            Address = "xyz Street",
            //            Phone = 1234654544
            //        }
            //    });
            //    context.SaveChanges();
            //}
                //Orders
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(new List<Order>()
                {
                    new Order()
                    {
                       Email = "raj@cd.com",
                       //Cust_Id = 1,
                       Amount = 19.12m

                    },
                    new Order()
                    {
                        Email = "tab@cd.com",
                        //Cust_Id = 2,
                        Amount = 70.45m
                    },
                    new Order()
                    {
                        Email = "gab@cd.com",
                        //Cust_Id = 3,
                        Amount = 100.10m

                    }

                });
                context.SaveChanges();
            }

        }
    }
}