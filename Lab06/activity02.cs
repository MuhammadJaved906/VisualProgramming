using System;
using System.Collections.Generic;

class DictionaryDemo
{
    static void Main()
    {
        // Create dictionary
        Dictionary<string, string> countries = new Dictionary<string, string>();

        // Add countries
        countries["USA"] = "Washington DC";
        countries["India"] = "New Delhi";  // Corrected to proper capital
        countries["Pakistan"] = "Islamabad";  // Corrected to proper capital

        // Display all countries
        foreach (var pair in countries)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        // Retrieve capital of specific country
        Console.WriteLine($"\nCapital of Pakistan: {countries["Pakistan"]}");

        // Remove country
        countries.Remove("USA");

        // Display updated countries and capitals
        Console.WriteLine("\nUpdated countries and capitals:");
        foreach (var pair in countries)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}