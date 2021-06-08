using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace TTcms.Services.Basket.API
{
    internal class TestHttpResponseTrailersFeature : IHttpResponseTrailersFeature
    {
        public IHeaderDictionary Trailers { get; set; }
    }
}