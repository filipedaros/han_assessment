using hahn.domain.entities;

namespace hahn.domain.contracts;

public interface ICountryRepository
{
    Task AddCountry(Country country);
    Task UpdateCountry(Country country);
    Task DeleteCountry(Guid countryId);
    Task<Country> GetCountryById(Guid countryId);
    IQueryable<Country> GetCountries();
    Task SaveChanges();

}

public interface ICountryExternalRepository
{
    Task<IEnumerable<Country>> GetCountries();
    
}