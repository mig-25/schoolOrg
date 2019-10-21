using System;
using System.ComponentModel.DataAnnotations;

namespace School
{
    /*
     IG is failing
     G is passing
     VG is above average
     MVG is the top grade
     */
    //public enum Grades { IG, G, VG, MVG }
    public enum Grades
    {
        [Display(Name = "IG")] IG = 1,

        [Display(Name = "G")] G = 2,

        [Display(Name = "VG")] VG = 3,

        [Display(Name = "MVG")] MVG = 4
    }

    //internal class DisplayAttribute : Attribute
    //{
    //    public string Name;
    //}

    public class Grade
    {
        private Student student;
        public bool IsSucess { get; set; }

        public Grades grade { get; set; }

        /*
         If the grade is IG, then the status of grade is false
         */
        public void GradeStatus()
        {
            if (grade == Grades.IG)
            {
                IsSucess = false;
            }
            else if (grade == Grades.G)
            {
                IsSucess = true;
            }
            else if (grade == Grades.VG)
            {
                IsSucess = true;
            }

            else IsSucess = true;
        }

        /*
         if the previous grade status is true, then success
         */
        public bool isSuccess
        {
            get { return isSuccess; }
            set
            {
                isSuccess = value;
                if (value)
                {
                    student.Status = true;
                }
                else
                {
                    student.Status = false;
                }
            }
        }


        /*
         Sets the grade and uses the Student as a argument
         */
        public Grade(Student obj)
        {
            student = obj;
        }

        public static void AddGrade()
        {
            string grades;
            bool stat;
            //Console.WriteLine("Enter Studnet Name");
            //string name = Console.ReadLine();
            Console.WriteLine("Enter Studnet Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student grade");
            Console.WriteLine("Provide garde");
            Console.WriteLine("1. IG -- Failing ");
            Console.WriteLine("2. G -- Passing");
            Console.WriteLine("3. VG -- Above Average");
            Console.WriteLine("4. MVG -- Top Grade");
            int command = Convert.ToInt32(Console.ReadLine());
            //if (command == "IG")
            //{
            //    grades = Grades.IG;

            //}
            //else if (command == "G")
            //{
            //    grades = Grades.G;
            //}
            //else if (command == "VG")
            //{
            //    grades = Grades.IG;
            //}

            //else
            //{
            //    grades = Grades.MVG;

            //}
            if (command == Convert.ToInt32(Grades.IG))
            {
                grades = "IG";

            }
            else if (command == Convert.ToInt32(Grades.G))
            {
                grades = "G";

            }
            else if (command == Convert.ToInt32(Grades.VG))
            {
                grades = "VG";

            }
            else
            {
                grades = "MVG";

            }
            foreach (Student student in Teacher.Students)
            {
                //if (name == student.StudentName && id == student.StudentId)
                //{
                //    Student student1 = new Student(name, id);

                //}
                if (grades.ToString() == "IG")
                {
                    stat = false;
                }
                else
                {
                    stat = true;
                }
                if (id == student.StudentId)
                {
                    student.Grade = grades;
                    student.Status = stat;
                    Console.WriteLine("Grade assigned sucessfully to: {0}", student.StudentId);
                }
            }
            Console.ReadLine();
            Console.Clear();
            Teacher.teachermenu();
        }
    }
}
