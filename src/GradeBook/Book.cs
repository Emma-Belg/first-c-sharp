using System.Collections.Generic;

namespace GradeBook
{

    //creating a new class for abstraction in the Program class

    //Things to think about when creating a new class 
    //  - what is the behaviour of this particular class?
    //  - what is the state that is going to be stored inside of instances of this type/class?
    //  - think of a class as 2 things - the state/data it holds and the behaviour that acts on that state
   
    class Book 
    {
        //A constructor in C# must be written as a method with the same name as the Class
        public Book(){
            grades = new List<double>();
        }
        //Variables outside of methods in classes are no longer known as variables but at known as 'Fields'
        List<double> grades = new List<double>();

        //Use the void Keyword with a method that is not going to return an
        public void AddGrade(double grade)
        {
            grades.Add(grade);

        }


    }
}