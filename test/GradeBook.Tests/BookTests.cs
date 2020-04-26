using System;
using Xunit;


namespace GradeBook.Tests
{
    //The name of the test is important and should follow good abstraction naming conventions
    public class BookTests
    {
        //[Fact] is an attribute
        //An attribute is bit of data that is attached to the symbol that follows it
        //[Fact] is attached to Test1
        //Attributes can be thought of as 'decoration' that u put on methods
        [Fact]
        public void Test1()
        {
            //People usually break up unit tests into 3 sections (the tripple A testing sections)
            //1st Section: 
            //Arrange (gather test data and arrange objects and values that you will use)
            
            //If you are referencing classes that are in other folders you can add a ProjectReference.
            //can add a ProjectReference by typing into terminal: dotnet add reference ../../src/GradeBook/GradeBook.csproj 
            //The above will add an ItemGroup into the csproj Tests file
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);


            //2nd Section: 
            //Act (invoke a method to perform a computation. Do something to check actual result)
            var result = book.ShowStatistics();

            //3rd Section:
            //Assert (assert something about the value found in Act)
            Assert.Equal(85.6, result.Average);
        }
    }
}
