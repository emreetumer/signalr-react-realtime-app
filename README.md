# 📡 SignalR Real-Time Projesi (.NET 9 & React 19)

Bu proje, **.NET 9 Web API** ve **React 19 (Vite)** mimarisi kullanılarak geliştirilmiş, **SignalR** teknolojisi ile gerçek zamanlı veri iletişimini (Server-Push) modern bir yaklaşımla ele alan bir öğrenme ve uygulama projesidir.

Projenin temel amacı, klasik "polling" (istemcinin sürekli sorması) yöntemi yerine, sunucu tarafında veri değiştiğinde (API tetiklendiğinde) bağlı olan tüm istemcilerin anlık olarak haberdar edilmesini sağlayan yapıyı kurmaktır.

---

## 🚀 Öne Çıkan Özellikler

*   **Güncel Teknoloji Yığını:** En son sürüm .NET 9 ve React 19 ile geliştirildi.
*   **Gerçek Zamanlı İletişim:** SignalR Hub mimarisi ile WebSocket tabanlı anlık veri akışı.
*   **API Entegrasyonu:** Controller seviyesinden `IHubContext` kullanarak Hub dışından bildirim gönderme yeteneği.
*   **Modern Frontend:** Vite ile ışık hızında derleme ve geliştirme ortamı.
*   **Temiz Mimari:** Backend ve Frontend projeleri ayrıştırılmış, modüler yapı.

---

## 🛠️ Teknoloji Yığını (Tech Stack)

### Backend (Sunucu Tarafı)
*   **Framework:** .NET 9 (ASP.NET Core Web API)
*   **Real-Time:** Microsoft.AspNetCore.SignalR
*   **Veritabanı Erişimi:** Entity Framework Core 9
*   **Veritabanı:** SQL Server (MsSQL)
*   **Dokümantasyon:** Swagger / OpenAPI

### Frontend (İstemci Tarafı)
*   **Çatı (Framework):** React 19
*   **Derleyici (Bundler):** Vite
*   **HTTP İstekleri:** Axios
*   **SignalR İstemcisi:** @microsoft/signalr
*   **Dil:** JavaScript (ES Modules) / TypeScript uyumlu yapı

---

## 📂 Proje Yapısı

```
root/
├── 📁 Client/
│   └── 📁 signalr-client    # React Frontend Uygulaması
├── 📁 SignalRLearning/
│   └── 📁 SignalRLearning.API  # .NET Backend Uygulaması
└── 📄 README.md             # Proje Dokümantasyonu
```

---

## ⚙️ Kurulum ve Çalıştırma

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları takip edebilirsiniz.

### Ön Gereksinimler
*   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
*   [Node.js](https://nodejs.org/) (LTS sürümü önerilir)
*   SQL Server veya LocalDB

### 1️⃣ Backend Kurulumu (.NET API)

1.  Terminalde API klasörüne gidin:
    ```bash
    cd SignalRLearning/SignalRLearning.API
    ```
2.  Gerekiyorsa `appsettings.json` dosyasındaki veritabanı bağlantı cümlesini (connection string) düzenleyin.
3.  Veritabanını oluşturun ve güncelleyin:
    ```bash
    dotnet ef database update
    ```
4.  Projeyi ayağa kaldırın:
    ```bash
    dotnet run
    ```
    *API muhtemelen `https://localhost:7193` adresinde çalışacaktır.*

### 2️⃣ Frontend Kurulumu (React)

1.  Yeni bir terminal sekmesinde Client klasörüne gidin:
    ```bash
    cd Client/signalr-client
    ```
2.  Bağımlılıkları yükleyin:
    ```bash
    npm install
    ```
3.  Uygulamayı başlatın:
    ```bash
    npm run dev
    ```
    *Tarayıcınızda `http://localhost:5173` (veya terminalde belirtilen port) adresine gidin.*

---

## 🤝 Katkıda Bulunma

1.  Bu repoyu Forklayın.
2.  Kendi özelliğiniz için bir dal (branch) oluşturun (`git checkout -b ozellik/YeniOzellik`).
3.  Değişikliklerinizi commit yapın (`git commit -m 'Yeni süper özellik eklendi'`).
4.  Branch'inizi Pushlayın (`git push origin ozellik/YeniOzellik`).
5.  Bir Pull Request (PR) açın.

