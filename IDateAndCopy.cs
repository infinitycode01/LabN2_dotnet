namespace LabN2_dotnet;

public interface IDateAndCopy
{
    DateTime Date { get; init; }
    
    object DeepCopy();
}