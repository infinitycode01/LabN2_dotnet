namespace LabN2_dotnet;

public class Test
{
    public string SubjectName { get; init; }
    public bool IsPassed { get; init; }

    public Test(string subjectName, bool isPassed)
    {
        SubjectName = subjectName;
        IsPassed = isPassed;
    }

    public Test() : this("C#", true) {}

    public override string ToString() => "Subject name: " + SubjectName + "\n" + "Passed: " + IsPassed;

}