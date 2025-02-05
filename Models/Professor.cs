namespace MatrixDigital;

public class Professor : Person
{
    public decimal Salary { get; set; }

    public List<string> SubjectsTaught { get; set; } = new List<string>();

    public Professor(string id, string name, int age, decimal salary) : base(id, name, age)
    {
        Salary = salary;
    }

    public bool AssignSubject(string subject)
    {
        if (SubjectsTaught.Contains(subject, StringComparer.OrdinalIgnoreCase)) return false;

        SubjectsTaught.Add(subject);

        return true;
    }

    public override string GetInfo()
    {
        string subjectsString = "";

        SubjectsTaught.ForEach(s => subjectsString += s + ", ");

        return "-------- Professor --------\n" + base.GetInfo() + $"\nSalary: {Salary}\nTaught Subjects: {subjectsString}" + "\n---------------------------";
    }
}
