namespace MatrixDigital;

public abstract class Person
{
    // Properties:
    public string Id { get; } = null!;

    public string Name { get; set; }

    public int Age { get; set; }

    // Constructor:
    protected Person(string id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    // Methods:
    // Return a string representing the person's information:
    public virtual string GetInfo()
    {
        string data = $"Id: {Id}\nName: {Name}\nAge: {Age}";

        return data;
    }
}
