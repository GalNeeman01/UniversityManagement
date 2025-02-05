namespace MatrixDigital;

public static class Validations
{
    private static bool IsIdValid(string id)
    {
        return int.TryParse(id, out int numericId) && id.Length == 9;
    }

    private static bool IsIdUnique(string id, University university)
    {
        return !(university.Members.ContainsKey(id));
    }

    public static string GetValidIdFormat(string id)
    {
        if (!IsIdValid(id))
            throw new InvalidFormatException();

        return id;
    }

    public static string GetValidId(string id, University university)
    {
        if (!IsIdValid(id))
            throw new InvalidFormatException();
        if (!IsIdUnique(id, university))
            throw new NotUniqueException();

        return id;
    }

    public static string GetValidName(string name)
    {
        if (name.Length < 3)
            throw new InvalidRangeException(3);

        return name;
    }

    public static string GetValidCourseName(string course)
    {
        if (course.Length < 3)
            throw new InvalidRangeException(3);

        return course;
    }

    public static int GetValidAge(string age)
    {
        int ageNum;

        if (!int.TryParse(age, out ageNum))
            throw new NotANumberException();

        if (ageNum < 18 || ageNum > int.MaxValue)
            throw new InvalidRangeException(18, 120);

        return ageNum;
    }

    public static double GetValidGPA(string gpa)
    {
        double gpaNum;

        if (!double.TryParse(gpa, out gpaNum))
            throw new NotANumberException();

        if (gpaNum < 0 || gpaNum > 4)
            throw new InvalidRangeException(0, 4);

        return gpaNum;
    }

    public static decimal GetValidSalary(string salary)
    {
        decimal salaryNum;

        if (!decimal.TryParse(salary, out salaryNum))
            throw new NotANumberException();

        if (salaryNum < 0 || salaryNum > 60000)
            throw new InvalidRangeException(0, 60000);

        return salaryNum;
    }
}
