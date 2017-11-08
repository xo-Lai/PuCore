using StackExchange.Redis;
using System.Threading.Tasks;
using Xunit;

namespace PuCore.Redis.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task StringSetAsync_TestsAsync()
        {
            RedisHelper redisHelper = new RedisHelper();
            string a = "abc";

            await redisHelper.StringSetAsync("test", a);
            var b = await redisHelper.StringGetAsync("test");

            Assert.True(a == b.ToString());
        }

    }

}

