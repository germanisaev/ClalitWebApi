

namespace GetPatientInfo.Repository;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddScoped<ICorrelationIdGenerators, CorrelationIdGenerators>();

        return services;
    }
}
