namespace LabN2_dotnet;

class Program
{
    static void Main(string[] args)
    {
        
        Student student = new Student();
        Student student1 = new Student(new Person("albert", "Albert", new DateTime(2000, 10, 10)), Education.Master, 500);
        //Console.WriteLine(student1.ToString());

        Exam[] newExams = [new Exam("C00000", 80, new DateTime(2000, 10, 10)), new Exam("C++", 100, new DateTime(2000, 10, 10)), new Exam("Java", 120, new DateTime(2000, 10, 10))];
        Test[] newTests = [new Test("Golang", true), new Test("C", true), new Test("python", true)];

        student1.AddExams(newExams);
        student1.AddTests(newTests);

        //Console.WriteLine(student1.ToString());

        foreach (var item in student1)
        {
            Console.WriteLine(item);
        }

        foreach (var exam in student1.GetExamsWithGradeGreaterThan(85))
        {
            Console.WriteLine(exam);
        }
        
    }
}
