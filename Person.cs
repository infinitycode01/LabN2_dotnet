namespace LabN2_dotnet;

public class Person
{
    private string _firstName;
    private string _lastName;
    private System.DateTime _birthDate;


    public Person(string firstName, string lastName, System.DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public Person(): this(firstName: "Dmytro", lastName: "Badichel", birthDate: new DateTime(2004, 9, 11, 7, 7, 7)) { }
    
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

    public System.DateTime BirthDate
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

    public override string ToString()
    {
        return "Name: " + FirstName + "\n" 
            + "Surname: " + LastName + "\n" 
            + "Birth date: " + BirthDate;
    }

    public string ToShortString() => "Name: " + FirstName + "\n" + "Surname: " + LastName;

}