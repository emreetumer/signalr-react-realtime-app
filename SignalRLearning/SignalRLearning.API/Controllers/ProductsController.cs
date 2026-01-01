using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRLearning.API.Data;
using SignalRLearning.API.Hubs;

namespace SignalRLearning.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    // DİKKAT: Hub'ı Controller içinde kullanmak için IHubContext arayüzünü inject ediyoruz.
    private readonly IHubContext<ProductHub> _hubContext;

    public ProductsController(AppDbContext context, IHubContext<ProductHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _context.Products.ToListAsync());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePrice(int id, [FromBody] decimal newPrice)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        // 1. Veritabanını güncelle
        product.Price = newPrice;
        await _context.SaveChangesAsync();

        // 2. SİGNALR İLE HERKESE HABER VER (MAGIC HAPPENS HERE)
        // Clients.All: Bağlı olan herkese gönder.
        // "ReceiveProductUpdate": React tarafında dinleyeceğimiz fonksiyon adı (buna biz karar verdik).
        await _hubContext.Clients.All.SendAsync("ReceiveProductUpdate", product);

        return Ok(product);
    }
}
