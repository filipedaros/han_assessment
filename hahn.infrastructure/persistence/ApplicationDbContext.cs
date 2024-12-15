using hahn.domain.entities;
using Microsoft.EntityFrameworkCore;

namespace hahn.infrastructure.persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}