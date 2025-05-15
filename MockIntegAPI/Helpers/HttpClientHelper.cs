namespace MockIntegAPI.Helpers
{
    public static class HttpClientHelper
    {
        public static HttpClient Create(IHttpClientFactory httpClientFactory)
        {
            return httpClientFactory.CreateClient();
        }
    }
}
