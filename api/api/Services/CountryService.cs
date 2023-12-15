namespace api.Services;

	public class CountryService : Country.CountryBase
	{
  private ILogger<CountryService> _logger;
  private IProcessingCountry _country;

  public CountryService(ILogger<CountryService> logger, IProcessingCountry country)
  {
    _logger = logger;
    _country = country;
  }

  public override Task<AddCountryResponse> AddCountry(AddCountryRequest request, ServerCallContext context)
  {
   return Task.FromResult(_country.AddCountry(request));
  }

  public override Task<GetCountriesResponse> GetCountries(GetCountriesRequest country, ServerCallContext context)
  {
    return Task.FromResult(_country.GetCountries(country));
  }
}

