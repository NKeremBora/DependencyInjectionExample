namespace DependencyInjectionExample.DependencyInjection;

public class DiServiceCollection
{
    private Dictionary<Type, ServiceDescriptor> _serviceDescriptors = new();
    
    public void Singleton<TService, TImplementation>()
    {
        var typeService = typeof(TService);
        var typeImplementation = typeof(TImplementation);
        _serviceDescriptors[typeService] = new ServiceDescriptor(typeImplementation, ServiceLifetime.Singleton);
    }
    public void Scoped<TService, TImplementation>()
    {
        var typeService = typeof(TService);
        var typeImplementation = typeof(TImplementation);
        _serviceDescriptors[typeService] = new ServiceDescriptor(typeImplementation, ServiceLifetime.Scoped);
    }
    public void Transient<TService, TImplementation>()
    {
        var typeService = typeof(TService);
        var typeImplementation = typeof(TImplementation);
        _serviceDescriptors[typeService] = new ServiceDescriptor(typeImplementation, ServiceLifetime.Transient);
    }
    

    public DiContainer GenerateContainer()
    {
        return new DiContainer(_serviceDescriptors);
    }
}