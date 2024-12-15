using hahn.application.contracts;
using hahn.domain.contracts;
using hahn.domain.entities;

namespace hahn.application.commands;

public class ImportCountriesRequest : IRequest<ImportCountriesResponse>
{
    
}

public class ImportCountriesResponse
{
    public int ImportedCount { get; set; }
}

public class ImportCountriesHandler(ICountryExternalRepository countryExternalRepository, ICountryRepository countryRepository) : IRequestHandler<ImportCountriesRequest, ImportCountriesResponse>
{
    public async Task<ImportCountriesResponse> Handle(ImportCountriesRequest request, CancellationToken cancellationToken)
    {
        //Get all countries from the external API
        var importedCountries = await countryExternalRepository.GetCountries();
        
        //List all countries to avoid round trips to databse
        var countriesInDatabase = countryRepository.GetCountries().ToList();

        var importedCount = 0;
        foreach (var importedCountry in importedCountries)
        {
            var countrySavedInDatabase = countriesInDatabase.FirstOrDefault(c => c.Name == importedCountry.Name);

            if (countrySavedInDatabase == null)
            {
                //Insert
                await countryRepository.AddCountry(importedCountry);
            }
            else
            {
                // Update existing country
                countrySavedInDatabase.UpdateCountry(
                    importedCountry.Capital, 
                    importedCountry.Region, 
                    importedCountry.Subregion, 
                    importedCountry.Flag,
                    importedCountry.Currency,
                    importedCountry.Area,
                    importedCountry.Population);
                
                await countryRepository.UpdateCountry(countrySavedInDatabase);
            }

            importedCount++;
        }

        //Commit the changes to database
        await countryRepository.SaveChanges();
        
        return new ImportCountriesResponse(){ImportedCount = importedCount}; 
    }
}