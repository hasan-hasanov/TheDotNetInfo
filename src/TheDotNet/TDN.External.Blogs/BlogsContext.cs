namespace TDN.External.Blogs
{
    public class BlogsContext
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogsContext(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HttpClient CreateClient(string blogUrl)
        {
            return _httpClientFactory.CreateClient(blogUrl);
        }
    }
}
