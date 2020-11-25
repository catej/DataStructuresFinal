using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class GradeBookApp
    {
        public string CourseName { get; set; }
        public LinkedList<Student> llRoster { get; set; }
        public List<string> methods = new List<string> () { "Display Roster", "Add Student" , "Remove Student", "Search for Item", "Filter"};
        public List<string> searchableCategories = new List<string> () { "Id", "First Name", "Last Name","GPA", "Program"};
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
                case 5:
                    Console.Clear();
                    FilterList();
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
        private Student? SelectStudent()
        {
            Student selectedStudent = null;
            Console.Write("Enter Student Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                selectedStudent = llRoster.Where(s => s.Id == id).First();
                return selectedStudent;
            }
            catch
            {
                return null;
            }
        }
        private void RemoveStudent()
        {
            UI.DisplayRemoveStudentTitle();
            try
            {
                Student studentToRemove = SelectStudent();
                llRoster.Remove(studentToRemove);
                Console.Clear();
                UI.DisplayRemovedStudent(studentToRemove);
            }
            catch
            {
                UI.DisplayStudentNotFound();
            }
        }
        private void PromptReset()
        {
            Console.Write("press enter for menu...");
            Console.ReadLine();
            Console.Clear();
        }
        private void SearchForStudent()
        {
            List<string> categories = new List<string> () { searchableCategories[0], searchableCategories[1], searchableCategories[2]};

            int category = UI.GetMethod(categories, "category");

            switch (category)
            {
                case 0:
                    break;
                case 1:
                    SearchForId();
                    break;
                case 2:
                    SearchForName("first");
                    break;
                case 3:
                    SearchForName("last");
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
        private void SearchForName(string searchName)
        {
            Student studentToSearch = null;
            string nameToSearch = "";
            try
            {
                nameToSearch = GetName(searchName);
                studentToSearch = llRoster.Where(s => s.FirstName == nameToSearch).First();
                UI.DisplayStudentFound(studentToSearch);
            }
            catch
            {
                UI.DisplayStudentNotFound();
            }
        }
        private void SearchForId()
        {
            Student foundStudent = SelectStudent();
            if(foundStudent != null)
            {
                UI.DisplayStudentFound(foundStudent);
            }
            else
            {
                UI.DisplayStudentNotFound();
            }
        }
        private void FilterList()
        {
            int category = UI.GetMethod(searchableCategories, "category");
            LinkedList<Student> filteredList = null;
            switch (category)
            {
                case 0:
                    break;
                case 1:
                    filteredList = FilterListById();
                    break;
                case 2:
                    filteredList = FilterListBy("first");
                    break;
                case 3:
                    filteredList = FilterListBy("last");
                    break;
                case 4:
                    filteredList = FilterListByGPA();
                    break;
                case 5:
                    filteredList = FilterListBy("program");
                    break;
            }
            if (filteredList.Count > 0)
            {
                Console.Clear();
                UI.DisplayRoster(filteredList);
            }
            else
            {
                Console.Clear();
                UI.DisplayStudentNotFound();
            }
        }
        public LinkedList<Student>? FilterListById()
        {
            int lowId = GetLowIdBound();
            int highId = GetHighIdBound();
            List<Student> filteredList = llRoster.Where(s => s.Id >= lowId && s.Id <= highId).ToList();
            LinkedList<Student> llFilteredList = null;

            if (filteredList != null)
            {
                llFilteredList = new LinkedList<Student>();
                foreach(Student student in filteredList)
                {
                    llFilteredList.AddLast(student);
                }
            }
            return llFilteredList;
            
        }
        public int GetLowIdBound()
        {
            bool isInt = false;
            int id = -1;
            while (!isInt)
            {
                Console.Write("Enter the low bound: ");
                isInt = Int32.TryParse(Console.ReadLine(), out id);
            }
            return id;
        }
        public int GetHighIdBound()
        {
            bool isInt = false;
            int id = -1;
            while (!isInt)
            {
                Console.Write("Enter the high bound: ");
                isInt = Int32.TryParse(Console.ReadLine(), out id);
            }
            return id;
        }
        public LinkedList<Student> FilterListByGPA()
        {
            // Not Finished: TEST
            throw new NotImplementedException();


            double lowGpa = GetLowGPABound();
            double highGpa = GetHighIdBound();
            List<Student> filteredList = llRoster.Where(s => s.Gpa >= lowGpa && s.Gpa <= lowGpa).ToList();
            LinkedList<Student> llFilteredList = null;

            if (filteredList != null)
            {
                llFilteredList = new LinkedList<Student>();
                foreach(Student student in filteredList)
                {
                    llFilteredList.AddLast(student);
                }
            }
            return llFilteredList;
        }
        
        public LinkedList<Student> FilterListBy(string subFilter)
        {
            // Not Finished: TEST
            throw new NotImplementedException();


            Console.Write($"Enter {subFilter} to search for: ");
            string searchString = Console.ReadLine();
            List<Student> filteredList;
            if (subFilter == "first")
            {
                filteredList = llRoster.Where(s => s.FirstName.Contains(searchString)).ToList();
            }
            else
            {
                filteredList = llRoster.Where(s => s.LastName.Contains(searchString)).ToList();
            }
            
            LinkedList<Student> llFilteredList = new LinkedList<Student>();

            if (filteredList != null)
            {
                foreach(Student student in filteredList)
                {
                    llFilteredList.AddLast(student);
                }
            }
            return llFilteredList;
        }
        public double GetLowGPABound()
        {
            bool isInt = false;
            double lowGpa = -1;
            while (!isInt)
            {
                Console.Write("Enter the low bound: ");
                isInt = Double.TryParse(Console.ReadLine(), out lowGpa);
            }
            return lowGpa;
        }
        public double GetHighGPABound()
        {
            bool isInt = false;
            double highGpa = -1;
            while (!isInt)
            {
                Console.Write("Enter the high bound: ");
                isInt = Double.TryParse(Console.ReadLine(), out highGpa);
            }
            return highGpa;
        }
    }
}

// TEST FILTERS
    // ID
    // NAME
    // GPA