namespace LabN2_dotnet;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        Person person1 = new Person();
        Person person2 = new Person("Dima", "badichel", new DateTime(2010, 10, 10));

        Console.WriteLine(person2.GetHashCode());

        
    }
}
