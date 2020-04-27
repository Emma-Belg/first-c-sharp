namespace GradeBook
{
    public class Statistics
    {
        //Declaring 'fields' to allow the Assert.Equal statements in BookTests.cs to compile
        //Making them public so that it is available
        public double Average;
        public double High;
        public double Low;

        //Trying to fix my bug: "BookTests.cs(42,39): error CS1061: 'Statistics' does not contain a definition for 'low' and no accessible extension method 'low' accepting a first argument of type 'Statistics' could be found (are you missing a using directive or an assembly reference?) [/home/emma/Documents/C#/gradebook/test/GradeBook.Tests/GradeBook.Tests.csproj]"
        //From what I understand a 'using directive' in the BookTests.cs file should fix the issue but apparently not, I read something online about creating a constructor for the class instead of only having fields but that doesn't seem to solve it either. 
       // public Statistics()
        //{
       //     this.High  = double.MinValue;
       //     this.Low = double.MaxValue;
        //}
    }
}