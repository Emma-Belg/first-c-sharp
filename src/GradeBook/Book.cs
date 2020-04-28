using System;
using System.Collections.Generic;

namespace GradeBook
{

    //Note that this delegate should be in a different file but is here for simplicity
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    //Again, shouldn't be making this class here but to keep it simple I am
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name{
            get;
            set;
        }
    }

    //Defining an interface, the convention is that an interface starts with a capital I.
    public interface IBook
    {
        void AddGrade (double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }


    //creating a new class for abstraction in the Program class
    //Things to think about when creating a new class 
    //  - what is the behaviour of this particular class?
    //  - what is the state that is going to be stored inside of instances of this type/class?
    //  - think of a class as 2 things - the state/data it holds and the behaviour that acts on that state
   
   // if you do not specify an access modifier of a class then it is implicitly treated as 'internal'
    public class InMemoryBook : Book, IBook
    {
         //Variables outside of methods in classes are no longer known as variables but at known as 'Fields'
        private List<double> grades;
        //This is creating a property which is similar to having getter and setter methods
        //note there are no () or ; after the Name as it is not a method but a public property
        //This is a method of encapsulation
        //having this as a public property allows me to have my name as private a protect that class member
            // public string Name
            // {
            //     get {
            //         return name;
            //     }
            //     set {
            //         //value is an implicit variable. 
            //         //Anytime you are in the setter for a property, there will be an implicit variable available and it will be the incoming value tha someone writes into your property 
            //         if(!String.IsNullOrEmpty(value)){
            //             name = value;
            //         }
            //     }
            // }
        private string name;

        //You could write all of the code for the field and property of Name with the same code as below
        //This is what is known as an Auto Property (you don't even need to set the private field of Name1 when using an auto property)
        public string Name1
        {
            get; 
            //setting the setter to private means that people can't simply "book.Name = "example"" to set the name
            //it means that they can only set the name via the contructor (once it is constructed the name cannot be changed)
            private set;
        }
        
        //The readonly keyword gives you a field that can only initialise or write to in the constructor of a class  
        //Readonly is handy because it allows you to
            //write classes where you assign values to fields inside of a constructor and be sure that those fields will never change after that
        readonly string category = "Science";

        //const is even stronger than readonly as it can never be changed or written, even in the constructor
        //it is safe to make constants public as they cannot be overwritten
        //it is common to write a const in all captitals to easily identify constants
        //const fields are treated like static members of the class
            //public const string SUBJECT = "Biology";


        //A constructor in C# must be written as a method with the same name as the Class
        //therefore you cannot access the field through an object(created with the class) but through the classname directly
        //base is a way to reference the base class, when you use base with () you are accessing the constructor of the base class
        //In this situation I can pass the name along from the Book to the base constructor but otherwise I would just have an empty string
        public InMemoryBook(string name) : base(name)
        {
            category = "";
            grades = new List<double>();
            Name = name;
        }

       
        //Use the void Keyword with a method that is not going to return an
        //the override keyword needs to be used here as this class inherits from an abstract clss with an abstract AddGrade method.
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
              grades.Add(grade);  
              if(GradeAdded != null)
              {
                  //The this object reference that you are currently working with is the sender
                  //the EventArgs() is a built in class??
                  //EventArgs() is where you can pass on addtional info about the Event
                  GradeAdded(this, new EventArgs());
              }
            }
            else {
                //There are built in exceptions that you can use in C#
                //a 'throw' exception always looks for a 'catch', if it cannot find one the program will crash, if you don't want that then you need to also use a 'catch'
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        //At the moment this is just a field in Book.cs
        //It means that outside of this class anyone can write book.GradeAdded and it will a delegate that is invoked whenever a grade is added (see GradeAddedDelegate above)
        //Adding the event keyword to the delegate adds some additional restrictions and capabilities that makes this delegate safer to use
        //We will 'invoke' this delegate in AddGrade (remember to think of delegates like fields/variables)
        public override event GradeAddedDelegate GradeAdded;


        //I have asked that this method return the type "Statistics" which is a class that I have created in another file.
        public override Statistics GetStatistics()
        {
            //List is not in the System namespace, to find what namespace a class is in do the following:
            //place your cursor on the class name and press ctrl+. then click on the "using ....." and it will add this as a 'using statement' at the top
            //A List type requires one type argument, this is put in the <>
            //You can use List similarly to an Array but the benefit of a List over an Array is that you can easily add things into a list (you can add things into an Array also, but it is not as easy). 
            //A list is implemented from the start as a dynamically sizable collection that you can easily add to or take from
            //A List is storing data(aka state), in this case, the numbers
                //List<double> grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
                //grades.Add(56.1);
            

            var result = new Statistics();
            //when you instantiate an object in .Net runtime it ensures that all of the fields inside a paricular class hen it is instantiated as an object are set to 'all bits off'.
            //"All bits off" means that all bits in the memory space are zero meaning a number would be set to = to 0.0
            result.Average  = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            

            //The same code as below, but writen as a foreach
            foreach(var grade in grades){
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }

            //Same as the above foreach but gives control over when to stop or ignore something
            //for (var i =0; i < grades.Count; i++){
                //if (grades[i] == 42.1)
                //{
                    //this would skip the loop when the grade[i] == 42.1 but would continue to loop through after this
                    //continue;
                //}
                //result.Low = Math.Min(grades[i], result.Low);
                //result.High = Math.Max(grades[i], result.High);
                //result.Average += grades[i];
            //}

            //You could also write the above foreach as while statement but I prefer the foreach
            //var index = 0;
            //while(index < grades.Count)
            //{
                //result.Low = Math.Min(grades[index], result.Low);
                //result.High = Math.Max(grades[index], result.High);
                //result.Average += grades[index];
                //index++;
            //};
            //Count is to Lists what Length is to Arrays
            result.Average /= grades.Count;

           //Since c# version 7, there are a few additional features with switch statements
            switch(result.Average){
                case var d when d >=90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >=80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >=70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >=60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            //Old switch statments from before c# version 7
            //switch(letter)
            //{
                //NOTE IT IS IMPORTANT TO USE single quotes for a character otherwise c# thinks it is a string. A char is a Struct whereas a String is a reference
                //case 'A':
                    //AddGrade(90);
                //A break statement is important in a switch b/c otherwise the code can 'fall through' and simply coninue doing the code for every case (in this case adding all the grades)
                    //break;
                //case 'B':
                    //AddGrade(80);
                    //break;
                //default:
                    //AddGrade(0);
                    //break;
            //}
        }

            return result; 
        }
    }
}