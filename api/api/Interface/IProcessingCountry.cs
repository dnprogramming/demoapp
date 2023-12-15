namespace api.Interface;

public interface IProcessingCountry
{
  AddCountryResponse AddCountry(AddCountryRequest country);
  GetCountriesResponse GetCountries(GetCountriesRequest country);
}

