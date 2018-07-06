namespace Carter.Tests
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class RequestRouteModule : CarterModule
    {
        public RequestRouteModule()
        {
            this.Route("/requestroute")
                .Pipe(ctx =>
                {
                    return Task.CompletedTask;
                })
                .Pipe(ctx =>
                {
                    return Task.CompletedTask;
                })
                .Get(async ctx =>
                {
                    await ctx.Response.WriteAsync("Hello");
                });
        }
    }
}
