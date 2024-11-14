class genericlistactivity
{
    static void Main()
    {

        //create list of integers
        List<int> numbers = new List<int>();

        //add integers to list
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);
        numbers.Add(5);
        numbers.Add(6);

        Console.WriteLine("original list: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        //sort list
        numbers.Sort();
        Console.WriteLine("sorted list: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        numbers.Remove(41);
        Console.WriteLine(" list after removal: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }



    }

}