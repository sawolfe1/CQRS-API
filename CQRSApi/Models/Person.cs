namespace CQRSApi.Models;

public class Person
{
    public Guid Id { get; set; }
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string BirthLocation { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? DeathLocation { get; set; }
}

public enum Gender
{
    Male,
    Female,
    NonBinary,
    Other
}