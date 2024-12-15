using hahn.application.contracts;
using hahn.domain.contracts;
using hahn.domain.entities;

namespace hahn.application.queries;

public class QueryCountriesRequest : IRequest<IEnumerable<QueryCountriesResponse>>
{
    
}

public class QueryCountriesResponse(
    Guid id,
    string name,
    string capital,
    string region,
    string subregion,
    string flag,
    long population,
    long area,
    string currency)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Capital { get; set; } = capital;
    public string Region { get; set; } = region;
    public string Subregion { get; set; } = subregion;
    public string Flag { get; set; } = flag;
    public long Population { get; set; } = population;
    public long Area { get; set; } = area;
    public string Currency { get; set; } = currency;

    public static QueryCountriesResponse From(Country country)
    {
        return new QueryCountriesResponse(country.Id, country.Name, country.Capital, country.Region, country.Subregion, country.Flag, country.Population, country.Area, country.Currency);
    }
}

public class CountriesQueryHandler(ICountryRepository countryRepository) : IRequestHandler<QueryCountriesRequest, IEnumerable<QueryCountriesResponse>>
{
    public Task<IEnumerable<QueryCountriesResponse>> Handle(QueryCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = countryRepository.GetCountries();
        return Task.FromResult(countries.AsEnumerable().Select(QueryCountriesResponse.From));
    }
}