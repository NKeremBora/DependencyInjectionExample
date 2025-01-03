namespace DependencyInjectionExample.DependencyInjection;

public enum ServiceLifetime
{
    Transient,
    Scoped,
    Singleton
}

public class ServiceDescriptor
{
    public Type? ServiceType { get; set; }
    public object? Instance { get; set; }
    public ServiceLifetime LifeTime { get; set; }

    public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
    {
        ServiceType = serviceType;
        LifeTime = lifetime;
    }
}