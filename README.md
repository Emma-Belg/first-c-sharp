# My First c#

I am following an intro to c# "c# Fundamentals" tutorial by Scott Allen on Plurasight.


# My Notes from the tutoral  
## Reference Types vs Value Types

**Reference types**
Any time you use a class provided by .Net you are using what is known as a **reference type**  

`eg var b = new Book("Grades");`  

the line of code will force the .Net run time to create a space in the computer memory for the variable b because we need memory to store values that are inside of variables. By the time that statemente finishes executing there will be a value(lets say 1072) in the letter b. The value represensts a memory location (on the megabytes and gigabytes of your computer), there will be memory cells where the .Net run time allocates space for this new book object that you want to create. The value 1072 is the 'address' or location of where the book is in those gigabytes gigabytes that are available. We talk about the variable b being a reference to where the book is stored on the memory of your computer. Your computer then uses this variable as a reference for where the book is stored in memory.  
Fields are similarly, also references to location in memory.  

**Value types**  
Intergers are special types in .Net, they are what is known as value types because for a value type the runtime still creates space for the variable x. But instead of creating a 'refrence' to an address inside of the variable, it stores the value itself and it is stored directly in that variable.  
`eg var x = 3;`
All numbers are value types; eg. floats, integers, doubles

## Solution files  

Solution files help you to build and run test for the whole project (not just per directory within the project) in one go. It keeps track of the whole project in one go. 

To create a solution file type into terminal:  
`dotnet new sln`  
You can add projects to the solution with commands like:  
`dotnet sln add src/GradeBook/GradeBook.csproj`  


