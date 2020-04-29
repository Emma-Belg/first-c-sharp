# My First c#

I am following an intro to c# "c# Fundamentals" tutorial by Scott Allen on Plurasight.
The code is absolutely FULL of comments as I tried to note most of the 'important' things he said. This means the code is _very ugly and not nice to read_, but this is a learning exercise for me and I have made a lot of notes for if I ever need to go back to look at something. 

**For further study**  
These are a few topics that Scott Allen recommends to continue studying after this tutorial:  

⋅⋅⋅Generics (Example from the tute: List of double is a generic type parameter)
⋅⋅⋅Asynchronous C#
⋅⋅⋅LINQ (Language Integrated Query)
⋅⋅⋅Programming Paradigms (OOP and functional programming)



# My Notes from the tutorial  

## Types

There are several types in C# including: 
Object types: Object is the base type for everything in .Net. Anything that we work with (from strings to ints to eg 'book'), they all have some relationship to Object Type. When you declare a variable/field/parameter of type object, I can pass _anything_ through that parameter (eg string or char or double or int - anything).
Structures: these are a value type.
Class types: these are a reference type, 
Delegates (which are a reference type).

NOTE: LOOK INTO Struct vs Class vs Delegate

### Class Types  
Classes can have: methods, fields, properties

### Delegate  
Delegates describe what a method will look like. Just like classes they should be written into a separate file.  
A delegate allows you to define a variable that can point to and invoke different methods. But a delegate cannot point to just any method, the method must have a specific shape and structure.  
When you should think about the return type of the method you expect to call, what are the parameter types and number of parameters that you expect to pass when you invoke this method.  

Example: Imagine I want to define a delegate that allows me to log messages. You use a delegate because you need some kind of abstraction/encapsulation between your code and the code that ultimately does the loggin. Delegates provide a way to say which method is to be called when an event is triggered.  

In this example, we use a delegate because it is not 'hard coded' to a method that only writes to the console or to a file. We want the ability to have a variable or a field that have the same structure but perhaps vastly different implementation. For example one method logs to the console while the other logs to a file.  

Method or parameter _names_ do not matter with delegates, only parameter and return _types_ are what matters. The method return type and parameter type must match the delegate.  

Delegates are know as "multi cast delegates" because they can invoke multiple methods. They give you the ability to declare a variable that can be used like a method; it is variable that can be invoked and parameters can be passed along to it.  

**Event Delegates**  
When writing an event delegate, you normally write two parameters. The first parameter that you pass should always be of type object and is the sender (who is sending this event out?), the second parameter is some form of Event argument.


### Reference Types vs Value Types

**Reference types**
Any time you use a class provided by .Net you are using what is known as a **reference type**  

eg: `var b = new Book("Grades");`  

the line of code will force the .Net run time to create a space in the computer memory for the variable b because we need memory to store values that are inside of variables. By the time that statement finishes executing there will be a value(lets say 1072) in the letter b. The value represents a memory location (on the megabytes and gigabytes of your computer), there will be memory cells where the .Net run time allocates space for this new book object that you want to create. The value 1072 is the 'address' or location of where the book is in those gigabytes gigabytes that are available. We talk about the variable b being a reference to where the book is stored on the memory of your computer. Your computer then uses this variable as a reference for where the book is stored in memory.  
Fields are similarly, also references to location in memory.  

**Value types**  
Integers are special types in .Net, they are what is known as value types because for a value type the runtime still creates space for the variable x. But instead of creating a 'reference' to an address inside of the variable, it stores the value itself and it is stored directly in that variable.  
eg: `var x = 3;`
The following are value types: floats, integers, doubles, DateTime, bool, char, Struct
All Structs are value types. You can check the type in Visual Studio Code by putting your cursor on the type and then hitting f12.  

Classes and strings are reference types but String is a special case because it behaves like a value type.

## Pass by Reference vs Pass by Value  

These terms describe how a perameter is given to some method that you are invoking.  
In the C# language, when you pass a parameter to a method you are ALWAYS passing a parameter by value (unless you specify with keywords). What that means is that I am taking the value from (see below example) book1 and I am copying that and placing it into the parameter Book. The value represents a pointer to a memory location so it is a reference to a book object.  

That would be very different in a language where they pass parameters by reference because then they would receive a reference to variable book1 and the parameter could still make changes to the book1 object because the parameter holds a reference to a variable that still holds a reference to my book object. But in a pass by reference scenario, I can even make changes to that book1 variable itself from the other method and that is something that CANNOT happen if I use 'pass by value'.

Example:  
```
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
  ```
        
