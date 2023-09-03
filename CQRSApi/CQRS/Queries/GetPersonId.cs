namespace CQRSApi.CQRS.Queries;

public class GetPersonId
{
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string BirthLocation { get; set; }
}