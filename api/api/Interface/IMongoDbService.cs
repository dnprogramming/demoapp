namespace api.Interface;

public interface IMongoDbService
{
  Task<Encryption> GetAsync(string id);
  Task CreateAsync(Encryption encryption);
}

