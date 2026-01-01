# BIAnalytics 1.2.0 – Gelişmiş Export Yetenekleri

BIAnalytics 1.2.0 sürümü, platformun **veri dışa aktarma (export)**
kabiliyetlerini önemli ölçüde genişletmiştir.

Bu sürüm ile birlikte kullanıcılar;
dashboard seviyesinde daha esnek Excel export alabilir,
chart bazında **tam veri (full data) CSV export** işlemlerini
kontrollü ve performanslı şekilde gerçekleştirebilir.

---

## 🎯 Öne Çıkan Yenilikler

- Seçilebilir chart bazlı Excel export
- Dataset’in tamamını kapsayan Full Data CSV export
- Kullanıcı kontrollü kolon, metric ve limit seçimi
- Büyük veri setleri için optimize edilmiş export altyapısı

---

## 📊 Dashboard Export (v2 – Seçilebilir Grafikler)

Bu özellik, dashboard içerisinde yer alan chart’ların
**ayrı ayrı veya seçilerek** export alınabilmesi amacıyla geliştirilmiştir.

### Özellik Detayları

- Dashboard’a özel geliştirilen **yeni bir export bileşeni**
  (custom component) kullanılmıştır
- Kullanıcılar dashboard üzerindeki:
  - Tek bir chart
  - Birden fazla chart
  - Seçilen chart grupları
  için Excel export alabilir
- Her seçilen chart, Excel dosyasında
  **ayrı bir sheet** olarak oluşturulur
- Dashboard üzerindeki aktif filtreler
  export edilen tüm chart’lara birebir uygulanır

### Kazanımlar

- Büyük ve kompleks dashboard’larda
  sadece ihtiyaç duyulan verilerin dışa aktarılması
- Tek Excel dosyasında, çoklu chart çıktısı
- Kullanıcı deneyiminde ciddi iyileşme

---

## 📄 Full Data CSV Export

Bu özellik ile birlikte BIAnalytics,
standart chart export sınırlarının ötesine geçmiştir.

Chart üzerinde **gösterilmeyen** ancak dataset içerisinde
tanımlı olan tüm alanlar export edilebilir hale gelmiştir.

### Özellik Detayları

- Chart’ların sağ üst menüsüne
  **“Full Data CSV Export”** seçeneği eklenmiştir
- Export işlemi, chart’ın beslendiği
  **dataset bazlı** çalışır
- Aşağıdaki alanlar export edilebilir:
  - Dataset’te tanımlı tüm kolonlar
  - Calculated (hesaplanmış) kolonlar
  - Metric’ler (kullanılsın veya kullanılmasın)
- Kullanıcılar:
  - Export edilecek kolonları seçebilir
  - Metric ve calculated kolonları dahil edebilir
  - Satır limiti belirleyebilir
  - İsterse **tam veri (limitsiz)** export alabilir

### Kullanım Senaryosu

Bu yapı sayesinde kullanıcılar:
- Dashboard’ta özet olarak gördükleri verinin
  **ham ve detaylı halini**
- Analiz, arşivleme veya harici sistemlere aktarma
  amacıyla CSV formatında alabilir

---

## ⚙️ Teknik Altyapı ve Gereksinimler

Bu sürümde export işlemleri için aşağıdaki
teknik iyileştirmeler yapılmıştır:

- `pandas` – veri işleme ve kolon yönetimi
- `pyarrow` – yüksek performanslı veri aktarımı
- **Stream-based CSV writer**
  - Büyük veri setlerinde bellek kullanımını minimize eder
  - Uzun süren export işlemlerinde stabilite sağlar

---

## 🐞 İyileştirmeler ve Fixler

- Büyük hacimli CSV export işlemlerinde
  oluşan **memory leak** problemi giderildi
- UTF-8 encoding iyileştirmeleri yapılarak
  **Türkçe karakter sorunları** çözüldü
- Uzun süren export işlemlerinde
  timeout ve bağlantı kopma problemleri azaltıldı

---

BIAnalytics 1.2.0, platformu yalnızca
bir dashboard aracı olmaktan çıkararak,
**kurumsal veri dışa aktarma ve analiz ihtiyaçlarına**
doğrudan cevap veren bir BI çözümü haline getirmiştir.
