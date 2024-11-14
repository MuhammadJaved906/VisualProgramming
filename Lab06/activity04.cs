//create student management system  (evalute and create levels)

class sms
{

    static void Main()
    {
        Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();

        //add students and their grades


        students["Ali"] = new List<int> { 85, 90, 88 };
        students["Hassan"] = new List<int> { 70, 65, 75 };
        students["Aslam"] = new List<int> { 95, 92, 94 };
        students["Shoaib"] = new List<int> { 10, 5, 0 };//low performing student 

        //create and display AVERAGE

        Console.WriteLine("Students Averages: ");
        foreach (var student in students)
        {

            double average = student.Value.Average();
            Console.WriteLine($"{student.Key}:{average:F2}");




        }


        //find highest and lowest


        var topStudent = students.OrderByDescending(s => s.Value.Average()).First();
        var lowStudent = students.OrderBy(s => s.Value.Average()).First();

        Console.WriteLine($"\nTop Performer: {topStudent.Key} with average of {topStudent.Value.Average():F2}");

        Console.WriteLine($"\nLow Performer: {lowStudent.Key} with average of {lowStudent.Value.Average():F2}");


        //remove students with low grades

        var failingstudent = students.Where(s => s.Value.Average() < 10).Select(s => s.Key).ToList();

        foreach (var student in failingstudent)
        {


            students.Remove(student);



        }

        //display remaining students

        Console.WriteLine("\n remaining students: ");

        foreach (var student in students)
        {

            Console.WriteLine(student.Key);
        }




    }
}