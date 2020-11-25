using System;
using System.Collections.Generic;

namespace GradeBook
{
    public static class UI
    {
        public static string line = "************************************************";
        public static string space = "*                                              *";
        public static void DisplayHeader()
        {
            Console.WriteLine(line);
            Console.WriteLine(space);
            Console.WriteLine("*                 Grade Book                   *");
            Console.WriteLine(space);
            Console.WriteLine(line);
        }
        public static void RosterTitle()
        {
            Console.WriteLine(space);
            Console.WriteLine("*                   Roster                     *");
            Console.WriteLine(space);
            Console.WriteLine(line);
        }
        public static void DisplayCategoryTitle()
        {
            DisplayHeader();
            Console.WriteLine(space);
            Console.WriteLine("*                  Category                    *");
            Console.WriteLine(space);
            Console.WriteLine(line);
            Console.WriteLine();
        }
        public static void DisplayMenuTitle()
        {
            Console.WriteLine(space);
            Console.WriteLine("*                    Menu                      *");
            Console.WriteLine(space);
            Console.WriteLine(line);
            Console.WriteLine();
        }
        public static void NewStudentTitle()
        {
            DisplayHeader();
            Console.WriteLine(space);
            Console.WriteLine("*                New Student                   *");
            Console.WriteLine(space);
            Console.WriteLine(line);
            Console.WriteLine();
        }
        public static void AddedStudentTitle()
        {
            DisplayHeader();
            Console.WriteLine(space);
            Console.WriteLine("*               Student Added                  *");
            Console.WriteLine(space);
            Console.WriteLine(line);
        }
        public static void DisplayFoundStudentTitle()
        {
            DisplayHeader();
            Console.WriteLine(space);
            Console.WriteLine("*               Student Found                  *");
            Console.WriteLine(space);
            Console.WriteLine(line);
        }
        public static void DisplayStudentNotFoundTitle()
        {
            DisplayHeader();
            Console.WriteLine(space);
            Console.WriteLine("*             Student Not Found                *");
            Console.WriteLine(space);
            Console.WriteLine(line);
        }
        public static void DisplayRemoveStudentTitle()
        {
            DisplayHeader();
            Console.WriteLine(space);
            Console.WriteLine("*              Remove  Student                 *");
            Console.WriteLine(space);
            Console.WriteLine(line);
        }
        public static void RemovedStudentTitle()
        {
            DisplayHeader();
            Console.WriteLine(space);
            Console.WriteLine("*               Student Removed                *");
            Console.WriteLine(space);
            Console.WriteLine(line);
        }
        public static void DisplayStudent(Student student)
        {
                Console.WriteLine(space);
                Console.WriteLine(    $"*   Id      : {student.Id}                                *");
                Console.Write(    $"*   Name    : {student.FirstName} {student.LastName}                        *\n");
                Console.WriteLine($"*   Program : {student.Program}  *");

            if (student.Gpa % 1 == 0)
            {
                Console.WriteLine($"*   GPA     : {student.Gpa}                                *");
            }
            else
            {
                Console.WriteLine($"*   GPA     : {student.Gpa}                              *");
            }
                Console.WriteLine(space);
                Console.WriteLine(line);
        }
        public static void DisplayRoster(LinkedList<Student> Roster)
        {
            DisplayHeader();
            RosterTitle();
            foreach(Student student in Roster)
            {
                DisplayStudent(student);
            }
        }
        public static int GetMethod(List<string> methods, string title)
        {
            if (title == "menu")
            {
                DisplayMenuTitle();
            }
            else if (title == "category")
            {
                DisplayCategoryTitle();
            }
            int choice = 0;
            bool success = false;

            for (int i = 0; i < methods.Count; i++)
            {
                Console.WriteLine($"{i+1}) {methods[i]}");
            }

            Console.WriteLine("0) Exit");

            while (success == false)
            {
                Console.Write("Choice: ");
                success = Int32.TryParse(Console.ReadLine(), out choice);
                if(success == false)
                {
                    Console.WriteLine("Invalid choice.");
                }
            }

            return choice;
        }
        public static void DisplayNewStudent(Student newStudent)
        {
            AddedStudentTitle();
            DisplayStudent(newStudent);
        }
        public static void DisplayRemovedStudent(Student studentToRemove)
        {
            RemovedStudentTitle();
            DisplayStudent(studentToRemove);
        }
        public static void DisplayStudentFound(Student foundStudent)
        {
            Console.Clear();
            DisplayFoundStudentTitle();
            DisplayStudent(foundStudent);
        }
        public static void DisplayStudentNotFound()
        {
            Console.Clear();
            DisplayStudentNotFoundTitle();
        }
    }
}