# BIAnalytics 1.1.0 – Dashboard Export (v1)

Bu sürüm ile BIAnalytics, kurumsal raporlama süreçlerinin
en kritik ihtiyaçlarından biri olan **Excel export** yeteneklerini
ilk kez ürün seviyesinde sunmaktadır.

Dashboard üzerinde oluşturulan raporların;
- **Veri içeriği**
- **Görsel düzeni**
- **Kolon yapısı**
- **Filtre sonuçları**

Excel çıktısına **birebir ve tutarlı** şekilde yansıtılması
hedeflenmiştir.

---

## 🎯 Yeni Özellikler

### Dashboard Export (v1)

Bu sürümle birlikte dashboard içerisindeki raporlar,
**tek bir Excel dosyası** olarak indirilebilir hale gelmiştir.

- Dashboard üzerinde yer alan tüm **Table chart’lar**
  otomatik olarak algılanır
- Her chart, Excel dosyasında **ayrı bir sheet** olarak oluşturulur
- Sheet isimleri, dashboard üzerindeki chart başlıkları ile uyumludur
- Dashboard seviyesinde uygulanan filtreler,
  export sırasında otomatik olarak dikkate alınır
- Excel çıktısında:
  - Kolon sıraları
  - Kolon başlıkları
  - Sayısal formatlar
  - Boş/null alanlar  
  rapor görünümü ile uyumlu şekilde oluşturulur

---

### Excel Uyumlu Veri ve Tasarım

Rapor çıktısının Excel üzerinde **okunabilir ve kullanılabilir**
olması amacıyla aşağıdaki geliştirmeler yapılmıştır:

- Dashboard’taki tablo görünümü,
  Excel sheet yapısına birebir yansıtılmıştır
- Kolon başlıkları Excel standardına uygun şekilde işlenmiştir
- Uzun metinler ve geniş kolonlar için otomatik genişlik ayarlamaları eklenmiştir
- Sayısal alanlar, Excel formülleri ve toplam hesaplarıyla uyumlu formatlanmıştır

Bu sayede, export edilen dosyalar ek bir manuel düzenleme
gerektirmeden doğrudan kullanılabilir hale gelmiştir.

---

### Çoklu Chart Desteği

Dashboard üzerinde birden fazla tablo içeren raporlar için:

- Tüm tablolar **tek bir Excel dosyası** içerisinde toplanır
- Her tablo, kendi içeriğini ve filtrelenmiş sonucunu korur
- Büyük dashboard’larda dahi tek dosya üzerinden
  merkezi raporlama sağlanır

Bu yapı, özellikle aylık/yıllık raporlama senaryolarında
manuel export ihtiyacını ortadan kaldırır.

---

## ⚙️ Teknik Detaylar

### Excel Export Altyapısı

- Excel export işlemleri için `excel.py` modülü geliştirilmiştir
- Modül içerisinde:
  - Veri hazırlama
  - Sheet oluşturma
  - Formatlama
  - Streaming write
  işlemleri ayrı fonksiyonlar halinde yapılandırılmıştır
- Büyük veri setleri için bellek kullanımını minimize eden
  **streaming yazma** yaklaşımı uygulanmıştır
- Export işlemleri, Superset Async Query altyapısı ile uyumlu çalışacak şekilde tasarlanmıştır

---

## ⚙️ Teknik Gereksinimler

- Python paketi: `openpyxl`
- Superset Async Query altyapısı
- Yeterli bellek ve disk alanı (büyük dashboard’lar için)

---

## 🐞 Düzeltmeler (Fixler)

- Büyük ve çok sayıda tablo içeren dashboard’larda
  export sırasında oluşan **timeout problemleri giderildi**
- Boş veya veri içermeyen dataset’lerin
  export sırasında hata üretmesi engellendi
- Excel dosyasında:
  - Eksik sheet oluşması
  - Yanlış kolon eşleşmesi
  gibi tutarsızlıklar giderildi

---

## 📌 Notlar

- Bu sürüm, Excel export yeteneklerinin
  **ilk ürünleşmiş versiyonudur**
- Sonraki sürümlerde:
  - Seçilebilir chart export
  - CSV ve PDF entegrasyonları
  gibi gelişmiş özellikler eklenmiştir
