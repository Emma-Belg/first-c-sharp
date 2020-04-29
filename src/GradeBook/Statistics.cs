using System;

namespace GradeBook
{
    public class Statistics
    {
        //Declaring 'fields' to allow the Assert.Equal statements in BookTests.cs to compile
        //Making them public so that it is available
        public double High;
        public double Low;
        public double Sum;
        public int Count;
        public char Letter
        {
            get
            {
                //Since c# version 7, there are a few additional features with switch statements
                switch(Average){
                    case var d when d >=90.0:
                        return 'A';
                    case var d when d >=80.0:
                        return 'B';
                    case var d when d >=70.0:
                        return 'C';
                    case var d when d >=60.0:
                        return 'D';
                    default:
                        return 'F';
                }

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
        }

        public double Average
        {
            get {
                return Sum / Count;
            }
        }
        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
        public Statistics(){
            //when you instantiate an object in .Net runtime it ensures that all of the fields inside a paricular class hen it is instantiated as an object are set to 'all bits off'.
            //"All bits off" means that all bits in the memory space are zero meaning a number would be set to = to 0.0
            Sum = 0.0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}