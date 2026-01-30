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
[Projenin Core sistemini kurmam lazım. IInteractable interface'i ve Raycast ile nesneleri algılayan bir InteractionDetector scripti gerekli.Özellikle `m_` prefix, region sıralaması ve XML dokümantasyon kurallarına %100 uyarak bu temel scriptleri hazırla]
```

**Alınan Cevap (Özet):**
```
[ Asistan  `IInteractable` arayüzünü ve `InteractionDetector` sınıfını hazırladı.
> - Unity methodları ve eventler Region içine alındı.
> - Raycast logic'i `InteractionDetector` içine kuruldu.]
```

**Nasıl Kullandım:**
- [x] Direkt kullandı
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
[Core sistemi kurduk. Şimdi kod tekrarını önlemek için abstract bir BaseInteractable sınıfı oluşturup IInteractable'ı oradan implemente edelim. Sonrasında bunu miras alan basit bir InteractableDoor (aç/kapa mantığı olan) scripti yaz]
```

**Alınan Cevap (Özet):**
```
[ Asistan, BaseInteractable abstract sınıfını oluşturarak ortak field'ları (PromptMessage, IsInteractable) buraya taşıdı. 
Ardından bu sınıftan türeyen ve Update içinde Quaternion.Slerp kullanarak yumuşak açılma/kapanma hareketi yapan InteractableDoor sınıfını hazırladı.]
```

**Nasıl Kullandım:**
- [] Direkt kullandım
- [x] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Her obje için aynı değişkenleri tekrar tekrar yazmamak (DRY prensibi) ve kapı mantığını hızlıca test edebilmek için inheritance yapısını kurdurttum.
Üretilen kodda IInteractable arayüzündeki OnInteract metodunun dönüş tipi (bool) ile implementasyondaki tip (void) arasında bir uyuşmazlık vardı . Bu derleme hatasını gidermek için dönüş tipini düzelttim ve metodu başarı durumunu (true) dönecek şekilde güncelleyerek projeye entegre ettim.]

---

## Prompt 4: [Inventory ve Key System Entegrasyonu]

**Araç:** [Gemini 3 Pro]
**Tarih/Saat:** 2025-01-30 17:20

**Prompt:**
```
[Projeye "Simple Inventory" gereksinimlerini eklememiz gerekiyor. Şunları implemente et:
  Anahtar verilerini tutacak bir KeyDataSO (ScriptableObject).
  Oyuncuda duracak basit bir PlayerInventory scripti.
  Yerden alınabilen InteractableKey sınıfı.
  InteractableDoor scriptini Lock,Unlock mantığını destekleyecek şekilde güncelle.]
```

**Alınan Cevap (Özet):**
```
[ Asistan; ScriptableObject tabanlı anahtar tanımlama sistemini, PlayerInventory yapısını ve InteractableKey sınıfını oluşturdu. Mevcut Door scriptini güncelleyerek `TryUnlock` mekanizmasını ekledi.]
```

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [] Adapte ettim
- [] Reddettim

**Açıklama:**
> [Case'in "Inventory" ve "Key + Locked Door Test" senaryolarını karşılamak için sistemi parçalara bölerek (Data, Logic, Interaction) implemente ettirdim.]

---

## Prompt 5: First Person Controller (Test İçin)

**Araç:** Gemini 3 Pro
**Tarih/Saat:** 2026-01-30 17:25

**Prompt:**
> Testleri yapabilmek için basit bir karakter hareket koduna ihtiyacım var. `CharacterController` kullanan, WASD ile yürüyen ve Mouse ile etrafa bakan basit bir script yaz. Standartlara uygun olsun.

**Alınan Cevap (Özet):**
> Asistan, `SimpleFirstPersonController` isminde, `CharacterController` component'ini kullanan temel bir hareket scripti sağladı. Mouse kilitleme (Cursor Lock) ve kamera rotasyon işlemleri eklendi.

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Case'in ana odak noktası interaction sistemi olduğu için, hareket koduna vakit harcamamak adına hazır ve temiz bir çözüm istedim.

---

## Prompt 6: Hold Interaction (Sandık) Mekaniği

**Araç:** Gemini 3 Pro
**Tarih/Saat:** 2026-01-30 18:00

**Prompt:**
 "Hold" (basılı tutma) etkileşim türünü sisteme entegre etmemiz gerekiyor.
   InteractionType enum'ı oluştur.
  BaseInteractable sınıfına HoldDuration ve Type ekle.
  InteractionDetector scriptini, basılı tutma süresini sayacak ve dolduğunda etkileşimi tetikleyecek şekilde güncelle.
  Bu sistemi kullanan bir InteractableChest scripti yaz (Açıldıktan sonra tekrar kapanmasın).

**Alınan Cevap (Özet):**
> Asistan, Core sistemde gerekli refactor işlemlerini yaparak InteractionDetectora zamanlayıcı mantığı ekledi. Sandık için basılı tutarak açılan ve tek seferlik çalışan bir script sağladı. Ayrıca UI Progress Bar için gerekli event altyapısını kurdu.

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Core sistemi "Instant" ve "Hold" olarak ikiye ayırarak, case'in en önemli gereksinimlerinden birini esnek bir yapıda çözdüm.

---

## Prompt 7: UI Feedback Sistemi (Prompt ve Progress Bar)

**Araç:** Gemini 3 Pro
**Tarih/Saat:** 2026-01-30 19.00

**Prompt:**
 Oyuncuya görsel geri bildirim vermek için bir UI sistemi kurmamız gerekiyor.
   InteractionDetector eventlerini dinleyen bir InteractionUI scripti yaz.
   OnInteractableChanged tetiklenince ekranda "Press E to Open" gibi dinamik bir yazı göster.
   OnInteractionProgress tetiklenince bir Image barını doldur.

**Alınan Cevap (Özet):**
> Asistan, Observer pattern kullanarak dedektörden gelen sinyalleri UI elemanlarına bağlayan InteractionUI scriptini sağladı. SetActive ile paneli gizleyip açan ve fillAmount ile barı dolduran yapı kuruldu.

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Kullanıcı deneyimi (UX) için etkileşim durumlarını görselleştirmek şarttı. Event-based bir yapı ile Detector ve UI kodlarını birbirinden bağımsız tuttum.

---

## Prompt 8: Switch ve Event Sistemi

**Araç:** Gemini 3 Pro
**Tarih/Saat:** 2026-01-30 19.20

**Prompt:**
  Son etkileşilebilir nesne olan Switch için bir script yaz.
  Toggle mantığı ile çalışsın.
  UnityEvent kullanarak başka nesneleri  tetikleyebilsin.
  Görsel olarak bir kolu aşağı yukarı döndürsün.

**Alınan Cevap (Özet):**
> Asistan, InteractableSwitch sınıfını hazırladı. UnityEvent yapısı sayesinde Switch'in ışıkları veya diğer objeleri Inspector üzerinden kontrol edebilmesini sağladı. Ayrıca kol animasyonu için Slerp rotasyonu eklendi.

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Case'in Switch/Lever ve Event-based connection gereksinimlerini karşılamak için UnityEvent sistemini kullanan esnek bir yapı kurdum.

---

## Prompt 9: Bonus Özellikler (Highlight ve SFX)

**Araç:** Gemini 3 Pro
**Tarih/Saat:** 2026-01-30 19.55

**Prompt:**
> Projeye bonus puan getirecek iki özellik ekleyelim:
.  Oyuncu nesneye baktığında  nesnenin rengi değişsin , bakmayı bırakınca  eski rengine dönsün.
   Nesnelerle etkileşime girildiğinde ses çalsın.
 
> Bunun için `IInteractable` arayüzünü güncelle ve `BaseInteractable` sınıfına gerekli düzenlemeyi yap.

**Alınan Cevap (Özet):**
> Asistan, `IInteractable` arayüzüne `OnFocus` ve `OnLoseFocus` metotlarını ekledi. `InteractionDetector` scriptini bu metotları tetikleyecek şekilde güncelledi. `BaseInteractable` sınıfına basit bir renk değiştirme (Highlight) ve ses çalma (`PlaySound`) altyapısı kurdu.

**Nasıl Kullandım:**
- [] Direkt kullandım
- [x] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Kullanıcıya hangi nesneyle etkileşime gireceğini belli etmek  ve eylemi doğrulamak için bonus özellikleri "Base Class" seviyesinde çözdüm. Böylece tüm nesneler otomatik olarak bu özelliklere sahip oldu.Fakat yapay zeka her objeye(Chest,Door vs) birer Audio Source ekleyerek sistemi kurdu."Separation of Concerns" prensibi gereği ses yönetimini nesnelerden ayırıp merkezi bir yöneticiye devrettim. Bu, projenin ölçeklenebilirliğini artırdı. 

**Yapılan Değişiklikler (adapte ettiyseniz):**
> [Her objeye audio source eklemek yerine ses yönetimini ortak bir merkezden yürütmek için AudioManager sınıfını yazdırdım]
---

## Prompt 10: Code Standards Review ve Refactoring

**Araç:** Gemini 3 Pro
**Tarih/Saat:** 2026-01-30 20:20

**Prompt:**
> Projenin kodlarını son kez `CSharp_Coding_Conventions.md` ve diğer Ludu Arts standart dökümanlarına göre denetle. Gözden kaçan "Silent Bypass", "Encapsulation" veya "Naming" hataları varsa tespit et ve düzeltilmiş versiyonlarını sun.

**Alınan Cevap (Özet):**
> Asistan kodları inceledi ve şu düzeltmeleri önerdi:
> 1. `KeyDataSO` içindeki public değişkenler `m_` prefixli private field ve public property yapısına (Encapsulation) çevrildi.
> 2. `InteractionDetector` içindeki "Silent Bypass" (sessiz hata) durumu giderildi; eksik referanslar için `Debug.LogError` eklendi.
> 3. `BaseInteractable` içindeki override metodlara eksik olan XML dokümantasyonları (`<inheritdoc/>`) eklendi.

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Teslim öncesi kod kalitesini artırmak ve şirketin kod standartlarına %100 uyum sağlamak için statik kod analizi yaptırdım ve önerilen kritik düzeltmeleri uyguladım.

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
