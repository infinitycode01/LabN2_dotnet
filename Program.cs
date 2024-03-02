namespace LabN2_dotnet;

class Program
{
    static void Main(string[] args)
    {
        
        Student student = new Student();
        Student student1 = new Student(new Person("albert", "Albert", new DateTime(2000, 10, 10)), Education.Master, 111);
        //Console.WriteLine(student1.ToString());

        Test[] newTests = [new Test(), new Test(), new Test()];
        Exam[] newExams = [new Exam(), new Exam(), new Exam()];
        

        student1.AddTests(newTests);
        student1.AddExams(newExams);


        Console.WriteLine(student1.ToString());

        student = (Student)student1.DeepCopy();

        Console.WriteLine(student.ToString());

        
    }
}
