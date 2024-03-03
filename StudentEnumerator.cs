using System.Collections;

namespace LabN2_dotnet;

public class StudentEnumerator : IEnumerator
{
    private readonly Student _student;
    private readonly HashSet<string> _testSubjects;
    private readonly HashSet<string> _examSubjects;
    private readonly List<object> _mergedList;
    private int _currentIndex = -1;

    public StudentEnumerator(Student student)
    {
        _student = student ?? throw new ArgumentNullException(nameof(student));

        _testSubjects = new HashSet<string>();
        _examSubjects = new HashSet<string>();

        if (_student.Tests != null)
        {
            foreach (Test test in _student.Tests)
            {
                _testSubjects.Add(test.SubjectName);
            }
        }

        // Заповнюємо HashSet назвами предметів для іспитів
        if (_student.ExamsTaken != null)
        {
            foreach (Exam exam in _student.ExamsTaken)
            {
                _examSubjects.Add(exam.SubjectName);
            }
        }
    }

    public object Current
    {
        get
        {
            if (_currentIndex == -1 || _currentIndex >= _mergedList.Count)
            {
                throw new InvalidOperationException();
            }
            return _mergedList[_currentIndex];
        }
    }

    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < _mergedList.Count;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }
}


        /*public IEnumerator GetEnumerator()
        {
            if (Student.Tests == null || Student.Tests.Count == 0 || Student.ExamsTaken == null || Student.ExamsTaken.Count == 0) 
            {
                throw new ArgumentNullException("Tests or Exams cannot be empty");
            }

            foreach (Test test in Student.Tests)
            {
                foreach (Exam exam in Student.ExamsTaken)
                {
                    if (test.SubjectName == exam.SubjectName)
                    {
                        yield return test.SubjectName;
                    }
                }
            }
        }*/
        
    


