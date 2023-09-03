using CQRSApi.EF;
using CQRSApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSApi.CQRS.Handlers;

public class GetAllPeopleQueryHandler
{
    private readonly CqrsContext _dbContext;
    private readonly ILogger<GetAllPeopleQueryHandler> _logger;

    public GetAllPeopleQueryHandler(CqrsContext dbContext, ILogger<GetAllPeopleQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<List<Person>> HandleAsync()
    {
        _logger.LogInformation("Handling GetAllPeople");
        var people = await _dbContext.Persons.ToListAsync();
        return people;
    }
}