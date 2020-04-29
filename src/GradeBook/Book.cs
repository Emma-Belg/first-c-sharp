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

        public string Name
        {
            get;
            set;
        }
    }

    //Defining an interface, the convention is that an interface starts with a capital I.
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;
        public const string CATEGORY = "Science";
        
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

           public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
              grades.Add(grade);  
              if(GradeAdded != null)
              {
                 GradeAdded(this, new EventArgs());
              }
            }
            else {
               throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
            {
        
                var result = new Statistics();

                for (var i =0; i < grades.Count; i++){
                    result.Add(grades[i]);
                }
                return result; 
            }
    }
}