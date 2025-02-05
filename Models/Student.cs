namespace MatrixDigital;

public class Student : Person
{
    public double GPA { get; set; }

    public List<string> Courses { get; set; } = new List<string>();

    public Student(string id, string name, int age, double gpa) : base(id, name, age)
    {
        GPA = gpa;
    }

    public bool EnrollCourse(string courseName)
    {
        if (Courses.Contains(courseName, StringComparer.OrdinalIgnoreCase)) return false;

        Courses.Add(courseName);

        return true;
    }

    public override string GetInfo()
    {
        string coursesString = "";

        Courses.ForEach(c => coursesString += c + ", ");

        return "--------- Student ---------\n" + base.GetInfo() + $"\nGPA: {GPA}\nEnrolled courses: {coursesString}" + "\n---------------------------";
    }
}
