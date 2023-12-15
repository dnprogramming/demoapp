namespace api.Utilities;

public class MongoDbService : IMongoDbService
{
  private readonly IMongoCollection<Encryption> _encryptionKeys;
  private readonly ILogger<MongoDbService> _logger;

  public MongoDbService(IOptions<MongoDbConn> mongoDBSettings, ILogger<MongoDbService> logger)
  {
    MongoClient client = new(mongoDBSettings.Value.ConnectionString);
    IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
    database.CreateCollection(mongoDBSettings.Value.CollectionName);
    _encryptionKeys = database.GetCollection<Encryption>(mongoDBSettings.Value.CollectionName);
    _logger = logger;
  }

  public async Task<Encryption> GetAsync(string id)
  {
    Encryption keys = await _encryptionKeys.Find(x => x.Ident == id).FirstOrDefaultAsync();
    return keys;
  }
  public async Task CreateAsync(Encryption encryption)
  {
    try
    {
      await _encryptionKeys.InsertOneAsync(encryption);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error Occurred in MongoDbService GetAsync");
    }
  }
}

