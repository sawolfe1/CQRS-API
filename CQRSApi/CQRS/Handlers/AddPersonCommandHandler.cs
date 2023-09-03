using CQRSApi.CQRS.Commands;
using CQRSApi.EF;
using CQRSApi.Models;

namespace CQRSApi.CQRS.Handlers;

public class AddPersonCommandHandler
{
    private readonly CqrsContext _dbContext;
    private readonly ILogger<AddPersonCommandHandler> _logger;

    public AddPersonCommandHandler(CqrsContext dbContext, ILogger<AddPersonCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> HandleAsync(AddPersonCommand request)
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            GivenName = request.GivenName,
            Surname = request.Surname,
            Gender = request.Gender,
            BirthDate = request.BirthDate,
            BirthLocation = request.BirthLocation,
            DeathDate = request.DeathDate,
            DeathLocation = request.DeathLocation
        };
        _logger.LogInformation("Handling AddPersonCommand for PersonId: {PersonId}", person.Id);
        _dbContext.Persons.Add(person);
        await _dbContext.SaveChangesAsync();

        return person.Id;
    }
}