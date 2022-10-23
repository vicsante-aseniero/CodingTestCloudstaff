using System.Diagnostics;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

/// <summary>
/// Please see the readme.md for details and information.
/// </summary>
namespace Diana.Code.Challenge
{
    /// <question>
    /// Please review the program below and refactor/change as required.
    /// </question>
    /// <answer>
    /// Fix code below.
    /// </answer>
    class Program
    {
        private static string _azureServiceKey = "e1951780-1460-445b-8e8e-9647e53ef023";

        private static string azureSecret = "asf23934td4dax5zx=";

        private static readonly int _cacheSize = 999_999;

        private static readonly uint _testNumber = 3;

        private static readonly uint _testLoopNumber = 100;

        static void Main(string[] args)
        {
            ConnectToAzure(_azureServiceKey, azureSecret);

            var caches = new iCacheStuff<employee>[]{
                new SlowCache<employee>(),
                new SuperFastCache<employee>() // <-- Need to make this really FAST!
            };

            foreach (var cache in caches)
            {
                TestCache(cache);
            }
        }

        /// <summary>
        /// Connect to azure for storing results
        /// </summary>
        /// <param name="serviceKey">The service key to connect to.</param>
        /// <param name="secret">The secret to use.</param>
        private static void ConnectToAzure(string serviceKey, string secret)
        {
            // Connect to azure
            ConnectToAzure(serviceKey, secret);
        }

        private static void TestCache(iCacheStuff<employee> cache)
        {
            new TestHarness()
                .Setup(cache: cache,
                        count: _cacheSize,
                        testNumber: _testNumber,
                        loopNumber: _testLoopNumber,
                        /// <question>
                        /// What is this code doing?
                        /// Why do you think that the coder used this approach?
                        /// <question>
                        /// <answer>
                        ///
                        /// </answer>
                        (System.Guid id, string name, string description) => new employee()
                        {
                            Id = id,
                            name = name,
                            _description = description
                        })
                .Run();
        }
    }
}
