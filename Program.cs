using System.Collections;

namespace LabN2_dotnet;

class Program
{
    static void Main(string[] args)
    {
        /*Person person = new Person("alberto", "albo", new DateTime(2000, 10, 10));
        Person person1 = new Person("alberto", "albo", new DateTime(2000, 10, 10));
        Console.WriteLine(person.GetHashCode());
        Console.WriteLine(person1.GetHashCode());

        Student studentOriginal = new Student();
        Exam[] newExams = [new Exam("C00000", 80, new DateTime(2000, 10, 10)), new Exam("C++", 100, new DateTime(2000, 10, 10)), new Exam("Java", 120, new DateTime(2000, 10, 10))];
        Test[] newTests = [new Test("Golang", true), new Test("C", true), new Test("python", false)];
        studentOriginal.AddExams(newExams);
        studentOriginal.AddTests(newTests);
        Console.WriteLine(studentOriginal.ToString());

        Console.WriteLine(studentOriginal.StudentData);

        Student studentCopy = new Student();
        studentCopy = (Student)studentOriginal.DeepCopy();
        studentOriginal.AddTests(new Test());
        //((Test)studentOriginal.Tests[0]).SubjectName = "Golang1"; to check this line change Test class init => get
        Console.WriteLine(studentOriginal.ToString());
        Console.WriteLine(studentCopy.ToString());

        try
        {
            Console.WriteLine("Input group number:");
            int group = Convert.ToInt32(Console.ReadLine());
            Student studentException = new Student(new Person(), Education.Master, group);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }

        foreach (var exam in studentOriginal.GetExamsWithGradeGreaterThan(85))
        {
            Console.WriteLine(exam);
        }*/

        Student studentOriginal = new Student();
        Exam[] newExams = [new Exam("C00000", 80, new DateTime(2000, 10, 10)), new Exam("C++", 100, new DateTime(2000, 10, 10)), new Exam("Java", 120, new DateTime(2000, 10, 10))];
        Test[] newTests = [new Test("Golang", true), new Test("C", true), new Test("python", false)];
        studentOriginal.AddExams(newExams);
        studentOriginal.AddTests(newTests);

        ArrayList testAndExam = new ArrayList(studentOriginal.GetAllTestAndExam());
        foreach (var item in testAndExam)
        {
            Console.WriteLine(item);
        }
    }
}
