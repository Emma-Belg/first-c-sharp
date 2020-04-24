using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 34.1;
            double y = 32.9;
            var result = x + y;
            //System is the namespace that Console lives in.
            //When you use the cw shortcut VSC inserts the namespace as well
            //The System namespace is not required explicitly here as in line one we are 'using' the System Namespace with a 'using statement'
            System.Console.WriteLine(result);

            var numbers = new[] {12.7, 10.3, 6.11, 4.1};
            //List is not in the System namespace, to find what namespace a class is in do the following:
            //place your cursor on the class name and press ctrl+. then click on the "using ....." and it will add this as a 'using statement' at the top
            //A List type requires one type argument, this is put in the <>
            //You can use List similarly to an Array but the benefit of a List over an Array is that you can easily add things into a list (you can add things into an Array also, but it is not as easy). 
            //A list is implemented from the start as a dynamically sizable collection that you can easily add to or take from
            List<double> grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            grades.Add(56.1);
        

            var result1 = 0.0;
            foreach(var number in numbers){
                result1 += number;
            }
            Console.WriteLine(result1);


            if (args.Length >0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            }
            else {
                Console.WriteLine("Hello!");
            }
        }   
    }
}
