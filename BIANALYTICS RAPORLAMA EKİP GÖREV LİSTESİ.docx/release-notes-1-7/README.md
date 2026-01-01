# BIAnalytics 1.7.0 – Refresh & Scheduling

BIAnalytics 1.7.0 sürümü, dashboard’ların
**yenilenme (refresh) ve cache yönetimi**
konularını kurumsal ölçekte ele alan
önemli bir stabilizasyon ve kontrol sürümüdür.

Bu sürüm ile birlikte otomatik refresh mekanizmaları
daha kararlı hale getirilmiş ve
kullanıcılara **zamanlama üzerinde tam kontrol**
sağlanmıştır.

---

## 🎯 Öne Çıkan Yenilikler

- Otomatik refresh stabilizasyonu
- Cron bazlı refresh interval desteği
- Saat / tarih bazlı dashboard yenileme
- Cache yenileme süreçlerinde kontrol ve öngörülebilirlik

---

## 🔄 Otomatik Refresh Stabilizasyonu

Bu sürüm ile birlikte dashboard’ların
belirli periyotlarla otomatik olarak
yenilenmesi ve cache’e kaydedilmesi
stabil hale getirilmiştir.

### Özellik Detayları

- Dashboard’lar:
  - Tanımlı periyotlarda
  - Otomatik olarak refresh edilir
- Refresh işlemi sonrası:
  - Güncel dashboard verisi
  - Redis cache’e kaydedilir
- Kullanıcılar dashboard’u açtığında:
  - En son yenilenmiş
  - Hazır cache üzerinden
  hızlıca görüntüler

### Kazanımlar

- Kullanıcılar manuel refresh ihtiyacı duymadan
  güncel verilere erişir
- Cache her zaman kontrollü şekilde güncel tutulur
- Yoğun kullanılan dashboard’larda
  performans ve tutarlılık sağlanır

---

## ⏱️ Cron Bazlı Refresh Interval

Bu sürüm ile dashboard cache yenileme mekanizması,
**kullanıcı tarafından tanımlanabilir**
hale getirilmiştir.

### Özellik Detayları

- Kullanıcılar dashboard için:
  - Cron formatında
  - Saat, gün, tarih bazlı
  yenileme tanımı yapabilir
- Örnek senaryolar:
  - Her gün saat 09:00’da yenile
  - Haftada bir pazartesi yenile
  - Ayın ilk günü cache’i güncelle
- Cron tanımı sayesinde:
  - İş saatleri dışında
  - Sistem yükü düşükken
  refresh işlemleri yapılabilir

### Kazanımlar

- Cache yenileme tamamen kontrol altına alınır
- Gereksiz refresh ve sorgu çalışmaları engellenir
- Kurumsal planlama ve operasyon süreçleriyle
  uyumlu bir yapı sağlanır

---

## 📅 Saat / Tarih Bazlı Yenileme

Cron bazlı yapı sayesinde:

- Sadece periyot değil
- **Belirli tarih ve saatler**
  için de refresh planlaması yapılabilir
- Özel raporlama dönemleri için
  (ay sonu, çeyrek kapanışı vb.)
  hedefli cache yenileme mümkündür

---

## 🐞 İyileştirmeler ve Fixler

- Refresh interval ayarlarının
  kendini resetlemesine neden olan
  problem giderildi
- Arka arkaya tetiklenen
  refresh işlemleri engellendi
- Aynı dashboard için
  eş zamanlı refresh çakışmaları çözüldü
- Cache yenileme sırasında
  oluşabilen tutarsız durumlar giderildi

---

BIAnalytics 1.7.0 sürümü ile birlikte platform,
dashboard yenileme ve cache yönetimi konusunda
**öngörülebilir, kontrollü ve kurumsal**
bir yapıya kavuşmuştur.
