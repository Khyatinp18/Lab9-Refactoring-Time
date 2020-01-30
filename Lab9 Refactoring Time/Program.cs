using System;
using System.Collections.Generic;

namespace Lab9_Refactoring_Time
{
    class Program
    {
        static void Main(string[] args)
        {   //This program asks users to selsect the student from the list and gives them option for what they want to know about that pertiular student.
            List<string> studentName = new List<string>
            {
                "Shamita", "Erwin", "Clay"
            };
            List<string> studentFavoriteFood = new List<string>
            {
                "Pad Thai", "Pizza", "Potato Curry"
            };
            List<string> studentFavoriteColor = new List<string>
            {
                "Blue", "Green", "Green"
            };
            List<string> studentHomeTown = new List<string>
            {
                "Hyderabad", "Troy", "Trenton"
            };

            // dispaly the welcome message and list of students
            Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about? (enter a number 0 - 2):");

            DisplayStudentName(studentName);

            //Program will continue asking user if they enter invalid input and also asks them if they want to know about another student 
            bool moreStudent = true;
            while (moreStudent)
            {
                string userChoice = GetUserInput("Enter Selection");
                int index = int.Parse(userChoice);

                Console.Write($"Great selection, What would you like to know about {studentName[index]}? ");

                bool continueStudent = true;
                bool validEntry = true;
                while (continueStudent)
                {
                    userChoice = GetUserInput($"Enter 'hometown', 'favorite food', or 'favorite color':");

                    if (userChoice == "favorite food")
                    {
                        Console.WriteLine($"{studentName[index]} likes {studentFavoriteFood[index]}.");
                    }
                    else if (userChoice == "hometown")
                    {
                        Console.WriteLine($"{studentName[index]} is from {studentHomeTown[index]}.");
                    }
                    else if (userChoice == "favorite color")
                    {
                        Console.WriteLine($"{studentName[index]} likes {studentFavoriteColor[index]}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry, please try again.");
                        validEntry = false;
                    }

                    if (validEntry)
                    {
                        continueStudent = KeepGoing($"Would you like to know more about {studentName[index]}(y/n)?", "n", "y");
                    }               
                }
                moreStudent = KeepGoing($"Would you like to know about another student (y/n)?", "n", "y");
            }

            Console.WriteLine("Thank you for your time, Goodbye!");
            Console.ReadKey();
        }




        //This method will display the selection list to the use
        public static void DisplayStudentName(List<string> name)
        {
            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine($"{i} : {name[i]}");
            }
        }


        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }


        public static bool KeepGoing(string message, string option1, string option2)
        {
            string keepGoing = GetUserInput(message).ToLower();
            if (keepGoing == option1)
            {
                return false;
            }
            else if (keepGoing == option2)
            {
                return true;
            }
            else
            {
                return KeepGoing("Not valid! " + message, option1, option2);
            }
        }
    }
}
