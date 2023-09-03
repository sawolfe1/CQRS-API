using CQRSApi.CQRS.Commands;
using CQRSApi.EF;
using Microsoft.EntityFrameworkCore;

namespace CQRSApi.CQRS.Handlers;

public class RecordBirthCommandHandler
{
    private readonly CqrsContext _dbContext;
    private readonly ILogger<RecordBirthCommandHandler> _logger;

    public RecordBirthCommandHandler(CqrsContext dbContext, ILogger<RecordBirthCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> HandleAsync(RecordBirthCommand command)
    {
        _logger.LogInformation("Handling RecordBirthCommand for PersonId: {PersonId}", command.PersonId);
        var person = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == command.PersonId);

        if (person == null)
            throw new Exception("Person not found");

        person.BirthDate = command.BirthDate ?? person.BirthDate;
        person.BirthLocation = command.BirthLocation ?? person.BirthLocation;

        await _dbContext.SaveChangesAsync();

        return person.Id;
    }
}