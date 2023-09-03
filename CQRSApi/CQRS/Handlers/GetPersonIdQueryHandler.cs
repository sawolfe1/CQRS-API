using CQRSApi.CQRS.Queries;
using CQRSApi.EF;
using Microsoft.EntityFrameworkCore;

namespace CQRSApi.CQRS.Handlers;

public class GetPersonIdQueryHandler
{
    private readonly CqrsContext _dbContext;
    private readonly ILogger<GetPersonIdQueryHandler> _logger;

    public GetPersonIdQueryHandler(CqrsContext dbContext, ILogger<GetPersonIdQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid?> HandleAsync(GetPersonId query)
    {
        _logger.LogInformation("Handling GetPersonId for Surname: {Name}", query.Surname);
        var person = await _dbContext.Persons.FirstOrDefaultAsync(p =>
            p.GivenName == query.GivenName &&
            p.Surname == query.Surname &&
            p.BirthDate.Month == query.BirthDate.Month &&
            p.BirthDate.Day == query.BirthDate.Day &&
            p.BirthDate.Year == query.BirthDate.Year &&
            p.BirthLocation == query.BirthLocation);

        if (person == null)
            return null;

        return person.Id;
    }
}