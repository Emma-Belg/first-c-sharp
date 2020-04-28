using System;
using Xunit;
//using GradeBook;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    //The name of the test is important and should follow good abstraction naming conventions
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod(){
                WriteLogDelegate log;
                
                //You can instantiate delegates like you do classes
                //Note that when you pass the method to your delegate you do not need to add the () after the method name as you do not actually want to run the method
                //You pass the method into the delegate and that basically says "I want my delegate to be initialised with this method"
                log = new WriteLogDelegate(ReturnMessage);

                //The shorthand version of above is:
                //log = ReturnMessage;
                //So when you write the above you are actually invoking the below method.

                //if you get an error "unnassigned local variable 'log'" you simply need to assign the log variable by adding = ReturnMessage to the above "WriteLogDelegate log" line
                log += ReturnMessage;
                log += IncrementCount;

                var result = log("Hello!");
                //If I was just using one method with my delegate I could check it this way
                //Assert.Equal("Hello!", result);
                Assert.Equal(3, count);
        }

        string ReturnMessage(string message){
            count++;
            return message.ToLower();
        }

                string IncrementCount(string message){
            count++;
            return message;
        }


        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            //Value types are immutable 
            //strings are not values but they are also immutable
            string name = "Scott";
            var upper = MakeUpperCase(name);
            
            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
            //This assertion will fail because the method ToUpper does not actually chnge the string but returns a copy of the string converted to uppercase
                //Assert.Equal("SCOTT", name);
            
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);
            //Though u might think that the value would be 42 it is actually 3 because the value of x does not change unless you use "ref" and cause it to pass by reference
            Assert.Equal(3, x);
        }

        private void SetInt(int z)
        {
            z = 42;
        }
        
        private int GetInt()
        {
            return 3;
        }

        [Fact]
        //This is how you would pass a perameter by Reference (using the ref keyword)
        //but in C# programing it is not that common so you won't see the "ref" keyword often, but there are some APIs that demand it
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book1, string name)
        {
            book1.Name = name;
        }

        //Try to name your test as what you are aiming to happen - give them good descriptive names
        [Fact]
        public void GetBookRetunrsDifferentObjects()
        {
            //Aim of test:
            //invoke a method that instantiates a book and then ...
            //prove or disprove that every book that returned from that method is the same object or a differet object
            //(yes the answer is quite obvious but this is about learning unit testing)
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {

            var book1 = GetBook("Book 1");
            //Using reference types, this line of code means that both book1 and book2 have the same reference the same location in the computer's memory or same (memory location) reference value
            var book2 = book1;

            Assert.Same(book1, book2);
            //Another (less nice) way to say the above line
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        //We do not place a [Fact] attribute on this method because this is not a unit test in iteself it is just another method that I call from a unit test somewhere else
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

    }

}
