namespace tests.Utilities
{
  public class ConnectionsTests
  {
    [OneTimeSetUp]
    public void Init()
    {
      Environment.SetEnvironmentVariable("RedisHostName", "MockRedis");
      Environment.SetEnvironmentVariable("RedisPortNumber", "6379");
      Environment.SetEnvironmentVariable("RedisPassword", "MockRedisPassword");
      Environment.SetEnvironmentVariable("SecuredRedisHostName", "MockSecuredRedis");
      Environment.SetEnvironmentVariable("SecuredRedisPortNumber", "6379");
      Environment.SetEnvironmentVariable("SecuredRedisPassword", "MockSecuredRedisPassword");
      Environment.SetEnvironmentVariable("SQLServerHostname", "MockDb");
      Environment.SetEnvironmentVariable("SQLServerDatabase", "MockSystem");
      Environment.SetEnvironmentVariable("SQLUserName", "MockUser");
      Environment.SetEnvironmentVariable("SQLPassword", "MockPassword");
    }

    [Test]
    public void TestRedisConnectionGeneration()
    {
      var RedisConnection = Connections.RedisConnectionString();

      Assert.That("MockRedis:6379,password=MockRedisPassword" == RedisConnection);
    }

    [Test]
    public void TestSecuredRedisConnectionGeneration()
    {
      var SecuredRedisConnection = Connections.SecuredRedisConnectionString();

      Assert.That("MockSecuredRedis:6379,password=MockSecuredRedisPassword" == SecuredRedisConnection);
    }

    [Test]
    public void TestSqlConnectionGeneration()
    {
      var SqlConnectionString = Connections.SQLConnectionString();

      Assert.That("Server=MockDb;Database=MockSystem;User Id=MockUser;Password=MockPassword;Trusted_Connection=True;TrustServerCertificate=true;integrated security=false;" == SqlConnectionString);
    }
  }
}

