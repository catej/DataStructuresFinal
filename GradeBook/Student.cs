namespace GradeBook
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Program { get; set; }
        public double Gpa { get; set; }
        public Student(){}
        public Student(int id, string firstName, string lastName, string program, double gpa)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Program = program;
            Gpa = gpa;
        }
    }
}