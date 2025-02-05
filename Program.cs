namespace MatrixDigital;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            UniversityConsoleMenu menu = new UniversityConsoleMenu(GetSeededUni());

            menu.RunMenu();
        }
        catch (Exception e)
        {
            Messages.DisplayErrorMessage(e.Message);
        }
    }

    public static University GetSeededUni()
    {
        Student s1 = new Student("111111111", "bart simpson", 23, 3.2);
        s1.EnrollCourse("C#");
        s1.EnrollCourse("Java");
        s1.EnrollCourse("Angular");
        s1.EnrollCourse("React");
        s1.EnrollCourse("PHP");

        Student s2 = new Student("222222222", "lisa simpson", 23, 3.5);
        s2.EnrollCourse("C#");
        s2.EnrollCourse("Angular");

        Student s3 = new Student("333333333", "david levi", 23, 4);
        s3.EnrollCourse("Java");
        s3.EnrollCourse("React");
        s3.EnrollCourse("PHP");

        Student s4 = new Student("444444444", "moishe cohen", 23, 1.9);
        s4.EnrollCourse("Java");
        s4.EnrollCourse("React");

        Professor p1 = new Professor("555555555", "homer simpson", 40, 20000);
        p1.AssignSubject("C#");
        p1.AssignSubject("Angular");

        Professor p2 = new Professor("666666666", "bill gates", 40, 18000);
        p2.AssignSubject("Java");

        Professor p3 = new Professor("777777777", "elon musk", 40, 25000);
        p3.AssignSubject("React");
        p3.AssignSubject("PHP");

        University university = new University();

        university.AddPerson(s1);
        university.AddPerson(s2);
        university.AddPerson(s3);
        university.AddPerson(s4);
        university.AddPerson(p1);
        university.AddPerson(p2);
        university.AddPerson(p3);

        return university;
    }
}
