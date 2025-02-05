namespace MatrixDigital;

public class UniversityConsoleMenu
{
    private University _university;

    public UniversityConsoleMenu(University university)
    {
        _university = university;
    }

    // Main menu method:
    public void RunMenu()
    {
        int option = -1;
        while (option != 0)
        {
            // Inner try catch to not break the loop in case of incorrect input:
            try
            {
                ShowMenuOptions();
                if (!int.TryParse(Console.ReadLine(), out option))
                    throw new InvalidFormatException();

                switch (option)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddProfessor();
                        break;
                    case 3:
                        EnrollStudent();
                        break;
                    case 4:
                        AssignSubject();
                        break;
                    case 5:
                        _university.DisplayAllPeople();
                        break;
                    case 0:
                        Console.WriteLine("Exiting menu...");
                        break;
                    default:
                        throw new InvalidRangeException(0, 5);
                }
            }
            catch (Exception e)
            {
                Messages.DisplayErrorMessage(e.Message);
            }
        }
    }

    public void ShowMenuOptions()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("------------- _university Menu: -------------");
        Console.WriteLine("1: Add a student");
        Console.WriteLine("2: Add a professor");
        Console.WriteLine("3: Enroll student in a course");
        Console.WriteLine("4: Assign a subject to a professor");
        Console.WriteLine("5: Display all people");
        Console.WriteLine("0: Exit menu");
        Console.WriteLine("Please enter a number between 1 - 5, or -1 to exit.");
        Console.WriteLine("--------------------------------------------");

        Console.ResetColor();
    }

    public void AddStudent()
    {
        Console.Write("Enter student id: ");
        string id = Validations.GetValidId(Console.ReadLine()!, _university);

        Console.Write("Enter student name: ");
        string name = Validations.GetValidName(Console.ReadLine()!);

        Console.Write("Enter student age: ");
        int age = Validations.GetValidAge(Console.ReadLine()!);

        Console.Write("Enter student GPA: ");
        double GPA = Validations.GetValidGPA(Console.ReadLine()!);

        Messages.DisplaySuccessMessage($"Added student {name} to the _university.");
        _university.AddPerson(new Student(id, name, age, GPA));
    }

    public void AddProfessor()
    {
        Console.Write("Enter professor id: ");
        string id = Validations.GetValidId(Console.ReadLine()!, _university);

        Console.Write("Enter professor name: ");
        string name = Validations.GetValidName(Console.ReadLine()!);

        Console.Write("Enter professor age: ");
        int age = Validations.GetValidAge(Console.ReadLine()!);

        Console.Write("Enter professor salary: ");
        decimal salary = Validations.GetValidSalary(Console.ReadLine()!);

        Messages.DisplaySuccessMessage($"Added professor {name} to the _university.");
        _university.AddPerson(new Professor(id, name, age, salary));
    }

    public void EnrollStudent()
    {
        Console.Write("Enter student ID: ");
        string id = Validations.GetValidIdFormat(Console.ReadLine()!);

        Person? student = _university.FindPerson(id);

        if (student == null)
            throw new Exception("Bitch does not exist");

        if (student is not Student)
            throw new Exception("Bitch is not a student");

        Console.Write("Enter course to enroll in: ");
        string course = Validations.GetValidCourseName(Console.ReadLine()!);

        if (!((Student)student).EnrollCourse(course))
            throw new Exception("Bitch is already enrolled!");

        Messages.DisplaySuccessMessage($"Student successfully enrolled for course {course}");
    }

    public void AssignSubject()
    {
        Console.Write("Enter Professor ID: ");
        string id = Validations.GetValidIdFormat(Console.ReadLine()!);

        Person? professor = _university.FindPerson(id);

        if (professor == null)
            throw new Exception("Bitch does not exist");

        if (professor is not Professor)
            throw new Exception("Bitch does not exist");

        Console.Write("Enter subject to assign: ");
        string course = Console.ReadLine()!;

        if (!((Professor)professor).AssignSubject(course))
            throw new Exception("Bitch already has subject");

        Messages.DisplaySuccessMessage("Successfully assigned subject.");
    }
}
