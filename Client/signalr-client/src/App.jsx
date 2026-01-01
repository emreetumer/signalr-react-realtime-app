import { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';
import axios from 'axios';

function App() {
  const [products, setProducts] = useState([]);
  const [connection, setConnection] = useState(null);

  // API URL'in (Backend çalıştığında launchSettings.json'dan portuna bak, örn: 5001)
  const API_URL = "http://localhost:5239/api/products";
  const HUB_URL = "http://localhost:5239/productHub";

  // 1. Sayfa açılınca mevcut veriyi çek
  useEffect(() => {
    axios.get(API_URL).then(res => setProducts(res.data));
  }, []);

  // 2. SignalR Bağlantısını Kur
  useEffect(() => {
    const newConnection = new signalR.HubConnectionBuilder()
      .withUrl(HUB_URL)
      .withAutomaticReconnect() // Bağlantı koparsa tekrar dene
      .build();

    setConnection(newConnection);
  }, []);

  // 3. Bağlantı varsa Başlat ve Dinlemeye Geç
  useEffect(() => {
    if (connection) {
      connection.start()
        .then(() => {
          console.log("SignalR Bağlandı! 🟢");

          // BACKEND'DEN GELEN MESAJI DİNLE
          // Controller'da "ReceiveProductUpdate" ismini vermiştik.
          connection.on("ReceiveProductUpdate", (updatedProduct) => {
            console.log("Fiyat Değişti!", updatedProduct);

            // State'i güncelle (Sayfayı yenilemeden fiyat değişir)
            setProducts(currentProducts =>
              currentProducts.map(p =>
                p.id === updatedProduct.id ? updatedProduct : p
              )
            );
          });
        })
        .catch(e => console.log("Bağlantı hatası: ", e));
    }
  }, [connection]);

  // Fiyat Güncelleme Fonksiyonu (Test için)
  const updatePrice = async (id, currentPrice) => {
    const newPrice = currentPrice + 100; // Her basışta 100 TL ekle
    await axios.put(`${API_URL}/${id}`, newPrice, {
      headers: { 'Content-Type': 'application/json' }
    });
    // Burada setState yapmıyoruz! SignalR'dan haber gelince state güncellenecek.
  };

  return (
    <div style={{ padding: '50px' }}>
      <h1>Canlı Ürün Fiyatları (SignalR)</h1>
      <div style={{ display: 'grid', gap: '10px' }}>
        {products.map(p => (
          <div key={p.id} style={{ border: '1px solid #ccc', padding: '10px', display: 'flex', justifyContent: 'space-between', width: '300px' }}>
            <span>{p.name}</span>
            <strong style={{ color: 'green' }}>{p.price} TL</strong>
            <button onClick={() => updatePrice(p.id, p.price)}>Fiyat Artır (+100)</button>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;