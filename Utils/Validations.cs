namespace MatrixDigital;

public static class Validations
{
    // Return whether a given string is in valid ID format or not:
    private static bool IsIdValid(string id)
    {
        return int.TryParse(id, out int numericId) && id.Length == 9;
    }

    // Return if an ID already exists in a given University instance:
    private static bool IsIdUnique(string id, University university)
    {
        return !(university.Members.ContainsKey(id));
    }

    // Only return ID if it is in valid foramt:
    public static string GetValidIdFormat(string id)
    {
        if (!IsIdValid(id))
            throw new InvalidFormatException();

        return id;
    }

    // Only return ID if it is unique and in valid format:
    public static string GetValidId(string id, University university)
    {
        if (!IsIdValid(id))
            throw new InvalidFormatException();
        if (!IsIdUnique(id, university))
            throw new NotUniqueException();

        return id;
    }

    // Only return name in valid format:
    public static string GetValidName(string name)
    {
        if (name.Length < 3)
            throw new InvalidRangeException(3);

        return name;
    }

    // Only return course name in valid format:
    public static string GetValidCourseName(string course)
    {
        if (course.Length < 2)
            throw new InvalidRangeException(2);

        return course;
    }

    // Only return age in valid format and range:
    public static int GetValidAge(string age)
    {
        int ageNum;

        if (!int.TryParse(age, out ageNum))
            throw new NotANumberException();

        if (ageNum < 18 || ageNum > int.MaxValue)
            throw new InvalidRangeException(18, 120);

        return ageNum;
    }

    // Only return GPA in valid format and range:
    public static double GetValidGPA(string gpa)
    {
        double gpaNum;

        if (!double.TryParse(gpa, out gpaNum))
            throw new NotANumberException();

        if (gpaNum < 0 || gpaNum > 4)
            throw new InvalidRangeException(0, 4);

        return gpaNum;
    }

    // Only return salary in valid format and range:
    public static decimal GetValidSalary(string salary)
    {
        decimal salaryNum;

        if (!decimal.TryParse(salary, out salaryNum))
            throw new NotANumberException();

        if (salaryNum < 0 || salaryNum > 600000)
            throw new InvalidRangeException(0, 600000);

        return salaryNum;
    }

    // Return a Student from a given University instance, if it exists.
    public static Student GetValidStudentById(string id, University university)
    {
        Person? student = university.FindPerson(id);

        if (student == null)
            throw new ResourceNotFoundException(id);

        if (student is not Student)
            throw new InvalidResourceTypeException("Student");

        return (Student)student;
    }

    // Return a Professor from a given University instance, if it exists.
    public static Professor GetValidProfessorById(string id, University university)
    {
        Person? professor = university.FindPerson(id);

        if (professor == null)
            throw new ResourceNotFoundException(id);

        if (professor is not Professor)
            throw new InvalidResourceTypeException("Professor");

        return (Professor)professor;
    }
}
