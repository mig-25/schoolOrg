using System;
namespace School
{
    public class Student
    {
        //Composiion relation to the Grade class
        public Grade grade;
        public static int accountNumberMarker = 1000;
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        //Status of passing or failing
        public bool Status { get; set; }
        public string Grade { get; set; }

        //public Student(string sn, int sid, bool status)
        //{
        //    StudentName = sn;
        //    StudentId = sid;
        //    Status = status;
        //}
        public Student(string sn, int sid)
        {
            StudentName = sn;
            StudentId = sid;
        }

        /*
         If grade is value is true from the Grade class, the the the student
         passes
         */
        public void GraduateStatus(bool pass)
        {
            if (grade.IsSucess == true)
            {
                Status = true;
            }
            else Status = false;
        }

        public Student()
        {
            grade = new Grade(this);
        }
        public static void showallstudents()
        {
            string stat = "";
            string grd = "";
            if (Teacher.Students.Count == 0)
            {
                Console.WriteLine("NO Students were added by the Teacher.  Teacher creates Students ");
                Console.ReadLine();
                Console.Clear();
                Teacher.teachermenu();
            }
            else
            {
                foreach (Student student in Teacher.Students)
                {
                    if (student.Grade == "" || student.Grade == null)
                    {
                        stat = "-";
                        grd = "-";
                    }
                    else
                    {
                        if (student.Status == true)
                        {
                            stat = "Pass";
                        }
                        else
                        {
                            stat = "Fail";
                        }

                        grd = student.Grade;
                    }
                    Console.WriteLine(" Student Id: {0}, \n StudentName: {1}, \n Grade: {2} \n Status: {3}", student.StudentId, student.StudentName, grd, stat);
                    Console.ReadLine();
                }
                Console.Clear();
                Teacher.teachermenu();
            }
        }
        public static void CreateStudent()
        {
            Console.WriteLine("Enter StudentName");
            string StudentName = Console.ReadLine();
            int StudentId = ++accountNumberMarker;
            Student student = new Student(StudentName, StudentId);
            Teacher.Students.Add(student);
            Console.WriteLine("Student Created Sucessfully: {0}", StudentName);
            Console.ReadLine();
            Console.Clear();
            Teacher.teachermenu();

        }


    }
}
