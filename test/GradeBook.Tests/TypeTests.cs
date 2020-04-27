using System;
using Xunit;
//using GradeBook;

namespace GradeBook.Tests
{
    //The name of the test is important and should follow good abstraction naming conventions
    public class TypeTests
    {
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book1, string name)
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
        Book GetBook(string name)
        {
            return new Book(name);
        }

    }

}
