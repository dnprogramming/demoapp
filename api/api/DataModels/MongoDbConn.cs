namespace api.DataModels;

public class MongoDbConn
{
  public string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("MongoDbConnectionString")!;
  public string DatabaseName { get; set; } = Environment.GetEnvironmentVariable("MongoDbDatabaseName")!;
  public string CollectionName { get; set; } = null!;
}
