# BIAnalytics 1.5.0 – Alerts & Reports (PDF)

BIAnalytics 1.5.0 sürümü ile birlikte platform,
kurumsal raporlama ihtiyaçlarının en önemli bileşenlerinden biri olan
**zamanlanmış raporlar, PDF export ve otomatik e-posta gönderimi**
yeteneklerini kazanmıştır.

Bu sürüm, BIAnalytics’i sadece interaktif bir analiz aracı olmaktan çıkarıp,
**otomatik rapor üreten bir kurumsal raporlama platformu**
haline getirmiştir.

---

## 🎯 Öne Çıkan Yenilikler

- Dashboard PDF export
- E-posta ile otomatik rapor gönderimi
- Çok sekmeli dashboard’lar için tek PDF üretimi
- Yüksek çözünürlüklü PDF render altyapısı

---

## 📄 Dashboard PDF Export

Bu sürüm ile birlikte dashboard’lar
**PDF formatında export** alınabilmektedir.

### Özellik Detayları

- Dashboard ekranı birebir korunarak PDF oluşturulur
- Grafikler, tablolar ve filtreler
  PDF çıktısına yansıtılır
- PDF çıktıları:
  - Sunum
  - Arşivleme
  - E-posta ile paylaşım
  senaryoları için uygundur

---

## ✉️ E-Posta ile Otomatik Gönderim

BIAnalytics 1.5.0 sürümünde
otomatik rapor gönderim altyapısı
önemli ölçüde geliştirilmiştir.

### Yapılan Geliştirmeler

- **Celery Beat** altyapısı güncellenmiştir
- Zamanlanmış görevler daha stabil hale getirilmiştir
- E-posta ile gönderilen PDF’ler:
  - Dashboard’un tamamını kapsayacak şekilde
  - Kırpılma olmadan
  - Orijinal boyutları korunarak
  oluşturulmaktadır

### Seçilebilir İçerik

- Dashboard içerisinde bulunan tab’ler:
  - Tek tek
  - İstenilen kombinasyonlarla
  seçilerek PDF içine eklenebilir
- Kullanıcı, gönderilecek PDF’in
  içeriğini kontrol edebilir

### Görsel Kalite İyileştirmeleri

- PDF içerisindeki grafik ve tabloların
  **çözünürlük kalitesi artırılmıştır**
- Font ve ikon netliği iyileştirilmiştir
- Basılı çıktılar ve yüksek çözünürlüklü ekranlar
  için uygun hale getirilmiştir

### Gelecek Planları

- Aynı altyapı üzerinden:
  - Excel
  - CSV
  formatında raporların da
  e-posta ile gönderilmesi
  planlanmaktadır

---

## 🗂️ Çok Sekmeli Dashboard’lar Tek PDF

BIAnalytics dashboard’ları
bir veya birden fazla sekmeden (tab) oluşabilmektedir.

### Özellik Detayları

- Çok sekmeli dashboard’lar:
  - Tek PDF
  - Seçili tab’lerin birleştirilmesi
  şeklinde export alınabilir
- Her tab PDF içerisinde:
  - Ayrı sayfa
  - Ayrı bölüm
  olarak yer alır
- Büyük dashboard’lar için
  anlamlı ve düzenli PDF çıktıları elde edilir

---

## ⚙️ Teknik Gereksinimler

Bu özelliklerin kullanılabilmesi için
aşağıdaki bileşenlerin yapılandırılmış olması gerekmektedir:

- **Celery** (worker & beat)
- **Redis** (task queue & cache)
- **SMTP yapılandırması**
  (e-posta gönderimi için)

---

## 🐞 İyileştirmeler ve Fixler

- PDF render sırasında oluşan
  font kaymaları giderildi
- Uzun dashboard’larda yaşanan
  sayfa kesilme problemleri çözüldü
- Çok sekmeli dashboard’larda
  PDF sıralama hataları düzeltildi
- Zamanlanmış görevlerde
  nadir görülen tetiklenmeme problemi giderildi

---

BIAnalytics 1.5.0 sürümü ile birlikte platform,
**otomatik, zamanlanmış ve paylaşılabilir raporlar**
üreten tam kapsamlı bir
kurumsal BI çözümüne dönüşmüştür.
