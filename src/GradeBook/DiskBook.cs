using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }
        //public string Name => throw new System.NotImplementedException();

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            //using the 'using' keyword here is not the same as when using it at the top of a file to bring in a namespace
            //It means that the code will run the code inside and then when it is done ...
            //clean up by using a Dispose() or Close() statement (that you don't see)
            //it is like the "try...finally" statement that ensures "dispose" will be called after the code inside the {} has run
            //It is common to wrap objects that work with things like files or sockets and has some kind of underlying resource, with a using statement
            using(var writer = File.AppendText($"{Name}.txt"))
            {                
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null){
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}