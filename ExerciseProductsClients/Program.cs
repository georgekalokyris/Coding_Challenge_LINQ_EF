using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProductsClients
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase db = new MyDatabase();

            //TotalPricePerClient(db);
            //AllProductsPerClient(db);
            //OrdersAfter2020(db);
            //PurchseOver50(db);

        }

        private static void PurchseOver50(MyDatabase db)
        {
            var clients = db.Orders.GroupBy(x => x.Client).ToList();

            int total = 0;
            foreach (var item in clients)
            {
                Console.WriteLine(item.Key.Name);
                foreach (var x in item)
                {
                    Console.WriteLine("\t\t");
                    total += x.Product.Price;

                }
                if (total > 20)
                {

                    Console.WriteLine("You won a product");


                }

            }
        }

        private static void OrdersAfter2020(MyDatabase db)
        {
            var orders = db.Orders.Where(x => x.OrderDate.Year > 2020).ToList();

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Name: {order.OrderNumber} {order.OrderDate:d}");
            }
        }

        private static void AllProductsPerClient(MyDatabase db)
        {
            var clients = db.Orders.GroupBy(x => x.Client).ToList();

            foreach (var client in clients)
            {
                Console.WriteLine(client.Key.Name);

                foreach (var item in client)
                {
                    Console.WriteLine("\t\t");
                    Console.WriteLine(item.Product.Title);
                }
            }
        }

        private static void TotalPricePerClient(MyDatabase db)
        {
            var orders = db.Orders.ToList();

            var clients = db.Orders.GroupBy(x => x.Client).ToList();

            int total = 0;
            foreach (var item in clients)
            {
                Console.WriteLine(item.Key.Name);
                foreach (var x in item)
                {
                    Console.WriteLine("\t\t");
                    total += x.Product.Price;

                }
                Console.WriteLine(total);
                total = 0;
            }
        }
    }

    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public ICollection<Order> Orders { get; set; }

    }

    public class Order
    {

        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }


        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        [Key, Column(Order = 1)]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }

}
