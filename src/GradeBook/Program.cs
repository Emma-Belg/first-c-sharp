using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 34.1;
            double y = 32.9;
            var result = x + y;
            System.Console.WriteLine(result);

            var numbers = new[] {12.7, 10.3, 6.11, 4.1};
            numbers[0] = 12.7;
            numbers [1] = 10.3;
            numbers[2]= 6.11;

            var result1 = numbers[0]+ numbers[1] + numbers[2];
            result1 += numbers[3];
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
