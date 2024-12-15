using System.Text.Json;
using hahn.domain.contracts;
using hahn.domain.entities;
using hahn.infrastructure.dto;
using Microsoft.Identity.Client;

namespace hahn.infrastructure.repositories;

public class CountryExternalRepository(IHttpClientFactory httpClientFactory) : ICountryExternalRepository
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IncludeFields = true};
    
    public async Task<IEnumerable<Country>> GetCountries()
    {
        var client = httpClientFactory.CreateClient("countries-api");
        
        var response = await client.GetAsync("/countries");
        response.EnsureSuccessStatusCode();
        
        var responseBody = await response.Content.ReadAsStringAsync(); 
        
        //If necessary, define a custom class to read the response of the api and then map do Country domain class.
        var countryData = JsonSerializer.Deserialize<RootApiResponse>(responseBody, _jsonSerializerOptions);

        if(countryData?.Data == null)
            throw new ApplicationException("Country data is null");
        
        var result = countryData.Data.Select(c => c.ToCountry());
        return result;
    }
}