using hahn.domain.contracts;

namespace hahn.domain.entities;

public class Country(Guid id, string name, string capital, string region, string subregion, string flag, string currency, int area, int population)
    : IAggregateRoot
{
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Capital { get; private set; } = capital;
    public string Region { get; private set; } = region;
    public string Subregion { get; private set; } = subregion;
    public string Flag { get; private set; } = flag;
    public int Population { get; private set; } = population;
    public int Area { get; private set; } = area;
    public string Currency { get; private set; } = currency;

    //Update country data. Name can not be changed
    public void UpdateCountry(string capital, string region, string subregion, string flag,
        string currency, int area, int population)
    {
        Capital = capital;
        Region = region;
        Subregion = subregion;
        Flag = flag;
        Currency = currency;
        Area = area;
        Population = population;
    }
    
}