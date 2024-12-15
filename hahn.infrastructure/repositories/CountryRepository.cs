using hahn.domain.contracts;
using hahn.domain.entities;
using hahn.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace hahn.infrastructure.repositories;

public class CountryRepository(DbContextOptions options) : ApplicationDbContext(options), ICountryRepository
{
    public async Task AddCountry(Country country)
    {
        await Countries.AddAsync(country);
    }

    public IQueryable<Country> GetCountries()
    {
        return Countries.AsNoTracking();
    }

    public new async Task SaveChanges()
    {
        await SaveChangesAsync();
    }

    public async Task<Country> GetCountryById(Guid countryId)
    {
        return await Countries.FirstAsync(c => c.Id == countryId);
    }

    public Task UpdateCountry(Country country)
    {
        Countries.Update(country);
        return Task.CompletedTask;
    }

    public async Task DeleteCountry(Guid countryId)
    {
        await Countries.Where(c => c.Id == countryId).ExecuteDeleteAsync();
    }
}