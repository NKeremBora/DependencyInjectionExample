namespace DependencyInjectionExample.DependencyInjection;

public class DiContainer(Dictionary<Type, ServiceDescriptor> serviceDescriptors)
{
    private readonly Dictionary<Type, object> _scopedInstances = new();
    public T? GetService<T>()
    {
        var type = typeof(T);

        if (!serviceDescriptors.TryGetValue(type, out var descriptor))
        {
            throw new Exception($"No service registered for type {type.Name}");
        }

        if (descriptor.ServiceType == null)
        {
            throw new Exception($"No service registered for type {type.Name}");
        }

        switch (descriptor.LifeTime)
        {
            case ServiceLifetime.Singleton:
            {
                descriptor.Instance ??= CreateInstance(descriptor.ServiceType);
                return (T)descriptor.Instance;
            }

            case ServiceLifetime.Transient:
            {
                return (T)CreateInstance(descriptor.ServiceType);
            }

            case ServiceLifetime.Scoped:
            {
                if (_scopedInstances.TryGetValue(type, out var instance)) return (T)instance;
                instance = CreateInstance(descriptor.ServiceType);
                _scopedInstances[type] = instance;
                return (T)instance;
            }

            default:
                throw new Exception($"Unsupported service lifetime: {descriptor.LifeTime}");
        }
    }

    private object CreateInstance(Type type)
    {
        var constructor = type.GetConstructors().FirstOrDefault();

        if (constructor == null || constructor.GetParameters().Length == 0)
        {
            return Activator.CreateInstance(type)
                   ?? throw new Exception($"Unable to create instance of type {type.Name}.");
        }

        var parameters = constructor
            .GetParameters()
            .Select(p => ResolveService(p.ParameterType))
            .ToArray();

        return constructor.Invoke(parameters);
    }
    private object ResolveService(Type serviceType)
    {
        var method = GetType().GetMethod(nameof(GetService));
        var genericMethod = method?.MakeGenericMethod(serviceType);

        if (genericMethod == null)
        {
            throw new Exception($"Cannot resolve service for type {serviceType.Name}");
        }

        return genericMethod.Invoke(this, null)!;
    }
}