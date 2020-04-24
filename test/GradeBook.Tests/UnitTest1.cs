using System;
using Xunit;

namespace GradeBook.Tests
{
    public class UnitTest1
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
            var x = 5;
            var y = 2;
            var expected = 7;

            //2nd Section: 
            //Act (invoke a method to perform a computation. Do something to check actual result)
            var actual = x + y;

            //3rd Section:
            //Assert (assert something about the value found in Act)
            Assert.Equal(expected, actual);
        }
    }
}
