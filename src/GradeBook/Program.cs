using System;
using System.Collections.Generic;

//It is important to put your code in a name space otherwise it is in the global name space and this is dangerous b/c it can lead to conflicts
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 34.1;
            double y = 32.9;
            var adding = x + y;
            //System is the namespace that Console lives in.
            //When you use the cw shortcut VSC inserts the namespace as well
            //The System namespace is not required explicitly here as in line one we are 'using' the System Namespace with a 'using statement'
            System.Console.WriteLine(adding);

            //we have created a Book class to abstract the add grade method as knowing the details of this are not important for the program class
            var book = new Book("Emma's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();

            //The :N2 is to say how many decimals I would like in my floating number
            Console.WriteLine($"The lowest grade is: {stats.Low:N2}");
            Console.WriteLine($"The highest grade is: {stats.High:N2}");
            Console.WriteLine($"The average grade is: {stats.Average:N2}");

        }   
    }
}
