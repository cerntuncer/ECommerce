## 📊 Veri Tabanı Şeması (Database Schema - ERD)

Bu diyagram, **.NET Core ve Yapay Zeka (NLP)** entegrasyonlu e-ticaret tasarım projemizin temelini oluşturan veri modelini göstermektedir. Projenin ana odak noktası, klasik e-ticaret işlevlerini desteklerken, Yapay Zeka (AI) aracılığıyla yorumların güvenilirliğini sağlamaktır.

### Temel Tablolar ve NLP Odaklı Alanlar

**1. Users (Kullanıcılar):**
* Kullanıcı giriş bilgilerini ve rolleri yönetir.
* **`IsAdmin`**: Yönetici yetkisini belirterek ürün ekleme ve sistem yönetimi yetkisi verir.

**2. Products (Ürünler):**
* Sistemde Admin tarafından listelenen e-ticaret ürünlerini tutar (`Name`, `Price`, `StockQuantity` vb.).
* **`FlagID` (FK):** Ürünün genel durumunu yansıtır (Kırmızı Bayrak/Yeşil Bayrak), tüm yorumların Yapay Zeka analizinden sonra hesaplanır.

**3. Reviews (Yorumlar) - AI'ın Kalbi:**
* Kullanıcıların ürünler hakkında yaptığı yorumları içerir ve projenin NLP bölümünün doğrudan hedefidir.
* **`Content`**: Analiz edilecek metin içeriği.
* **`Rating`**: Kullanıcının verdiği sayısal yıldız değeri (1-5).
* **`NLPSentimentScore`**: Yapay Zeka modelinin yorum metninden çıkardığı duygu skoru.
* **`IsRatingConsistent`**: Yapay Zeka'nın en kritik çıktısı. **Yorum metninin duygusal tonu ile kullanıcının verdiği yıldızın tutarlı olup olmadığını** kontrol eder. (Örn: "Ürün berbat!" yazıp 5 yıldız vermek = Tutarsız/Kırmızı Bayrak sinyali).

**4. Flags (Bayraklar) & Categories (Kategoriler):**
* **Flags:** Kırmızı ve Yeşil Bayrak durumlarını tanımlar.
* **Categories:** Ürünleri gruplamak için kullanılır.

Bu mimari, veriyi sağlam bir şekilde depolarken, özellikle **Yorumlar** tablosu sayesinde güçlü bir Yapay Zeka katmanına olanak sağlamaktadır.
