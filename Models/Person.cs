namespace MatrixDigital;

public abstract class Person
{
    public string Id { get; } = null!;

    public string Name { get; set; }

    public int Age { get; set; }

    protected Person(string id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public virtual string GetInfo()
    {
        string data = $"Id: {Id}\nName: {Name}\nAge: {Age}";

        return data;
    }
}
