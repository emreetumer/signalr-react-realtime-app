using Microsoft.AspNetCore.SignalR;

namespace SignalRLearning.API.Hubs;

// Hub sınıfından miras alıyoruz. Bu, sınıfın SignalR yeteneklerine sahip olmasını sağlar.
public class ProductHub : Hub
{
    // Şu an burası boş kalabilir! 
    // Neden? Çünkü biz mesajı "istemci bir şey yapınca" değil, 
    // "API üzerinden veri değişince" göndereceğiz.

    // İleride buraya "JoinGroup" veya "SendMessage" gibi metotlar yazabilirsin.
    // Amaç sadece veri dinlemekse Hub boş kalabilir.
}
