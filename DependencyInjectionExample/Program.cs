using DependencyInjectionExample;
using DependencyInjectionExample.DependencyInjection;


var services = new DiServiceCollection();
services.Singleton<ISingletonService,RandomGuidGeneratorSingleton>();
services.Scoped<IScopedService,RandomGuidGeneratorScoped>();
services.Transient<ITransientService,RandomGuidGeneratorTransient>();

services.Transient<ICtorService,RandomGuidGeneratorCtor>();

var container = services.GenerateContainer();
var container2 = services.GenerateContainer();


var singletonServiceFirst = container.GetService<ISingletonService>();
var singletonServiceSecond = container.GetService<ISingletonService>();
var singletonServiceThird = container2.GetService<ISingletonService>();

var scopedServiceFirst = container.GetService<IScopedService>();
var scopedServiceSecond = container.GetService<IScopedService>();
var scopedServiceThird = container2.GetService<IScopedService>();

var transientServiceFirst = container.GetService<ITransientService>();
var transientServiceSecond = container.GetService<ITransientService>();
var transientServiceThird = container2.GetService<ITransientService>();

var ctorServiceFirst = container.GetService<ICtorService>();

singletonServiceFirst?.PrintSomething();
singletonServiceSecond?.PrintSomething();
singletonServiceThird?.PrintSomething();
ctorServiceFirst?.PrintSomething();

Console.WriteLine();
scopedServiceFirst?.PrintSomething();
scopedServiceSecond?.PrintSomething();
scopedServiceThird?.PrintSomething();

Console.WriteLine();
transientServiceFirst?.PrintSomething();
transientServiceSecond?.PrintSomething();
transientServiceThird?.PrintSomething();
