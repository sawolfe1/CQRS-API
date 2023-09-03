using CQRSApi.CQRS.Commands;
using CQRSApi.CQRS.Handlers;
using CQRSApi.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CQRSApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : Controller
{
    private readonly AddPersonCommandHandler _addPersonHandler;
    private readonly RecordBirthCommandHandler _recordBirthHandler;
    private readonly GetPersonIdQueryHandler _getPersonIdHandler;
    private readonly GetAllPeopleQueryHandler _getAllPeopleHandler;

    public PersonController(AddPersonCommandHandler addPersonHandler, RecordBirthCommandHandler recordBirthHandler, GetPersonIdQueryHandler getPersonIdHandler, GetAllPeopleQueryHandler getAllPeopleHandler)
    {
        _addPersonHandler = addPersonHandler;
        _recordBirthHandler = recordBirthHandler;
        _getPersonIdHandler = getPersonIdHandler;
        _getAllPeopleHandler = getAllPeopleHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] AddPersonCommand command)
    {
        if (!ModelState.IsValid || (command.GivenName.IsNullOrEmpty() && command.Surname.IsNullOrEmpty()))
            return BadRequest(ModelState);
        
        var id = await _addPersonHandler.HandleAsync(command);
        return Ok(id);
    }

    [HttpPost("record-birth")]
    public async Task<IActionResult> RecordBirth([FromBody] RecordBirthCommand command)
    {
        if (!ModelState.IsValid || (command.BirthDate is null && string.IsNullOrWhiteSpace(command.BirthLocation)))
            return BadRequest(ModelState);
        
        var id = await _recordBirthHandler.HandleAsync(command);
        return Ok(id);
    }
    [HttpPost("get-person-id")]
    public async Task<IActionResult> GetPersonId([FromBody] GetPersonId query)
    {
        var personId = await _getPersonIdHandler.HandleAsync(query);
            
        if (!personId.HasValue)
            return NotFound();

        return Ok(personId);
    }
    [HttpGet("get-all-people")]
    public async Task<IActionResult> GetAllPeople()
    {
        var people = await _getAllPeopleHandler.HandleAsync();
        return Ok(people);
    }
}