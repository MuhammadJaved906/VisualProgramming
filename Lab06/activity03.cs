using System;
using System.Collections;

class NonGenericActivity
{
    static void Main()
    {
        // Create an ArrayList
        ArrayList arrayList = new ArrayList();
        arrayList.Add(1);
        arrayList.Add("Hello");
        arrayList.Add("World");
        arrayList.Add(2.5);

        // Display items
        Console.WriteLine("ArrayList items:");
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        // Remove an item
        arrayList.Remove("Hello");

        // Display items after removal
        Console.WriteLine("\nArrayList items after removal:");
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }
        //check if item exists
        Console.WriteLine($"\n Contains 'World': {arrayList.Contains("World")}");

        //create student management system  (evalute and create levels)


    }
}