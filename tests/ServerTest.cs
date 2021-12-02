using ProtoSharp;
using Xunit;

namespace tests
{
    public class ServerTest
    {
        [Fact]
        public void CreateServer()
        {
            var server = Server.Create();

            Assert.IsAssignableFrom<Server>(server);
            Assert.True(server.IsAlive);
        }
    }
}