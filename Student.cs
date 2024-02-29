    namespace LabN2_dotnet;

    public class Student
    {
        private Person _studentData;
        private Education _educationForm;
        private int _groupNumber;
        private Exam[]? _examsTaken;

        public Student(Person studentData, Education educationForm, int groupNumber)
        {
            StudentData = studentData;
            EducationForm = educationForm;
            GroupNumber = groupNumber;
        }

        public Student(): this(studentData: new Person(), educationForm: Education.Bachelor, groupNumber: 111)
        {
            ExamsTaken = new Exam[3];
            for (int i = 0; i < ExamsTaken.Length; i++)
            {
                ExamsTaken[i] = new Exam();
            }

        }

        public Person StudentData
        {
            get { return _studentData; }
            init { _studentData = value; }
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

        public Exam[]? ExamsTaken
        {
            get { return _examsTaken; }
            init { _examsTaken = value; }
        }

        public double AverageGrade
        {
            get
            {
                if (ExamsTaken == null || ExamsTaken.Length == 0)
                {
                    return 0;
                }

                double gradeSum = 0;
                foreach (var exam in ExamsTaken)
                {
                    gradeSum += exam.Assessment;
                }

                return gradeSum / ExamsTaken.Length;
            }
        }

        public bool this[Education index] => _educationForm == index;

        public void AddExams(params Exam[] newExams)
        {
            if (newExams == null || newExams.Length == 0)
            {
                return;
            }

            if (ExamsTaken == null || ExamsTaken.Length == 0)
            {
                _examsTaken = newExams;
                return;
            }

            int currentLength = ExamsTaken.Length;
            Array.Resize(ref _examsTaken, currentLength + newExams.Length);
            
            for (int i = 0; i < newExams.Length; i++)
            {
                _examsTaken[currentLength + i] = newExams[i];
            }

            Console.WriteLine("Exams were added successfully");
        }


        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
    
            sb.AppendLine("\x1b[1mStudent Data:\x1b[0m");
            sb.AppendLine(_studentData.ToString());
            sb.AppendLine($"\x1b[1mEducation Form:\x1b[0m {_educationForm}");
            sb.AppendLine($"\x1b[1mGroup Number:\x1b[0m {_groupNumber}");
            sb.AppendLine("\x1b[1mExams Taken:\x1b[0m");
            foreach (var exam in _examsTaken)
            {
                if (exam != null)
                {
                    sb.AppendLine(exam.ToString());
                }
            }

            return sb.ToString();
        }

        public string ToShortString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
    
            sb.AppendLine("\x1b[1mStudent Data:\x1b[0m");
            sb.AppendLine(_studentData.ToString());
            sb.AppendLine($"\x1b[1mEducation Form:\x1b[0m {_educationForm}");
            sb.AppendLine($"\x1b[1mGroup Number:\x1b[0m {_groupNumber}");
            sb.AppendLine($"\x1b[1mAverage grade:\x1b[0m {AverageGrade}");

            return sb.ToString();
        }
    }

