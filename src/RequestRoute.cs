namespace Carter
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    public class RequestRoute
    {
        private readonly string path;
        private readonly Dictionary<(string verb, string path), RequestDelegate> routes;
        

        private RequestDelegate pipeline;

        internal RequestRoute(string path, Dictionary<(string verb, string path), RequestDelegate> routes)
        {
            this.path = path;
            this.routes = routes;
        }

        public RequestRoute Pipe(RequestDelegate next)
        {
            if (this.pipeline == null)
            {
                this.pipeline = next;
            }
            else
            {
                var previous = this.pipeline;
                this.pipeline = async ctx =>
                {
                    await previous(ctx);
                    await next(ctx);
                };
            }
            
            return this;
        }
        
        public void Get(RequestDelegate handler)
        {
            this.Pipe(handler);
            this.routes[(HttpMethods.Get, this.path)] = this.pipeline;
            this.routes[(HttpMethods.Head, this.path)] = this.pipeline;
        }
    }
}
