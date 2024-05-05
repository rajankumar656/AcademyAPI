using AcademyAPI.Model;

namespace AcademyAPI.Data;


/*public class AppDbInitialize
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            context.Database.EnsureCreated();

            if(!context.Orders.Any())
            {
                context.Orders.AddRange(new List<Order>()
                {
                    new Order()
                    {
                        Email = "raj@cd.com",
                        Name = "Test1",
                    },
                    new Order()
                    {
                        Email = "tab@cd.com",
                        Name = "Test2",
                    },
                    new Order()
                    {
                        Email = "gab@cd.com",
                        Name = "Test3",
                    },
                    new Order()
                    {
                        Email = "jab@cd.com",
                        Name = "Test4",
                    }

                }); 
                context.SaveChanges();
                    
            }
        }

    }
}*/