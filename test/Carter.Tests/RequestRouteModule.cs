namespace Carter.Tests
{
    using Microsoft.AspNetCore.Http;

    public class RequestRouteModule : CarterModule
    {
        public RequestRouteModule()
        {
            this.Route("/requestroute")
                .Get(async ctx => { await ctx.Response.WriteAsync("Hello"); });
        }
    }
}
