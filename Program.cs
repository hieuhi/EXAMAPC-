using System;
namespace EXAMAPC{
public abstract class Product
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Producer { get; set; }

    public Product(string productId, string name, double price, string producer)
    {
        ProductId = productId;
        Name = name;
        Price = price;
        Producer = producer;
    }

    public abstract double ComputeTax();
}
public class Book : Product
{
    public Book(string productId, string name, double price, string producer)
        : base(productId, name, price, producer)
    {
    }

    public override double ComputeTax()
    {
        return Price * 0.08;
    }
}
public class MobilePhone : Product
{
    public MobilePhone(string productId, string name, double price, string producer)
        : base(productId, name, price, producer)
    {
    }

    public override double ComputeTax()
    {
        return Price * 0.10;
    }
}
public class TaxCalculator
{
    public static void Main()
    {
        Product[] products = new Product[6]
        {
            new Book("B001", "Harry Potter", 29.99, "J. K. Rowling"),
            new Book("B002", "Sherlock Holmes", 49.99, " Arthur Conan Doyle"),
            new Book("B003", "The Da Vinci Code", 39.99, "Dan Brown"),
            new MobilePhone("M001", "GalaxyNote20", 499.99, "SamSung"),
            new MobilePhone("M002", "Iphone15", 999.99, "Iphone"),
            new MobilePhone("M003", "RedmiUltral10", 399.99, "Xiaomi")
        };

        double totalTaxBooks = 0;
        double totalTaxMobiles = 0;

        foreach (Product product in products)
        {
            if (product is Book)
            {
                totalTaxBooks += product.ComputeTax();
            }
            else if (product is MobilePhone)
            {
                totalTaxMobiles += product.ComputeTax();
            }
        }

        Console.WriteLine($"Total tax for books: {totalTaxBooks:C}");
        Console.WriteLine($"Total tax for mobile phones: {totalTaxMobiles:C}");
    }
}
}