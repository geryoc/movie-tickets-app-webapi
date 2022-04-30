using System.Text.Json;
using Xunit;

namespace MovieTicketsApp.WebApi.IntegrationTests.Tests.Shared
{
    public static class TestHelper
    {
        public static void AssertSuccessJsonResponse(HttpResponseMessage response)
        {
            var unsuccessfulResponseException = Record.Exception(() => response.EnsureSuccessStatusCode());
            Assert.Null(unsuccessfulResponseException);
            Assert.Contains("application/json", response.Content.Headers.ContentType.ToString());
        }

        public static async Task<T> Deserialize<T>(this HttpResponseMessage response)
        {
            T result = default(T);

            if (response.Content is object)
            {
                var content = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                result = await JsonSerializer.DeserializeAsync<T>(content, options);
            }

            return result;
        }
    }
}