![alt text](https://github.com/Emma-Belg/first-c-sharp/blob/master/CSharpIsPassByValue.png "CSharpUsesPassByValue")

**Pass By Reference**  
You can do a pass by reference using the "ref" or "out" keywords.  
The difference between "ref" and "out" is that with the "out" keyword the C# compiler assumes that the incoming reference has not been initialized. Therefore it will be an error if you do not assign to an "out" parameter because it expects something assigned to the output parameter, it is like leaving an uninitialized variable around.

![alt text](CSharpCanPassByReference.png "CSharpCanPassByReference")




## Events  

Events are not as commonly in today's frameworks as they used to be. For example the ASP.core (which is for server side and web programming) framework, doesn’t use Events very much.  
Events are popular in forms and desktop programming. Some frameworks that use Events a lot include: Windows presentation foundation, Zamer and forms, Windows forms, ASP.net web forms.  
Events build on top of Delegates.  

You need to think about certain user actions as events (eg clicking a button could be an event). For our GradeBook we can think of 'adding a grade' as a 'significant event'.  


**Event Handling and Raising**  
Event "Raising" is invoking the delegate.  Aka subscribing or listening to the event?
Event "Handling" is adding a method to the event that we want invoked when this class "raises" the event. Handling the event is using the += operator to add a method into the invocation list.  You can handle the event from anywhere that you have an object created. Therefore if you want to handle all of the events then you should add the event handler right after instantiation of the object. 



## Solution files  

Solution files help you to build and run test for the whole project (not just per directory within the project) in one go. It keeps track of the whole project in one go. 

To create a solution file type into terminal:  
`dotnet new sln`  
You can add projects to the solution with commands like:  
`dotnet sln add src/GradeBook/GradeBook.csproj`  


## Garbage Collection in .Net runtime

You do not need to tell the runtime to delete an object to free up memory space as .Net has a garbage collector. It will keep track of all the objects that you have allocated and created and it tracks variables and fields. The .Net runtime knows when there is an object in memory and knows that if it has no variables or fields pointing to or using that object that the object is no longer in use and that it can run a garbage collection to free up memory so that your program doesn't exhaust memory.   

## Properties and Fields  

When you declare a variable inside of the class but outside of the method it is known as a "field".
Creating a property is similar to writing setter and getter methods but no method is needed.
It is a way to encapsulate the field and make it accessible (with a public property) but keep it protected (by keeping the field itself private).  

```
        //note there are no () or ; after the Name as it is not a method but a public property
        public string Name
        {
            get {
                return name;
            }
            set {
                //value is an implicit variable. 
                //Anytime you are in the setter for a property, there will be an implicit variable available and it will be the incoming value tha someone writes into your property 
                if(!String.IsNullOrEmpty(value)){
                    name = value;
                }
            }
        }
        private string name;  
```

**Auto Properties**  
You could write the exact same code as above with an Auto Property. This means that you do not even have to declare the field

```
        public string Name1
        {
            get;
            //setting the setter to private means that people can't simply "book.Name = "example"" to set/overwrite the name
            //it means that they can only set the name via the constructor (once it's constructed, the name cannot be changed)
            private set;
        }  
```
So what is the point? What is the difference between properties and fields?
There are some places in the .Net runtime where properties might behave a bit differently to fields - most of those places revolve around reflection and serialization. Reflection and Serialization both dynamically at run time go in and inspect an object and see what it has available for state.  


## Overloading
To overload a method you simply write the same method with a different signature (a method signature is made up of ONLY the  method name and the parameters the method takes).
So for example I could write both doubles and characters to method AddGrade by doing this:

```
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
              grades.Add(grade);  
            }
        }
        
        public void AddGrade(char Letter)
        {
                switch(letter)
                 {
                    case 'A':
                         AddGrade(90);
                         break;
                    default:
                         AddGrade(0);
                         break;
                 }

         }
        
```


# OOP in C#  

## Inheritance  
Note: every single class that is written in c# inherits from the "object" class, this class has some static methods that can be used (a few examples: ToString(); GetHashCode(); GetType() etc).  

You can have classes inherit from several bases if you have the inheritance 'chain' set up correctly.

Parents/Super and children/sub classes are now known as "base" classes and "derived" classes.  

```
//This is the base class
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

    public abstract class BookBase : NamedObject
    {
        public BookBase(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);
    }

//This is the derived class (it inherits from the base class by writing ": BaseClassName" after the class name
    public class Book : BookBase
    {
        public Book(string name) : base(name)
        {
            category = "";
            grades = new List<double>();
            Name = name;
        }
    ...
```

## Polymorphism  
You can use abstract classes, virtual methods or interfaces to achieve polymorphism.
The key to polymorphism is to override methods that we inherit from our base classes.  
You cannot override any method in C#, you can only override **abstract methods or virtual methods**.  

The below example is using the above abstract method that it inherits from.

```
//the override keyword needs to be used here as this class inherits from an abstract clss with an abstract AddGrade method.
    public class Book : BookBase
    {
    ...
        public override void AddGrade(double grade){
        ....
        
```

**Interfaces**  

The everyday use case for an Interface is to define a pure abstraction.
There is a convention in C# and .Net that any time you write an interface, the name of the interface starts with a capital I.
To implement an interface is the same as inheriting. An example of both inheriting and using 2 interfaces:  
`public void ClassName : BaseClaseName, InterfaceName, InterfaceTwo`  

**Virtual Keyword**  

The virtual keyword on a method is a way of saying "here is a method that is in this class, but a derived class might choose to override the implementation details for this method."  
Properties can also be virtual.

**Abstract Method**
An abstract method is implicitly virtual.  

        
