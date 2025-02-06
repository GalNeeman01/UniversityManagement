namespace MatrixDigital;

public class Professor : Person
{
    // Properties:
    public decimal Salary { get; set; }

    public List<string> SubjectsTaught { get; set; } = new List<string>();

    // Constructor:
    public Professor(string id, string name, int age, decimal salary) : base(id, name, age)
    {
        Salary = salary;
    }

    // Methods:
    // Add a subject to the professors's subjects list, or return false if it already exists:
    public bool AssignSubject(string subject)
    {
        if (SubjectsTaught.Contains(subject, StringComparer.OrdinalIgnoreCase)) return false;

        SubjectsTaught.Add(subject);

        return true;
    }

    // Return a string representing the professor's information:
    public override string GetInfo()
    {
        string subjectsString = "";

        SubjectsTaught.ForEach(s => subjectsString += s + ", ");

        return "-------- Professor --------\n" + base.GetInfo() + $"\nSalary: {Salary}\nAssigned Subjects: {subjectsString}" + "\n---------------------------";
    }
}
