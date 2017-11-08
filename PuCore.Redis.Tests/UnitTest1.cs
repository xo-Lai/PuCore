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
            RedisHelper redisHelper = new RedisHelper(1, "127.0.0.1:6379,allowAdmin=true");
            string a = "abc";
            await redisHelper.StringSetAsync("test", a);
            var b = await redisHelper.StringGetAsync("test");

            Assert.True(a == b.ToString());
        }

    }

}

