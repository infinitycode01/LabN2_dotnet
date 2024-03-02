namespace LabN2_dotnet;

public class Person : IDateAndCopy
{
    protected string _firstName;
    protected string _lastName;
    protected DateTime _birthDate;


    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public Person() : this(firstName: "Dmytro", lastName: "Badichel", birthDate: new DateTime(2004, 9, 11, 7, 7, 7)) { }
    
    public string FirstName
    {
        get { return _firstName; }
        init { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        init { _lastName = value; }
    }

    public DateTime BirthDate
    {
        get { return _birthDate; }
        init { _birthDate = value; }
    }

    public int BirthYear
    {
        get { return _birthDate.Year; }
        set
        {
            _birthDate = new DateTime(value, _birthDate.Month, _birthDate.Day);
        }
    }

    public DateTime Date
    {
        get { return BirthDate; }
        init { BirthDate = value; }
    }

    public override string ToString()
    {
        return "Name: " + FirstName + "\n" 
            + "Surname: " + LastName + "\n" 
            + "Birth date: " + BirthDate;
    }

    public string ToShortString() => "Name: " + FirstName + "\n" + "Surname: " + LastName;

    public static bool operator == (Person obj1, Person obj2)
    {
        if (obj1 is null)
            return obj2 is null;

        return obj1.Equals(obj2);
    }

    public static bool operator != (Person obj1, Person obj2)
    {
        return !(obj1 == obj2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;

        return obj is Person obj2? (FirstName == obj2.FirstName 
            && LastName == obj2.LastName 
            && BirthDate == obj2.BirthDate): false;
    }

    public override int GetHashCode()
    {
        return (FirstName, LastName, BirthDate).GetHashCode();
    }

    public object DeepCopy()
    {
        return new Person(FirstName, LastName, Date);
    }
}