using System;
using System.Collections.Generic;

namespace DemeterLawCodeExample
{
    class Customer
    {
        private string name;
        private List<Order> orders;

        public Customer(string name)
        {
            this.name = name;
            orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        // violating Demeter's law by accessing the name of the products in the order
        public void PrintProductNames()
        {
            foreach (Order order in orders)
            {
                foreach (Product product in order.Products)
                {
                    Console.WriteLine(product.GetName());
                }
            }
        }
    }

    class Order
    {
        private List<Product> products;

        public Order()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> Products
        {
            get { return products; }
        }
    }

    class Product
    {
        private string name;

        public Product(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("John Doe");
            Order order1 = new Order();
            order1.AddProduct(new Product("Product A"));
            order1.AddProduct(new Product("Product B"));
            customer.AddOrder(order1);
            Order order2 = new Order();
            order2.AddProduct(new Product("Product C"));
            customer.AddOrder(order2);
            customer.PrintProductNames();
        }
    }
}
