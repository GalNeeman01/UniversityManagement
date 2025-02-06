namespace MatrixDigital;

public class University : IGraduatable
{
    // Fields & properties:
    private double _gradGPA = 3;

    public Dictionary<string, Person> Members { get; set; } = new Dictionary<string, Person>();

    // Constructor:
    public University() { }

    // Methods:
    // Save a new person to the university instance, or return false if it already exists:
    public bool AddPerson(Person person)
    {
        if (Members.ContainsKey(person.Id)) return false;

        Members.Add(person.Id, person);

        return true;
    }

    // Return a person found by it's ID, or null if ot doesn't exist:
    public Person? FindPerson(string id)
    {
        if (Members.TryGetValue(id, out Person? person))
            return person;

        return null;
    }

    // Print all the members of the university:
    public void DisplayAllPeople()
    {
        foreach (KeyValuePair<string, Person> member in Members)
            Console.WriteLine(member.Value.GetInfo());
    }

    // Remove all members of type Student that have a GPA higher than the gradGPA defined above. 
    public void Graduate()
    {
        foreach (KeyValuePair<string, Person> student in Members.Where(
            m => m.Value.GetType() == typeof(Student)
            && ((Student)m.Value).GPA > _gradGPA).ToList())
        {
            Members.Remove(student.Key);
        }
    }
}
