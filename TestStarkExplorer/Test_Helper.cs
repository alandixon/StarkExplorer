using StarkExplorerLib;

namespace TestStarkExplorer
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_GetEnvVar_temp()
        {
            string temp = "temp";
            string envvar = Helper.GetEnvVar(temp);
            Assert.IsTrue(!string.IsNullOrEmpty(envvar), $"Failed to find environment variable called {temp}.");
        }

        [Test]
        public void Test_GetEnvVar_apikey()
        {
            string apikey = "INFURA_APIKEY";
            string envvar = Helper.GetEnvVar(apikey);
            Assert.IsTrue(!string.IsNullOrEmpty(envvar), $"Failed to find environment variable called {apikey}.");
        }
    }
}