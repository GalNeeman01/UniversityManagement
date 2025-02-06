namespace MatrixDigital;

public class Student : Person
{
    // Properties:
    public double GPA { get; set; }

    public List<string> Courses { get; set; } = new List<string>();


    // Constructor:
    public Student(string id, string name, int age, double gpa) : base(id, name, age)
    {
        GPA = gpa;
    }

    // Methods:
    // Add a course to the student's courses list, or return false if it already exists:
    public bool EnrollCourse(string courseName)
    {
        if (Courses.Contains(courseName, StringComparer.OrdinalIgnoreCase)) return false;

        Courses.Add(courseName);

        return true;
    }

    // Return a string representing the student's information:
    public override string GetInfo()
    {
        string coursesString = "";

        Courses.ForEach(c => coursesString += c + ", ");

        return "--------- Student ---------\n" + base.GetInfo() + $"\nGPA: {GPA}\nEnrolled courses: {coursesString}" + "\n---------------------------";
    }
}
