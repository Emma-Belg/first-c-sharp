using System;
using System.Collections.Generic;

//It is important to put your code in a name space otherwise it is in the global name space and this is dangerous b/c it can lead to conflicts
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //double x = 34.1;
            //double y = 32.9;
            //var adding = x + y;
            //System is the namespace that Console lives in.
            //When you use the cw shortcut VSC inserts the namespace as well
            //The System namespace is not required explicitly here as in line one we are 'using' the System Namespace with a 'using statement'
            //System.Console.WriteLine(adding);

            //we have created a Book class to abstract the add grade method as knowing the details of this are not important for the program class
            var book = new InMemoryBook("Emma's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            //The :N2 is to say how many decimals I would like in my floating number
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The average grade is: {stats.Average:N2}");
            Console.WriteLine($"The letter grade is: {stats.Letter}.");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    //This parses the input (which will be seen as a string), into a double
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                //This is to catch the 'throw' exception written into AddGrade in Book.cs
                //You could just write Exception to catch any kind of exception but it is better to catch the type of exception(s) you are expecting or 'know you can deal with'
                //eg ArgumentException, FormatException, 
                catch (ArgumentException excep)
                {
                    Console.WriteLine(excep.Message);
                }
                catch (FormatException excep)
                {
                    Console.WriteLine(excep.Message);
                }
                //Finally block is useful if there is a piece of code that you ALWAYS want to execute WHEN:
                //the code inside of your try block executes SUCCESSFULLY
                //BUT something ADD throws an exception
                //The finally block can be useful when you need to make sure that you: eg. close a file or network socket even when there has been an exception
                finally
                {
                    //in this example the finally code would mean that book.AddGrade(grade) is skipped due to the throw
                    //BUT the below Console.WriteLine() is executed
                    Console.WriteLine("**");
                }
            }
        }

        //This code can be completely decoupled from the book itself 
        static void OnGradeAdded(object sender, EventArgs e){
                Console.WriteLine("A grade was added");
        }
    }
}
