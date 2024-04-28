namespace WithMinimallAPIs.Endpoints.Configuration;

public interface IEndpoints
{
    /// <summary>
    /// Add the endpoint definitions
    /// </summary>
    public static abstract void DefineEndpoints(IEndpointRouteBuilder app);

    /// <summary>
    /// Add services related to endpoints
    /// </summary>
    public static abstract void AddServices(IServiceCollection services);
}
