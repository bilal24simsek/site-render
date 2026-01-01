# BIAnalytics 1.3.0 – Table Chart Geliştirmeleri

BIAnalytics 1.3.0 sürümü, özellikle **Table Chart** kullanan
kurumsal raporlar için kapsamlı görsel, fonksiyonel ve
performans odaklı geliştirmeler içermektedir.

Bu sürüm ile birlikte tablo bazlı raporlar;
daha okunabilir, daha esnek ve çok büyük veri setleriyle
çalışabilir hale gelmiştir.

---

## 🎯 Öne Çıkan Yenilikler

- Tekrarlayan satırlar için **Row Grouping**
- Sütun bazlı **otomatik toplam (Columns Total)**
- **Yatay (Reverse) tablo görünümü**
- Çok seviyeli başlık ve header yapıları
- Büyük veri setleri için **Pagination (Sayfalama)**
- Excel export ile birebir görsel uyum

---

## 📊 Row Grouping (Tekrarlayan Satır Gruplama)

Bu özellik, tablo içerisinde **birbirini tekrar eden satırların**
gruplanarak daha sade ve okunabilir bir yapı sunmasını sağlar.

### Özellik Detayları

- Aynı değerlere sahip satırlar:
  - Tek satır
  - Tek hücre
  şeklinde gruplanabilir
- Gruplanan satırlar dashboard üzerinde
  daha kompakt bir görünüm sunar
- Aynı gruplama yapısı **Excel export çıktısına**
  birebir yansıtılır

### Kazanımlar

- Uzun ve tekrarlı tabloların okunabilirliği artar
- Raporlama ekranları sadeleşir
- Excel çıktıları sunum ve paylaşım için uygun hale gelir

---

## ➕ Columns Total (Otomatik Sütun Toplamları)

Bu sürüm ile birlikte istenilen kolonlar için
**otomatik toplam (total) satırı** eklenebilmiştir.

### Özellik Detayları

- Kullanıcı, hangi sütunların toplanacağını belirleyebilir
- Toplamlar tablonun en altında
  **ayrı bir total satırı** olarak gösterilir
- Sayısal kolonlar otomatik hesaplanır
- Aynı toplam satırı **Excel çıktısında da**
  birebir yer alır

---

## 🔄 Reverse Table (Yatay Tablo Görünümü)

Bazı raporlama senaryolarında,
satır ve kolonların yer değiştirmesi gerekebilmektedir.

### Özellik Detayları

- Table chart’lar **yatay (transpose)** formatta görüntülenebilir
- Satırlar kolon, kolonlar satır olarak gösterilebilir
- Bu yapı özellikle:
  - Karşılaştırmalı raporlar
  - Dönem bazlı analizler
  için tercih edilmektedir
- Reverse table yapısı **Excel export’ta da**
  aynı şekilde uygulanır

---

## 🏷️ Header Add (Tablo Üst Başlıkları)

Bu sürümde tablo chart’ların üzerine
**özel başlık (header)** eklenebilmesi sağlanmıştır.

### Özellik Detayları

- Table chart’a özel başlık tanımlanabilir
- Başlıklar:
  - Açıklama
  - Rapor adı
  - Özet bilgi
  içerecek şekilde kullanılabilir
- Tanımlanan header’lar
  **Excel çıktısında da** aynı konumda yer alır

---

## 🧩 Groups Header (Çok Seviyeli Başlık Grupları)

Bu özellik sayesinde tablo kolon başlıklarında
**bir veya birden fazla seviyede gruplama**
yapılabilmektedir.

### Özellik Detayları

- Kolon başlıkları üst başlıklar altında gruplanabilir
- Çok seviyeli header yapısı desteklenir
- Karmaşık tablolarda:
  - Anlam bütünlüğü korunur
  - Görsel hiyerarşi sağlanır
- Grup başlıkları **Excel export’ta**
  birebir korunur

---

## 📄 Pagination (Sayfalama Desteği)

Bu sürümün **en kritik ve performans odaklı özelliği**
sayfalama (pagination) altyapısıdır.

### Özellik Detayları

- Table chart’lar sayfalı şekilde görüntülenebilir
- Kullanıcı:
  - Toplam kaç sayfa olacağını
  - Bir sayfada kaç satır gösterileceğini
  belirleyebilir
- Dashboard ilk yüklendiğinde
  **sadece ilk sayfa** verisi çekilir
- Diğer sayfalar:
  - Kullanıcı tıkladıkça
  - İhtiyaç anında
  backend’den getirilir

### Performans Kazanımı

- Çok büyük veri setleri (örneğin **yüz milyonlarca satır**)
  dashboard ekranında görüntülenebilir
- Bellek tüketimi minimize edilir
- Dashboard açılış süreleri ciddi oranda düşer
- 500 milyon satırlık tablolar dahi
  pratik şekilde analiz edilebilir

---

## 🐞 İyileştirmeler ve Fixler

- Pivot Table export ile dashboard görünümü
  arasındaki uyumsuzluk giderildi
- Çok kolonlu tabloların
  Excel’de bozulmasına neden olan sorunlar çözüldü
- Header ve grouping kombinasyonlarında
  oluşan hizalama problemleri giderildi
- Pagination aktifken
  filtre değişimlerinde yaşanan senkronizasyon
  sorunları düzeltildi

---

BIAnalytics 1.3.0, Table Chart’ları
sadece bir görselleştirme aracı olmaktan çıkararak,
**yüksek hacimli kurumsal veri analizleri**
için güçlü ve ölçeklenebilir bir raporlama bileşeni
haline getirmiştir.
