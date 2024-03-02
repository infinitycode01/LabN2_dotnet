namespace LabN2_dotnet;

class Program
{
    static void Main(string[] args)
    {
        
        Student student = new Student("dfdfdf", "Badfdfdfdfdichel", new DateTime(2000, 10, 10), Education.Master, 311);
        Student student1 = new Student();
        Console.WriteLine(student1.ToString());

        student1 = (Student)student.DeepCopy();

        Console.WriteLine(student1.ToString());
        
    }
}
