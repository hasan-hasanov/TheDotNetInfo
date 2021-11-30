namespace TDNI.External.Blogs
{
    public class HttpContext
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpContext(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HttpClient CreateClient(string blogUrl)
        {
            return _httpClientFactory.CreateClient(blogUrl);
        }
    }
}
