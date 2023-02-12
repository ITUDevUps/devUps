using Xunit;
using minitwit_backend.Data;

namespace minitwit_backend.Test
{
    public class APiTest
    {
        [Fact]
        public async void GIVEN_DbContext_WHEN_GettingMessages_THEN_MessagesFromDBReturned()
        {
            using var context = await new TestContext().SetupMessageRepo();

            var messages = await context.Repo.GetMessagesAsync();
            Assert.NotEmpty(messages);
        }
    }
}