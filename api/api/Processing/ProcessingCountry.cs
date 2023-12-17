namespace api.Processing;

public class ProcessingCountry : IProcessingCountry
{
  private const string cacheKey = "countries";
  private DistributedCacheEntryOptions _cacheOptions = new();
  private readonly IDistributedCache _cache;
  private readonly IDataProtector _dataProt;
  private readonly IDbConnection _connection;
  private readonly IEncrypting _enc;
  private readonly IMongoDbService _mongo;
  private SystemContext _db;
  private ILogger<ProcessingCountry> _logger;
  public ProcessingCountry(IDistributedCache cache, SystemContext db,
                             IDataProtectionProvider dataProtProvider,
                             IDbConnection connection,
                             IEncrypting enc,
                             IMongoDbService mongo,
                             ILogger<ProcessingCountry> logger)
  {
    _cache = cache;
    _db = db;
    _logger = logger;
    _connection = connection;
    _dataProt = dataProtProvider.CreateProtector("Country");
    _enc = enc;
    _mongo = mongo;
  }
  private List<CountryInformation> GetCountriesEncryptedForApi()
  {
    List<CountryInformation> countries = new();
    try
    {
      if (_cache.Get(cacheKey) != null)
      {
        var result = _cache.Get(cacheKey);
        var jsonString = Encoding.UTF8.GetString(result);
        var results = JsonConvert.DeserializeObject<List<CountryInformation>>(jsonString);
        foreach (var r in results)
        {
          string decryptedcountry = _dataProt.Unprotect(r.Countryname);
          CountryInformation country = new()
          {
            Countryid = r.Countryid.ToString(),
            Countryname = decryptedcountry
          };
          countries.Add(country);
        }
      }
      else
      {
        string sp = "uspGetCountries";
        DynamicParameters parameters = new();
        parameters.Add("@passkey", _enc.SPPassKey());
        var result = _connection.Query<CountryDataModel>(sp, parameters, null, true, null, CommandType.StoredProcedure).ToList();
        Console.WriteLine(result.Count);
        foreach (var r in result)
        {

          string decryptedcountry = _dataProt.Unprotect(r.Country_name);
          CountryInformation country = new()
          {
            Countryid = r.Country_external_id.ToString(),
            Countryname = decryptedcountry
          };
          countries.Add(country);
        }
        _cacheOptions.SetAbsoluteExpiration(DateTimeOffset.Now.AddDays(7));
        var jsonString = JsonConvert.SerializeObject(countries);
        var byteArray = Encoding.UTF8.GetBytes(jsonString);
        _cache.Set(cacheKey, byteArray, _cacheOptions);
      }
    }
    catch(Exception ex)
    {
      _logger.LogError($"A Error has occurred in GetCountries Encrypted: {ex.Message}");
    }
    return countries;
  }
  private List<CountryInformation> GetCountriesEncryptedForCacheUpdate()
  {
    List<CountryInformation> countries = new();
    try
    {
      if (_cache.Get(cacheKey) != null)
      {
        var result = _cache.Get(cacheKey);
        var jsonString = Encoding.UTF8.GetString(result);
        var results = JsonConvert.DeserializeObject<List<CountryInformation>>(jsonString);
        foreach (var r in results)
        {
          CountryInformation country = new()
          {
            Countryid = r.Countryid.ToString(),
            Countryname = r.Countryname
          };
          countries.Add(country);
        }
      }
      else
      {
        string sp = "uspGetCountries";
        DynamicParameters parameters = new();
        parameters.Add("@passkey", _enc.SPPassKey());
        var result = _connection.Query<CountryDataModel>(sp, parameters, null, true, null, CommandType.StoredProcedure).ToList();
        foreach (var r in result)
        {
          CountryInformation country = new()
          {
            Countryid = r.Country_external_id.ToString(),
            Countryname = r.Country_name
          };
          countries.Add(country);
        }
        _cacheOptions.SetAbsoluteExpiration(DateTimeOffset.Now.AddDays(7));
        var jsonString = JsonConvert.SerializeObject(countries);
        var byteArray = Encoding.UTF8.GetBytes(jsonString);
        _cache.Set(cacheKey, byteArray, _cacheOptions);
      }
    }
    catch(Exception ex)
    {
      _logger.LogError("A Error has occurred in GetCountries Encrypted: ", ex.Message);
    }
    return countries;
  }
  private CountryInformation InsertCountryEncrypted(AddCountryRequest country)
  {
    var name = _dataProt.Protect(country.Countryname.Trim());
    string sp = "uspInsertCountry";
    DynamicParameters parameters = new();
    parameters.Add("@country_name", name);
    parameters.Add("@record_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
    var countryId = _connection.ExecuteAsync(sp, parameters, null, null, CommandType.StoredProcedure).Result;
    var info = _db.Countries.Where(e => e.Id == countryId).FirstOrDefault().CountryExternalId.ToString();
    CountryInformation countryInformation = new()
    {
      Countryid = info,
      Countryname = name
    };
    var countriesData = GetCountriesEncryptedForCacheUpdate();
    countriesData.Add(countryInformation);
    _cache.Remove(cacheKey);
    var jsonString = JsonConvert.SerializeObject(countriesData);
    var byteArray = Encoding.UTF8.GetBytes(jsonString);
    _cacheOptions.SetAbsoluteExpiration(DateTimeOffset.Now.AddDays(7));
    _cache.Set(cacheKey, byteArray, _cacheOptions);
    return countryInformation;
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
      var countryAdded = InsertCountryEncrypted(country);
      response.Success = true;
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
      var countriesData = GetCountriesEncryptedForApi();
      countries.Countries.AddRange(countriesData);
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

