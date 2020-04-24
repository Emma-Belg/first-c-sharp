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

            var book = new Book();
            book.AddGrade(89.1);

            //List is not in the System namespace, to find what namespace a class is in do the following:
            //place your cursor on the class name and press ctrl+. then click on the "using ....." and it will add this as a 'using statement' at the top
            //A List type requires one type argument, this is put in the <>
            //You can use List similarly to an Array but the benefit of a List over an Array is that you can easily add things into a list (you can add things into an Array also, but it is not as easy). 
            //A list is implemented from the start as a dynamically sizable collection that you can easily add to or take from
            //A List is storing data(aka state), in this case, the numbers
            List<double> grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            grades.Add(56.1);
            

            var result = 0.0;
            foreach(var number in grades){
                result += number;
            }
            //Count is to Lists what Length is to Arrays
            result /= grades.Count;
            //The :N2 is to say how many decimals I would like in my floating number
            Console.WriteLine($"The average grade is: {result:N2}");

        }   
    }
}
