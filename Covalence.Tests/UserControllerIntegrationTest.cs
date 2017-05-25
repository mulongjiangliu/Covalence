using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Covalence.Contracts;
using System.Linq;

namespace Covalence.Tests
{
    [Collection("Integration")]
    public class UserControllerIntegrationTests
    {
        private readonly HttpClient Client;
        private readonly String Token;
        public UserControllerIntegrationTests(TestFixture<TestStartup> fixture)
        {
            Client = fixture.Client;
            Token = fixture.Token;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }

        [Fact]
        public async Task GetUser() {
            var response = await Client.GetAsync("/api/user");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserContract>(content);

            Assert.Equal(user.Email, "fixture@test.com");
        }

        [Fact]
        public async Task AddTagToUser_CorrectData_ShouldContainSingleTag() {
            var tagType = "study";
            var tagName = "Physics";
            var uri = $"/api/user/tag/{tagType}/{tagName}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            var response = await Client.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            var userResponse = await Client.GetAsync("/api/user");
            response.EnsureSuccessStatusCode();

            var content = await userResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserContract>(content);

            Assert.Equal(user.StudyTags.Single().Name, "Physics");         
        }

        [Fact]
        public async Task AddTagToUser_IncorrectTagType_ShouldReturn400Error() {
            var tagType = "dinosaurs"; // Testing non-accepted tagtypes
            var tagName = "Physics";
            var uri = $"/api/user/tag/{tagType}/{tagName}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            var response = await Client.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Invalid tag type", content);
        }

        [Fact]
        public async Task RemoveTagFromUser_CorrectData_ShouldContainZeroTags() {
            var tagType = "study";
            var tagName = "Physics";

            // Assign Physics as a Study tag to User
            var createUri = $"/api/user/tag/{tagType}/{tagName}";
            var createResponse = await Client.SendAsync(new HttpRequestMessage(HttpMethod.Post, createUri));
            createResponse.EnsureSuccessStatusCode();

            // Remove Physics from Study tags on User
            var removeUri = $"/api/user/tag/{tagType}/{tagName}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, removeUri);
            var response = await Client.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            // Validate on User
            var userResponse = await Client.GetAsync("/api/user");
            response.EnsureSuccessStatusCode();

            var content = await userResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserContract>(content);

            Assert.False(user.StudyTags.Any());  
        }

        [Fact(Skip="Not Implemented")]
        public async Task RequestConnectionToUser() {

        }

        [Fact(Skip="Not Implemented")]
        public async Task AcceptConnectionFromUser() {

        }

        [Fact(Skip="Not Implemented")]
        public async Task RejectConnectionFromUser() {

        }

        [Fact(Skip="Not Implemented")]
        public async Task BlockUser() {

        }

        // [Fact]
        // public void TestFoo()
        // {
        //     Assert.True(false, $"{nameof(TestFoo)} was run.");
        // }
    }
}
