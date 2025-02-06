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

    // Print options for actions:
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

    // Accept validated user input and add a student:
    public void AddStudent()
    {
        Console.Write("Enter student id (9 digits): ");
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

    // Accept validated user input and add a professor:
    public void AddProfessor()
    {
        Console.Write("Enter professor id (9 digits): ");
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

    // Accept validated user input and enroll a student for a course:
    public void EnrollStudent()
    {
        Console.Write("Enter student id (9 digits): ");
        string id = Validations.GetValidIdFormat(Console.ReadLine()!);

        Student student = Validations.GetValidStudentById(id, _university);

        Console.Write("Enter course to enroll for: ");
        string course = Validations.GetValidCourseName(Console.ReadLine()!);

        if (!student.EnrollCourse(course)) // Returns false if student is already enrolled for this course
            Messages.DisplayErrorMessage($"This student is already enrolled for course '{course}'");
        else
            Messages.DisplaySuccessMessage($"Student successfully enrolled for course {course}");
    }

    // Accept validated user input and assign a subject to a professor:
    public void AssignSubject()
    {
        Console.Write("Enter Professor id (9 digits): ");
        string id = Validations.GetValidIdFormat(Console.ReadLine()!);

        Professor professor = Validations.GetValidProfessorById(id, _university);

        Console.Write("Enter subject to assign: ");
        string subject = Console.ReadLine()!;

        if (!professor.AssignSubject(subject)) // Returns false if subject is already assigned to this professor
            Messages.DisplayErrorMessage($"This professor is already assigned for subject '{subject}'");
        else
            Messages.DisplaySuccessMessage("Successfully assigned subject.");
    }
}
