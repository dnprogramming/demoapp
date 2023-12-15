using System;
namespace tests.Utilities
{
  [TestFixture]
  public class EncryptingTests
  {
    [OneTimeSetUp]
    public void Init()
    {
      Environment.SetEnvironmentVariable("SpPassKey", "Pass");
    }

    [Test]
    public void GetStoredProcedureKey()
    {
      var enc = new Encrypting(new Mock<ILogger<Encrypting>>().Object);
      string key = enc.SPPassKey();
      Assert.True(key == "Pass");
    }
  }
}

