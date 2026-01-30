# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.
> Dürüst ve detaylı dokümantasyon beklenmektedir.

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | X |
| Kullanılan araçlar | ChatGPT / Claude / Copilot |
| En çok yardım alınan konular | [liste] |
| Tahmini LLM ile kazanılan süre | X saat |

---

## Prompt 1: [Konu Başlığı]

**Araç:** [Gemini 3 Pro]
**Tarih/Saat:** 2025-01-30 16:16

**Prompt:**
```
[Staj başvurusu yaptığım bir şirket bana bir case gönderdi. Şimdi seninle birlikte bu case i yapıcaz. 
Fakat bazı kurallar var proje için bir github reposu açıcam PROMPTS.md ve README.md ile açıklama zorunlu.(Dosyalar ekte gönderildi)]
```

**Alınan Cevap (Özet):**
```
[Asistan, gönderilen tüm dokümanları ve Ludu Arts standartlarını analiz etti.
Klasör yapısının şemasını çıkardı (Docs, Scripts/Runtime/Core vb.).
Şirketin 'm_' prefix kuralı ile benim kişisel underscore kullanmama tercihim arasındaki çelişkiyi tespit edip, şirket kurallarına uyulması gerektiğini belirtti.
PROMPTS.md ve README.md dosyalarının ilk taslaklarını oluşturdu.]
```

**Nasıl Kullandım:**
- [x] Direkt kullandım (değişiklik yapmadan)
- [ ] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
> [Projeye başlarken yanlış bir mimari kurmamak ve şirketin katı isimlendirme kurallarını (naming conventions) gözden kaçırmamak için yapay zekadan bir analiz ve yol haritası istedim. Bu sayede klasör yapısını tek seferde doğru kurdum.]

**Yapılan Değişiklikler (adapte ettiyseniz):**
> [LLM cevabını nasıl değiştirdiğinizi açıklayın]

---

## Prompt 2: [Core Interaction Sisteminin Kurulması]

**Araç:** [Gemini 3 Pro]
**Tarih/Saat:** 2025-01-30 16:44

**Prompt:**
```
[Projenin Core sistemini kurmam lazım. `IInteractable` interface'i ve Raycast ile nesneleri algılayan bir `InteractionDetector` scripti gerekli.Özellikle `m_` prefix, region sıralaması ve XML dokümantasyon kurallarına %100 uyarak bu temel scriptleri hazırla]
```

**Alınan Cevap (Özet):**
```
[ Asistan  `IInteractable` arayüzünü ve `InteractionDetector` sınıfını hazırladı.
> - Unity methodları ve eventler Region içine alındı.
> - Raycast logic'i `InteractionDetector` içine kuruldu.]
```

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Temel mimariyi kurarken vakit kaybetmemek ve şirketin katı isimlendirme kurallarında hata yapmamak için standartlara uygun bir boilerplate istedim.]

---

## Prompt 3: [Base Class ve Door Implementasyonu]

**Araç:** [Gemini 3 Pro]
**Tarih/Saat:** 2025-01-30 16:51

**Prompt:**
```
[Core sistemi kurduk. Şimdi kod tekrarını önlemek için abstract bir `BaseInteractable` sınıfı oluşturup `IInteractable`'ı oradan implemente edelim. Sonrasında bunu miras alan basit bir `InteractableDoor` (aç/kapa mantığı olan) scripti yaz]
```

**Alınan Cevap (Özet):**
```
[ Asistan, `BaseInteractable` abstract sınıfını oluşturarak ortak field'ları (PromptMessage, IsInteractable) buraya taşıdı. 
Ardından bu sınıftan türeyen ve `Update` içinde `Quaternion.Slerp` kullanarak yumuşak açılma/kapanma hareketi yapan `InteractableDoor` sınıfını hazırladı.]
```

**Nasıl Kullandım:**
- [] Direkt kullandım
- [x] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Her obje için aynı değişkenleri tekrar tekrar yazmamak (DRY prensibi) ve kapı mantığını hızlıca test edebilmek için inheritance yapısını kurdurttum.
Üretilen kodda `IInteractable` arayüzündeki `OnInteract` metodunun dönüş tipi (`bool`) ile implementasyondaki tip (`void`) arasında bir uyuşmazlık vardı . Bu derleme hatasını gidermek için dönüş tipini düzelttim ve metodu başarı durumunu (`true`) dönecek şekilde güncelleyerek projeye entegre ettim.]

---

## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. [Alan 1]
2. [Alan 2]
3. [Alan 3]

### LLM'in Yetersiz Kaldığı Alanlar
1. [Alan 1 - neden yetersiz kaldığı]
2. [Alan 2]

### LLM Kullanımı Hakkında Düşüncelerim
> [Bu case boyunca LLM kullanarak neler öğrendiniz?
> LLM'siz ne kadar sürede bitirebilirdiniz?
> Gelecekte LLM'i nasıl daha etkili kullanabilirsiniz?]

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
