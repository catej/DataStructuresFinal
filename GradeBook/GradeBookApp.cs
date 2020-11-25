using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class GradeBookApp
    {
        public string CourseName { get; set; }
        public LinkedList<Student> llRoster { get; set; }
        public List<string> methods = new List<string> () { "Display Roster", "Add Student" , "Remove Student", "Search for Item"};
        public List<string> searchableCategories = new List<string> () { "Id", "First Name", "Last Name"};
        public GradeBookApp(string courseName)
        {
            CourseName = courseName;
            llRoster = new LinkedList<Student>();
        }
        public void SeedRoster()
        {
            Student student1 = new Student( 1, "Jeff", "Cate", "IT Web and Software Development", 3.5);
            Student student2 = new Student( 2, "Anne", "Bach", "IT Web and Software Development", 2.9);
            Student student3 = new Student( 3, "Zach", "Zate", "IT Web and Software Development", 2.0);
            llRoster.AddLast(student1);
            llRoster.AddLast(student2);
            llRoster.AddLast(student3);
        }
        public void Run()
        {
            SeedRoster();
            int choice = -1;
            do{
                UI.DisplayHeader();
                choice = UI.GetMethod(methods, "menu");
                SelectMethod(choice);
            }while(choice != 0);
        }
        public void SelectMethod(int selection)
        {
            switch (selection)
            {
                case 0:
                    break; 
                case 1:
                    Console.Clear();
                    UI.DisplayRoster(llRoster);
                    PromptReset();
                    break; 
                case 2:
                    Console.Clear();
                    BuildStudent();
                    PromptReset();
                    break; 
                case 3:
                    Console.Clear();
                    RemoveStudent();
                    PromptReset();
                    break; 
                case 4:
                    Console.Clear();
                    SearchForStudent();
                    PromptReset();
                    break; 
            }
        }
        private void BuildStudent()
        {
            // bool acceptable = false;
            // bool building = true;
            UI.NewStudentTitle();
            Student newStudent = new Student();

            // while (acceptable == false && building == true){
                Console.Write("First Name: ");
                newStudent.FirstName = Console.ReadLine();

                Console.Write(" Last Name: ");
                newStudent.LastName = Console.ReadLine();

                bool validGPA = false;
                while(validGPA == false)
                {
                    Console.Write("       GPA: ");
                    double gpa;
                    validGPA = Double.TryParse(Console.ReadLine(), out gpa);
                    newStudent.Gpa = gpa;
                }
                Console.Write("Department: ");
                newStudent.Program = Console.ReadLine();
                newStudent.Id = llRoster.Count + 1;
            // }
            AddStudent(newStudent);         
        }
        private void AddStudent(Student studentToAdd)
        {
            llRoster.AddLast(studentToAdd);
            Console.Clear();
            UI.DisplayNewStudent(studentToAdd);
        }
        // convert to get student with overrides
        // convert remove student
        private Student SelectStudent()
        {
            Console.Write("Enter Student Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Student selectedStudent = llRoster.Where(s => s.Id == id).First();
            return selectedStudent;
        }
        private void RemoveStudent()
        {
            UI.DisplayRemoveStudentTitle();
            Student studentToRemove = SelectStudent();
            llRoster.Remove(studentToRemove);
            Console.Clear();
            UI.DisplayRemovedStudent(studentToRemove);
        }
        private void PromptReset()
        {
            Console.Write("press enter for menu...");
            Console.ReadLine();
            Console.Clear();
        }
        private void SearchForStudent()
        {
            int category = UI.GetMethod(searchableCategories, "category");

            switch (category)
            {
                case 0:
                    SelectStudent();
                    break;
                case 1:
                    string fName = GetName("First");
                    SearchForFirst(fName);
                    break;
                case 2:
                    string lName = GetName("Last");
                    SearchForLast(lName);
                    break;
            }
        }
        private string GetName(string name)
        {
            Console.Write($"Enter {name} name to search: ");
            return Console.ReadLine();
        }
        private int GetIdToSearch()
        {
            bool validInt = false;
            int intToSearch = -1;
            while (!validInt)
            {
                Console.Write($"Enter int to search: ");
                validInt = Int32.TryParse(Console.ReadLine(), out intToSearch);
            }
            return intToSearch;
        }
        private void SearchForLast(string lName)
        {
            throw new NotImplementedException();
        }
        private void SearchForFirst(string fName)
        {
            throw new NotImplementedException();
        }
        private void SearchForId(int id)
        {
            throw new NotImplementedException();
        }
    }
}