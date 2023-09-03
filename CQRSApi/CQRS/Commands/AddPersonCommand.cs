using System.ComponentModel.DataAnnotations;
using CQRSApi.Models;

namespace CQRSApi.CQRS.Commands;

public class AddPersonCommand
{
    
    public string GivenName { get; set; }
    public string Surname { get; set; }
    [Required(ErrorMessage = "Gender is required")]
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string BirthLocation { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? DeathLocation { get; set; }
}