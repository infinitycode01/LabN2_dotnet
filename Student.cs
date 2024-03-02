namespace LabN2_dotnet;

public class Student: Person, IDateAndCopy
{
    private Education _educationForm;
    private int _groupNumber;
    private System.Collections.ArrayList? _tests;
    private System.Collections.ArrayList? _examsTaken;

    public Student(Person studentData, Education educationForm, int groupNumber)
        : base(studentData.FirstName, studentData.LastName, studentData.BirthDate)
    {
        EducationForm = educationForm;
        GroupNumber = groupNumber;
        Tests = new System.Collections.ArrayList();
        ExamsTaken = new System.Collections.ArrayList();
    }

    public Student() : base()
    {
        EducationForm = Education.Bachelor;
        GroupNumber = 111;
        Tests = new System.Collections.ArrayList();
        Tests.Add(new Test());
        ExamsTaken = new System.Collections.ArrayList();
        ExamsTaken.Add(new Exam());
    }

    public Person StudentData
    {
        get { return new Person(FirstName, LastName, BirthDate); }
        init 
        {
            FirstName = value.FirstName;
            LastName = value.LastName;
            BirthDate = value.BirthDate;
        }
    }

     public Education EducationForm
    {
        get { return _educationForm; }
        init { _educationForm = value; }
    }

    public int GroupNumber
    {
        get { return _groupNumber; }
        init { _groupNumber = value; }
    }

    public System.Collections.ArrayList? ExamsTaken
    {
        get { return _examsTaken; }
        init { _examsTaken = value; }
    }

    public System.Collections.ArrayList? Tests
    {
        get { return _tests; }
        init { _tests = value; }
    }

    public DateTime Date
    {
        get { return BirthDate; }
        init {  BirthDate = value; }
    }

    public double AverageGrade
    {
        get 
        {
            if (ExamsTaken == null || ExamsTaken.Count == 0)
            {
                return 0;
            }

            double gradeSum = 0;
            foreach (var exam in ExamsTaken)
            {
                gradeSum += ((Exam)exam).Assessment;
            }

            return gradeSum / ExamsTaken.Count;
        }
    }

    public void AddExams(params Exam[] newExams)
    {
        if (newExams == null || newExams.Length == 0)
        {
            return;
        }

        foreach (var exam in newExams)
        {
            _examsTaken.Add(exam);
        }
        
        Console.WriteLine("Exams was added successfully");
    }

    public void AddTests(params Test[] newTests)
    {
        if (newTests == null || newTests.Length == 0)
        {
            return;
        }

        foreach (var test in newTests)
        {
            _tests.Add(test);
        }
        
        Console.WriteLine("Exams was added successfully");
    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine("\x1b[1mStudent Data:\x1b[0m");
        sb.AppendLine(base.ToString());
        sb.AppendLine($"\x1b[1mEducation Form:\x1b[0m {EducationForm}");
        sb.AppendLine($"\x1b[1mGroup Number:\x1b[0m {GroupNumber}");
        sb.AppendLine("\x1b[1mTests:\x1b[0m");
        if (Tests == null || Tests.Count == 0)
        {
            sb.AppendLine("Tests is empty");
        }
        else
        {
            foreach (var test in Tests)
            {
                if (test != null)
                {
                    sb.AppendLine(test.ToString());
                }
            }
        }
        sb.AppendLine("\x1b[1mExams Taken:\x1b[0m");
        if (ExamsTaken == null || Tests.Count == 0)
        {
            sb.AppendLine("Exams is empty");
        }
        else
        {
            foreach (var exam in ExamsTaken)
            {
                if (exam != null)
                {
                    sb.AppendLine(exam.ToString());
                }
            }
        }
        return sb.ToString();
    }

    public string ToShortString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine("\x1b[1mStudent Data:\x1b[0m");
        sb.AppendLine(base.ToString());
        sb.AppendLine($"\x1b[1mEducation Form:\x1b[0m {EducationForm}");
        sb.AppendLine($"\x1b[1mGroup Number:\x1b[0m {GroupNumber}");
        sb.AppendLine($"\x1b[1mAverage grade:\x1b[0m {AverageGrade}");

        return sb.ToString();
    }

    public object DeepCopy()
    {
        Student studentCopy = new Student(new Person(FirstName, LastName, Date), EducationForm, GroupNumber);

        if (Tests != null && Tests.Count > 0)
        {
            Test[] testsCopy = new Test[Tests.Count];
            Tests.CopyTo(testsCopy);
            studentCopy.AddTests(testsCopy);
        }

        if (ExamsTaken != null && ExamsTaken.Count > 0)
        {
            Exam[] examsCopy = new Exam[ExamsTaken.Count];
            ExamsTaken.CopyTo(examsCopy);
            studentCopy.AddExams(examsCopy);
        }

        return studentCopy;
    }
}

