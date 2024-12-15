using System.Text.Json.Serialization;
using hahn.domain.entities;

namespace hahn.infrastructure.dto;

public class RootApiResponse()
{
    public string Message { get; set; }
    public IEnumerable<CountryApiResponse> Data { get; set; }
}

public class CountryApiResponse
{
    public string name { get; set; }
    public string capital { get; set; }
    public string region { get; set; }
    public string subregion { get; set; }
    public int population { get; set; }
    public dynamic area { get; set; }
    public string currency { get; set; }
    public string flag { get; set; }

    public Country ToCountry()
    {
        int.TryParse(area.ToString(), out int areaInt);
        
        return new Country(Guid.Empty, name, capital, region, subregion, flag, currency, areaInt, population);
    }
}