using System.Collections;

namespace LabN2_dotnet;

public class Student: Person, IDateAndCopy, IEnumerable
{
    private Education _educationForm;
    private int _groupNumber;
    private ArrayList? _tests;
    private ArrayList? _examsTaken;

    public Student(Person studentData, Education educationForm, int groupNumber)
        : base(studentData.FirstName, studentData.LastName, studentData.BirthDate)
    {
        EducationForm = educationForm;
        GroupNumber = groupNumber;
        Tests = new ArrayList();
        ExamsTaken = new ArrayList();
    }

    public Student() : this(studentData: new Person(), educationForm: Education.Bachelor, groupNumber: 111) { }

    public Person StudentData
    {
        get { return this; }
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
        init 
        {
            if (value <= 100 || value > 699)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(GroupNumber),
                    message: "Group number must be between 100 and 699."
                );
            }
            _groupNumber = value;
        }
    }

    public ArrayList? ExamsTaken
    {
        get { return _examsTaken; }
        init { _examsTaken = value; }
    }

    public ArrayList? Tests
    {
        get { return _tests; }
        init { _tests = value; }
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

        if (_examsTaken == null)
        {
            _examsTaken = new ArrayList();
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

        if (_tests == null)
        {
            _tests = new ArrayList();
        } 

        foreach (var test in newTests)
        {
            _tests.Add(test);
        }
        
        Console.WriteLine("Tests was added successfully");
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
        
        if ((Tests == null || Tests.Count == 0) && (ExamsTaken == null || ExamsTaken.Count == 0)) 
        {
            return studentCopy;
        }

        if (Tests != null && Tests.Count > 0)
        {
            Test[] testsCopy = new Test[Tests.Count];
            foreach (Test test in Tests)
            {
                testsCopy = test.DeepCopy() as Test[];
            }
            studentCopy.AddTests(testsCopy);
        }

        if (ExamsTaken != null && ExamsTaken.Count > 0)
        {
            Exam[] examsCopy = new Exam[ExamsTaken.Count];
            foreach (Exam exam in ExamsTaken)
            {
                examsCopy = exam.DeepCopy() as Exam[];
            }
            studentCopy.AddExams(examsCopy);
        }

        return studentCopy;
    }   

    public IEnumerator GetEnumerator()
    {
        if ((Tests == null || Tests.Count == 0) && (ExamsTaken == null || ExamsTaken.Count == 0)) 
        {
            yield break;
        }

        Console.WriteLine("All tests and exams:");
        if (Tests != null && Tests.Count > 0)
        {
            foreach (var item in Tests)
            {
                yield return item;
            }
        }
        
        if (ExamsTaken != null && ExamsTaken.Count > 0)
        {
            foreach (var item in ExamsTaken)
            {
                yield return item;
            }
        }
    }

    /*public IEnumerator GetEnumerator()
    {
        if (Tests == null || Tests.Count == 0 || ExamsTaken == null || ExamsTaken.Count == 0)
        {
            throw new ArgumentNullException("Tests or Exams cannot be empty");
        }

        Console.WriteLine("All tests and exams:");

        return new StudentEnumerator(this);
    }*/

    public IEnumerable GetExamsWithGradeGreaterThan(double grade)
    {
        if (ExamsTaken == null || ExamsTaken.Count == 0) 
        {
            yield break;
        }

        Console.WriteLine("Exams with grade grater than " + grade + ":");
        foreach (var exam in ExamsTaken)
        {
            if (exam is Exam && ((Exam)exam).Assessment > grade)
            {
                yield return exam;
            }
        }
    }

    public IEnumerator GetIntersection()
    {
        if (Tests == null || Tests.Count == 0 || ExamsTaken == null || ExamsTaken.Count == 0) 
        {
            throw new ArgumentNullException("Tests or Exams cannot be empty");
        }

        foreach (Test test in Tests)
        {
            foreach (Exam exam in ExamsTaken)
            {
                if (test.SubjectName == exam.SubjectName)
                {
                    yield return test.SubjectName;
                }
            }
        }
    }
}