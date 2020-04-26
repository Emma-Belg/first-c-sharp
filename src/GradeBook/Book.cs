using System;
using System.Collections.Generic;

namespace GradeBook
{

    //creating a new class for abstraction in the Program class

    //Things to think about when creating a new class 
    //  - what is the behaviour of this particular class?
    //  - what is the state that is going to be stored inside of instances of this type/class?
    //  - think of a class as 2 things - the state/data it holds and the behaviour that acts on that state
   
   // if you do not specify an access modifier of a class then it is implicitly treated as 'internal'
    public class Book 
    {
         //Variables outside of methods in classes are no longer known as variables but at known as 'Fields'
        private List<double> grades = new List<double>();
        private string name;

        //A constructor in C# must be written as a method with the same name as the Class
        public Book(string name){
            this.name = name;
            grades = new List<double>();
        }
       
        //Use the void Keyword with a method that is not going to return an
        public void AddGrade(double grade)
        {
            grades.Add(grade);

        }

        //I have asked that this method return the type "Statistics" which is a class that I have created in another file.

        public Statistics GetStatistics()
        {
            //List is not in the System namespace, to find what namespace a class is in do the following:
            //place your cursor on the class name and press ctrl+. then click on the "using ....." and it will add this as a 'using statement' at the top
            //A List type requires one type argument, this is put in the <>
            //You can use List similarly to an Array but the benefit of a List over an Array is that you can easily add things into a list (you can add things into an Array also, but it is not as easy). 
            //A list is implemented from the start as a dynamically sizable collection that you can easily add to or take from
            //A List is storing data(aka state), in this case, the numbers
            List<double> grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            grades.Add(56.1);
            

            var result = new Statistics();
            //when you instantiate an object in .Net runtime it ensures that all of the fields inside a paricular class hen it is instantiated as an object are set to 'all bits off'.
            //"All bits off" means that all bits in the memory space are zero meaning a number would be set to = to 0.0
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach(var grade in grades){
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            //Count is to Lists what Length is to Arrays
            result.Average /= grades.Count;

            return result; 
        }
    }
}