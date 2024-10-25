using System;
using System.Collections.Generic;
using System.Linq;

public class Item
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Cost { get; set; }

    public Item(int id, string title, decimal cost)
    {
        Id = id;
        Title = title;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"{Id}. {Title} - ${Cost}";
    }
}

public class CartEntry
{
    public Item Product { get; set; }
    public int Qty { get; set; }

    public CartEntry(Item product, int qty)
    {
        Product = product;
        Qty = qty;
    }

    public decimal TotalPrice()
    {
        return Product.Cost * Qty;
    }
}

public class Cart
{
    private List<CartEntry> entries;
    private decimal discount = 0.10m;
    private decimal tax = 0.08m;
    private DateTime expiration;

    public Cart()
    {
        entries = new List<CartEntry>();
        expiration = DateTime.Now.AddMinutes(30);
    }

    public void AddItem(Item product, int qty)
    {
        var entry = entries.Find(e => e.Product.Id == product.Id);
        if (entry != null)
        {
            entry.Qty += qty;
        }
        else
        {
            entries.Add(new CartEntry(product, qty));
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{qty}x {product.Title} added.");
        Console.ResetColor();
        Pause();
    }

    public void RemoveItem(int productId, int qty)
    {
        var entry = entries.Find(e => e.Product.Id == productId);
        if (entry != null)
        {
            if (qty >= entry.Qty) entries.Remove(entry);
            else entry.Qty -= qty;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Removed {qty}x {entry.Product.Title}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Item not found.");
        }
        Console.ResetColor();
        Pause();
    }

    public void ShowCart()
    {
        Console.Clear();
        if (entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cart is empty.");
            Console.ResetColor();
            Pause();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n+-------------------------------------------------+");
        Console.WriteLine("|                   Your Cart Items                |");
        Console.WriteLine("+-------------------------------------------------+");
        Console.ResetColor();

        entries.ForEach(e => {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("|-------------------------------------------------|");
            Console.WriteLine($"| {e.Product.Title}");
            Console.WriteLine($"| Qty: {e.Qty}");
            Console.WriteLine($"| Total Price: ${e.TotalPrice()}");
            Console.WriteLine("|-------------------------------------------------|");
            Console.ResetColor();
        });

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("+-------------------------------------------------+");
        Console.WriteLine($"| Subtotal: ${Subtotal()}");
        Console.WriteLine($"| Discount: ${Discount()}");
        Console.WriteLine($"| Tax: ${Tax()}");
        Console.WriteLine($"| Total: ${Total()}");
        Console.WriteLine("+-------------------------------------------------+\n");
        Console.ResetColor();

        Pause();
    }

    public decimal Subtotal() => entries.Sum(e => e.TotalPrice());
    public decimal Discount() => Subtotal() * discount;
    public decimal Tax() => (Subtotal() - Discount()) * tax;
    public decimal Total() => Subtotal() - Discount() + Tax();

    public bool IsExpired() => DateTime.Now > expiration;

    public void CompletePurchase()
    {
        Console.Clear();
        if (IsExpired())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cart expired. Start a new session.");
        }
        else if (entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cart is empty.");
        }
        else
        {
            ShowCart();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for your purchase!");
            entries.Clear();
        }
        Console.ResetColor();
        Pause();
    }

    private void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Display Welcome Message
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("+-------------------------------------------------+");
        Console.WriteLine("|           Welcome to the Grocery Store!         |");
        Console.WriteLine("+-------------------------------------------------+");
        Console.ResetColor();
        Pause();

        var cart = new Cart();

        var catalog = new List<Item>
        {
            new Item(1, "Organic Apples", 3.99m),
            new Item(2, "Whole Grain Bread", 2.49m),
            new Item(3, "Free-Range Eggs", 4.99m),
            new Item(4, "Almond Milk", 3.49m),
            new Item(5, "Fresh Spinach", 2.99m),
            new Item(6, "Greek Yogurt", 1.99m),
            new Item(7, "Chicken Breast", 9.99m),
            new Item(8, "Quinoa", 5.49m),
            new Item(9, "Mixed Nuts", 6.99m),
            new Item(10, "Dark Chocolate", 2.99m),
            new Item(11, "Bananas", 1.29m),
            new Item(12, "Tomatoes", 2.59m),
            new Item(13, "Cheddar Cheese", 4.79m),
            new Item(14, "Olive Oil", 7.99m),
            new Item(15, "Avocados", 1.99m),
            new Item(16, "Brown Rice", 3.79m),
            new Item(17, "Carrots", 1.89m),
            new Item(18, "Bell Peppers", 2.49m),
            new Item(19, "Salmon Fillet", 12.99m),
            new Item(20, "Honey", 4.59m)
        };

        bool active = true;
        while (active)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n [ Menu ]");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. Remove from Cart");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Exit");
            Console.ResetColor();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewProducts(catalog);
                    break;

                case "2":
                    ViewProducts(catalog);
                    AddToCart(cart, catalog);
                    break;

                case "3":
                    RemoveFromCart(cart);
                    break;

                case "4":
                    cart.ShowCart();
                    break;

                case "5":
                    cart.CompletePurchase();
                    break;

                case "6":
                    active = false;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option.");
                    Console.ResetColor();
                    Pause();
                    break;
            }
        }
    }

    static void ViewProducts(List<Item> catalog)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n[ Products ]");
        catalog.ForEach(item => Console.WriteLine(item.ToString()));
        Console.ResetColor();
        Pause();
    }

    static void AddToCart(Cart cart, List<Item> catalog)
    {
        Console.WriteLine("Enter product ID:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var product = catalog.Find(p => p.Id == id);
            if (product != null)
            {
                Console.WriteLine("Enter quantity:");
                if (int.TryParse(Console.ReadLine(), out int qty))
                {
                    if (qty <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantity of product is not valid.");
                    }
                    else
                    {
                        cart.AddItem(product, qty);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid quantity.");
                    Pause();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found.");
                Pause();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid ID.");
            Pause();
        }
        Console.ResetColor();
    }

    static void RemoveFromCart(Cart cart)
    {
        Console.Clear();
        Console.WriteLine("[ Current Cart Items ]");
        cart.ShowCart();

        Console.WriteLine("Enter product ID to remove:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Enter quantity:");
            if (int.TryParse(Console.ReadLine(), out int qty))
            {
                if (qty <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantity of product is not valid.");
                    Pause();
                }
                else
                {
                    cart.RemoveItem(id, qty);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid quantity.");
                Pause();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid ID.");
            Pause();
        }
        Console.ResetColor();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
