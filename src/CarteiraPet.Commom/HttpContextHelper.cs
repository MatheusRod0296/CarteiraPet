using Microsoft.AspNetCore.Http;

namespace CarteiraPet.Commom
{
    public static class HttpContextHelper
    {
        public static HttpContext _httpContext => new HttpContextAccessor().HttpContext;
    }
}