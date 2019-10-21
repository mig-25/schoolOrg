using System;
using System.Collections.Generic;

namespace School
{
    public class Teacher : Employee

    {
        //Aggregation, A teacher has many students, also create a list of students
        public static List<Student> Students = new List<Student>();

        string GraduateLevel;

        //Inheritance The teacher inherits from its parent, the Employee class
        public Teacher(string gl, string name, int enr) : base(name, enr)
        {
            GraduateLevel = gl;
            Name = name;
            EmployeeNr = enr;
        }

        public Teacher()
        {
        }

        public void CreateCard()
        {
            EntryCard card = new EntryCard();
            card.SetCardNr();
        }

        //A association to card class, takes the EntryCard as argument
        public void checkEntry(string name)
        {
            EntryCard obj = new EntryCard();
            obj.Swipe(name);
        }

        /*
         This is the abstract method implemented from the parent employee class.
         Generate a employee nr, either by some randomizer och start with
         1000 and add 1 for each emaployee
         Then check if there is a employee nr bigger then 0 and print the
         employee nr*/
        public override void checkCredentials()
        {
            Console.WriteLine("Enter Username");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = ReadPassword();
            Name = name;
            if (Name == "admin")
            {
                checkEntry(name);
                //Here the output should be:
                //Valid employee with card nr: 0000 and name "xxxx" used card at DateTime.Now
                //Console.WriteLine("Valid Employee: {0}, Card swipted at: {1}", Name, DateTime.Now);
                Console.Clear();
                Teacher.teachermenu();
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
                Console.ReadLine();
                Console.Clear();
                mainmenu();
            }
        }
        //This method is used for setting the password value to * so that no one can view it.
        public static string ReadPassword()
        {
            string password = "admin";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

        //this method is used as default menu while loading the program 
        public static void mainmenu()
        {
            Employee employee = new Teacher();
            Console.WriteLine("-------------------");
            Console.WriteLine("1: Login");
            //Console.WriteLine("2: Show Students");
            Console.WriteLine("-------------------");
            string command = Console.ReadLine();
            switch (command)
            {
                case "1":
                    employee.checkCredentials();
                    break;
                //case "2":
                //    Student.showallstudents();
                //    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        //this menu i sused for loading the teachers menu for grading the student the student
        //and creating the student
        public static void teachermenu()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("1: Create Student");
            Console.WriteLine("2: Show Students");
            Console.WriteLine("3: Assign grade to Students");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-------------------");
            string command = Console.ReadLine();
            switch (command)
            {
                case "1":
                    Student.CreateStudent();
                    break;
                case "2":
                    Student.showallstudents();
                    break;
                case "3":
                    Grade.AddGrade();
                    break;
                case "4":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

    }
}
