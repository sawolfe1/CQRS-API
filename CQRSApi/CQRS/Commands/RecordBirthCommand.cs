namespace CQRSApi.CQRS.Commands;

public class RecordBirthCommand
{
    public Guid PersonId { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? BirthLocation { get; set; }
}