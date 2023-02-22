using System.Net.Http.Headers;
using System.Text.Json;

namespace MA532
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string userProfileUrl = "https://graph.microsoft.com/v1.0/me";

        static async Task Main(string[] args)
        {
            string accessToken = "EwBgA8l6BAAUAOyDv0l6PcCVu89kmzvqZmkWABkAAUUw48Ar+B3ssL2IMQaxLlR/0QBDJ6qhBjgIwI6dPezF5ZSz3dayfvPRph9CbOoBp32GpYCzQ0WsUo1DTrOqgNmdsyVUStVjqcHd7pjWh2GC6GbtlbGow6RBoUHylRMQ5jlwPdN5RsOAt8LfsB0+10D86+79Qp/HYxcJx81yOzZRqJSL0zVbEt8hD6GMs6XMXnPrAYLI7XgnSQAQJQtBaNTsVhMAFbX4bEVlKBEoq27XLtdBUE6bXEfUbe/+4ZWrWmWKPXq9HngoAdolzCC4VxY0UqPHHWQ+rk0GbT8WfCCYIqG/tywQjhxZpim+Irvor4+39gaMEIwdQQMJuPRagm8DZgAACIKrJKaOAQLuMAIDPF08P1OsDQNq301XSmoBXwXQeS5jj4iW9FrGy2o9/uVKOzJvhzhV6Up+MeQWZqBZpOKFa4IxTKr/PoANf1Ldzi/a0wPzVW15A14fxZmCGnIm00C50c7Ocq5DqKc8CO8JR5zgwAtALyccYEDmOBP1Wd5qMcbidnUVb0d3wXW7jvHFkirm/7CoBUNuMRhgktgHGM3KeQglJn6KBl68k235K0cOD+I3rF9fdd9qbWSKLqQKkJlz27bzFeaaW2KHvnggyn/FmwcEwMDFQhedD+QLFqDOlqgiI/nUx4kBfwXCUYP4jRxnsA5oBTrY+Th8azCef4j74fNNDoOJJIoXkqNfjAXaGcpGB7iSXVD5LFS0i6v5KeIPVGLt5RdbHbXR3rlCh9Vk0keCuCMsfmAH076glS4NeY4l2NQJ5E3mx2Zatfofwt8vEtW0KJvkIl8yXLtuZ/T+MIhncJDXAV2tLfBCqmG8f9gc28g5CnrSPtalC1gOGVyEEaAl320KuETanpsNyacHZYC5HrRiEHKrHffQUyV9e1Xi2Sl6VHOkECF+chX8Uxvdm3kHrnrDYKwa2zhTKISmfqx0jlSTwXGsH9eiShCr24QZvXR5gnFgpJxFNKlEShgHhdm5dqTWkylzapGJ3x9VBZSlvxctFX4lJb6MHdLH44tl3QhWCZiO+MmgadXkTM4Wzcvfwvc8mMprtokWjzSI8gKf/mMHG6YnVlw+T5XN0kWpVKozhOC1hdDwlW0C";

            // Your MSAL code to obtain an AuthenticationResult object
            //AuthenticationResult authResult = ...;

            // Use the AccessToken to call Microsoft Graph API
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await client.GetAsync("https://graph.microsoft.com/v1.0/me");

            Console.WriteLine(await response.Content.ReadAsStringAsync());
            //var response = await GetUserProfileAsync(accessToken);

            //Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions
            //{
            //    WriteIndented = true
            //}));
        }

        private static async Task<dynamic> GetUserProfileAsync(string accessToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(userProfileUrl);
            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<dynamic>(await response.Content.ReadAsStreamAsync());
        }
    }
}