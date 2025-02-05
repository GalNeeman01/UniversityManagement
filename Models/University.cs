namespace MatrixDigital;

public class University : IGraduatable
{
    private double _gradGPA = 3;

    public Dictionary<string, Person> Members { get; set; } = new Dictionary<string, Person>();

    public bool AddPerson(Person person)
    {
        if (Members.ContainsKey(person.Id)) return false;

        Members.Add(person.Id, person);

        return true;
    }

    public Person? FindPerson(string id)
    {
        if (Members.TryGetValue(id, out Person? person))
            return person;

        return null;
    }

    public void DisplayAllPeople()
    {
        foreach (KeyValuePair<string, Person> member in Members)
            Console.WriteLine(member.Value.GetInfo());
    }

    public void Graduate()
    {
        // Remove all members of type Student that have a GPA higher than the gradGPA defined above.
        foreach (KeyValuePair<string, Person> student in Members.Where(
            m => m.Value.GetType() == typeof(Student)
            && ((Student)m.Value).GPA > _gradGPA).ToList())
        {
            Members.Remove(student.Key);
        }
    }
}
