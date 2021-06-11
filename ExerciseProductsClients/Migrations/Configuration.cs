namespace ExerciseProductsClients.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExerciseProductsClients.MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ExerciseProductsClients.MyDatabase context)
        {
            Product p1 = new Product() { Title = "Nespresso Pod", Price = 5 };
            Product p2 = new Product() { Title = "Dolce Gusto Pod", Price = 5 };
            Product p3 = new Product() { Title = "Airpods", Price = 100};
            Product p4 = new Product() { Title = "Red Bull", Price = 30 };
            Product p5 = new Product() { Title = "Water", Price = 5 };

            Client c1 = new Client() { Name = "George" };
            Client c2 = new Client() { Name = "Stratos" };
            Client c3 = new Client() { Name = "Antonis" };
            Client c4 = new Client() { Name = "Kostantinos"};
            Client c5 = new Client() { Name = "Hector" };

            Order o1 = new Order() { Client = c1 , Product = p1, OrderDate = new DateTime(2021,6,11), OrderNumber = 4444123};
            Order o2 = new Order() { Client = c2, Product = p2, OrderDate = new DateTime(2020, 6, 11), OrderNumber = 4321 };
            Order o4 = new Order() { Client = c3, Product = p3, OrderDate = new DateTime(2019, 6, 11), OrderNumber = 43421 };
            Order o5 = new Order() { Client = c4, Product = p4, OrderDate = new DateTime(2019, 6, 11), OrderNumber = 451221 };
            Order o6 = new Order() { Client = c5, Product = p5, OrderDate = new DateTime(2019, 6, 11), OrderNumber = 421231231 };

            context.Products.AddOrUpdate(x => x.Title, p1, p2, p3);
            context.Clients.AddOrUpdate(x => x.Name, c1, c2, c3);
            context.Orders.AddOrUpdate(x => x.OrderNumber, o1, o2, o4, o5, o6);

            context.SaveChanges();
        
        }
    }
}
