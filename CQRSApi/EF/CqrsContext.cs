using CQRSApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSApi.EF;

public class CqrsContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public CqrsContext(DbContextOptions<CqrsContext> options)
        : base(options)
    {
    }
}