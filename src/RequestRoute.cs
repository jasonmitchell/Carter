namespace Carter
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    public class RequestRoute
    {
        private readonly string path;
        private readonly Dictionary<(string verb, string path), RequestDelegate> routes;

        internal RequestRoute(string path, Dictionary<(string verb, string path), RequestDelegate> routes)
        {
            this.path = path;
            this.routes = routes;
        }
        
        public void Get(RequestDelegate handler)
        {
            this.routes.Add((HttpMethods.Get, this.path), handler);
            this.routes.Add((HttpMethods.Head, this.path), handler);
        }
    }
}
