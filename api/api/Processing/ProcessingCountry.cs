namespace api.Processing;

public class ProcessingCountry : IProcessingCountry
{
  private SystemContext _db;
  private ILogger<ProcessingCountry> _logger;
  public ProcessingCountry(SystemContext db, ILogger<ProcessingCountry> logger)
  {
    _db = db;
    _logger = logger;
  }

  private AddCountryResponse AddingCountry(AddCountryRequest country)
  {
    AddCountryResponse response = new()
    {
      Success = false
    };
    try
    {
      if (string.IsNullOrWhiteSpace(country.Countryname))
        return response;
      string? countryNameExist = _db.Countries.Where(c => c.CountryName.ToLower() == country.Countryname.ToLower()).Select(e => e.CountryName).FirstOrDefault();
      if (string.IsNullOrWhiteSpace(countryNameExist))
      {
        _db.Countries.Add(new DataContext.Country
        {
          CountryName = country.Countryname.Trim()
        });
        _db.SaveChanges();
        response.Success = true;
      }
      else
      {
        _logger.LogError("Country already exists");
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error Adding Country");
    }
    return response;
  }

  private GetCountriesResponse GettingCountries(GetCountriesRequest country)
  {
    GetCountriesResponse countries = new();
    try
    {
      List<DataContext.Country> countryList = _db.Countries.ToList();
      foreach(var c in countryList!)
      {
        CountryInformation cData = new()
        {
          Countryid = c.CountryExternalId.ToString(),
          Countryname = c.CountryName
        };
        countries.Countries.Add(cData);
      }  
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error occurred in GettingCountries");
    }
    return countries;
  }

  public AddCountryResponse AddCountry(AddCountryRequest country)
  {
    return AddingCountry(country);
  }

  public GetCountriesResponse GetCountries(GetCountriesRequest getCountries)
  {
    return GettingCountries(getCountries);
  }
}

