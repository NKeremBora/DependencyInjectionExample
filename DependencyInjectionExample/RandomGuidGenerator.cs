namespace DependencyInjectionExample;

public interface IService
{
    public void PrintSomething();
}

public interface ISingletonService: IService
{
}
public interface IScopedService: IService
{
}
public interface ITransientService: IService
{
}

public interface ICtorService : IService
{
    
}

public abstract class RandomGuidGenerator
{
    public Guid RandomGuid { get; set; } = Guid.NewGuid();

    public abstract void PrintSomething();
}
public class RandomGuidGeneratorSingleton: RandomGuidGenerator, ISingletonService
{
    public override void PrintSomething()
    {
        Console.WriteLine($"Singleton Random Guid: {RandomGuid}");
    }
}

public class RandomGuidGeneratorScoped: RandomGuidGenerator, IScopedService
{
    public override void PrintSomething()
    {
        Console.WriteLine($"Scoped Random Guid: {RandomGuid}");
    }
}
public class RandomGuidGeneratorTransient: RandomGuidGenerator, ITransientService
{
    public override void PrintSomething()
    {
        Console.WriteLine($"Transient Random Guid: {RandomGuid}");
    }
}

public class RandomGuidGeneratorCtor(ISingletonService singleton) : RandomGuidGenerator, ICtorService
{
    public override void PrintSomething()
    {
        singleton.PrintSomething();
    }
}