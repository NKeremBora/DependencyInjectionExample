# DependencyInjectionExample

Bu proje, .NET 9 kullanılarak basit bir Dependency Injection (DI) sistemi oluşturmayı amaçlayan bir örnek uygulamadır. Projede, DI kavramını anlamak ve farklı yaşam döngüsü türleri (Singleton, Scoped, Transient) ile çalışma mantığını öğrenmek için bir temel oluşturulmuştur.

## Projenin Amacı

- **DI mekanizmasını anlamak ve uygulamak**: Hizmetlerin yaşam döngülerini yönetmek ve bağımlılıkları çözmek için bir DI sistemi geliştirilmiştir.
- **Farklı yaşam döngüleri**:
  - **Singleton**: Tüm yaşam döngüsü boyunca aynı örneği kullanır.
  - **Scoped**: Her konteyner örneği için bir kez oluşturulur.
  - **Transient**: Her çağrıda yeni bir örnek oluşturulur.
- **Constructor bağımlılıklarının çözümü**: Hizmetlerin ihtiyaç duyduğu bağımlılıkları otomatik olarak çözme yeteneği sağlanmıştır.

## Kullanılan Teknolojiler

- **Dil**: C#
- **Çerçeve**: .NET 9
- **Araçlar**: Visual Studio, .NET CLI

## Katkıda Bulunma

Katkıda bulunmak isterseniz:
- Bir fork oluşturun.
- Yeni bir özellik veya düzeltme (fix) ekleyin.
- Pull Request gönderin.

## Kurulum ve Çalıştırma

1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/NKeremBora/DependencyInjectionExample.git
   cd DependencyInjectionExample

2.	Projeyi derleyin ve çalıştırın
    ```bash
    dotnet build
    dotnet run
