# Interaction System - [ENES ERAY AKSOY]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.3.0f1 |
| Render Pipeline |  URP |
| Case Süresi | 6 saat |
| Tamamlanma Oranı | %100 |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/enesaksoy250/Ludu-Arts-Case.git
```

2. Unity Hub'da projeyi açın
3. `Assets/Ludu-Arts-Case/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |
| [Diğer] | [Açıklama] |

### Test Senaryoları

1. **Door Test:**
   - Kapıya yaklaşın, ekranda "Open Door" yazısını görün.
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın, "Locked - Key Required" mesajını görün
   - Sahnedeki Kırmızı Anahtarı (Küre) bulun ve E ile toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

3. **Switch Test:**
   - Switch'e yaklaşın ve aktive edin
   - Bağlı nesnenin (kapı/ışık vb.) tetiklendiğini görün

4. **Chest Test:**
   - Sandığa yaklaşın
   - E'ye basılı tutun, progress bar dolsun
   - Sandık açılsın ve içindeki item alınsın

---

## Mimari Kararlar

### Interaction System Yapısı

```
[Sistem, Inheritance (Kalıtım) ve Observer Pattern temelleri üzerine kurulmuştur.]
```

**Neden bu yapıyı seçtim: **
> [Genişletilebilirlik (Extensibility) ana hedefim oldu. Yeni bir etkileşimli nesne eklemek için BaseInteractable sınıfından miras almak yeterlidir. Ayrıca Görsel (Highlight) ve İşitsel (SFX) geri bildirimleri Base Class seviyesinde çözerek kod tekrarını önledim.]

**Alternatifler:**
> [Kompozisyon (Composition) temelli bir yapı düşünülebilirdi. Yani her nesneye sadece `Interactable` scripti atıp, özel davranışları (OpenDoor, LootChest) ayrı bileşenler olarak eklemek.]

**Trade-off'lar:**
> [Inheritance (Kalıtım) yapısını seçmek, kod yazımını hızlandırdı ve `BaseInteractable` üzerinden ortak özellikleri (Ses, Renk) yönetmeyi kolaylaştırdı. Ancak hiyerarşi derinleşirse yönetimi zorlaşabilir. Bu proje ölçeğinde Kalıtım daha temiz bir çözüm sundu.]

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| [Observer] | [InteractionDetector -> InteractionUI] | [UI ve Logic birbirinden bağımsız (Decoupled) çalışmalıydı. Event sistemi ile bunu sağladım.] |
| [Singleton] | [AudioManager] | [Ses efektlerini her yerden kolayca ve tek bir merkezden yönetmek için kullandım.] |
| [Factory/SO] | [KeyDataSO] | [Anahtar verilerini koddan bağımsız, tasarımcı dostu ScriptableObject'ler olarak tuttum.] |

---

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] | Tüm private fieldlar kapsüllendi. |
| s_ prefix (private static) | [x] | Singleton instance'larında uygulandı. |
| k_ prefix (private const) | [  ] | |
| Region kullanımı | [x] | Fields, Properties, Methods olarak ayrıldı.  |
| Region sırası doğru | [x] | |
| XML documentation | [x] | Public API ve Interface metodları belgelendi. |
| Silent bypass yok | [x]  | Null referanslar için Debug.LogError eklendi. |
| Explicit interface impl. | [ ]  | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] | P_Door, P_Chest, P_Key |
| M_ prefix (Material) | [x] | M_Door_Wood, M_Chest_Gold |
| T_ prefix (Texture) |  [ ] | |
| SO isimlendirme | [x] | KeyDataSO |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x]  | Prefab root'ları (Empty Parent) (0,0,0) referans alınarak oluşturuldu. |
| Pivot bottom-center | [x] | Kapı ve Sandık kapağı için menteşe (Pivot) noktaları manuel ayarlandı. |
| Collider tercihi | [x] | Performans için Primitive (Box/Sphere) colliderlar kullanıldı. |
| Hierarchy yapısı | [x]  | Logic (Script) ve Visual (Mesh) ayrımı Parent-Child yapısıyla sağlandı. |

### Zorlandığım Noktalar
> [Alışkanlıklarımı Ludu Arts'ın belirlediği katı kodlama standartlarına (özellikle 'Encapsulation' ve 'Silent Bypass' kurallarına) adapte etmek başlangıçta efor gerektirdi. Ancak projeyi refactor ettikten sonra kodun ne kadar daha güvenli ve yönetilebilir hale geldiğini görmek öğretici oldu.]

---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] Core Interaction System
  - [x]  IInteractable interface
  - [x]  InteractionDetector
  - [x]  Range kontrolü

- [x] Interaction Types
  - [x]  Instant
  - [x]  Hold
  - [x]  Toggle

- [x] Interactable Objects
  - [x]  Door (locked/unlocked)
  - [x]  Key Pickup
  - [x]  Switch/Lever
  - [x]  Chest/Container

- [x] UI Feedback
  - [x]  Interaction prompt
  - [x]  Dynamic text
  - [x]  Hold progress bar
  - [x]  Cannot interact feedback

- [x]  Simple Inventory
  - [x]  Key toplama
  - [x]  UI listesi

### Bonus (Nice to Have)

- [x] Animation entegrasyonu
- [x] Sound effects
- [x] Multiple keys / color-coded
- [x] Interaction highlight
- [ ] Save/Load states
- [x] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Özellik] - [Neden tamamlanamadı]
2. [Özellik] - [Neden]

### Bilinen Bug'lar
1. [Bug açıklaması] - [Reproduce adımları]
2. [Bug]

### İyileştirme Önerileri
1. **Object Pooling** - Ses efektleri (`PlayClipAtPoint`) her seferinde yeni bir AudioSource oluşturup yok ediyor. Yoğun etkileşimli sahneler için bir "Audio Pool" sistemi performansı artıracaktır.
2. **State Pattern** - Oyuncu ve Kapı kontrolcüleri şu an bool değişkenlerle (`m_IsOpen`, `m_IsLocked`) yönetiliyor. Daha kompleks durumlar için "Finite State Machine" (FSM) yapısına geçilebilir.

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Simple First Person Controller]**
   - Açıklama: [Testlerin yapılabilmesi için CharacterController kullanan temiz bir FPS hareket kodu yazıldı.]
   - Neden ekledim: [Case'in odak noktası interaction olsa da, test edilebilirlik için gerekliydi.]



---

## Dosya Yapısı

```
Assets/
├── [Ludu-Arts-Case]/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   └── AudioManager.cs
│   │   │   │   └── InteractionType.cs
│   │   │   ├── Interactables/
│   │   │   │   ├── BaseInteractable.cs
│   │   │   │   └── Door.cs
│   │   │   │   └── Chest.cs
│   │   │   │   └── Key.cs
│   │   │   ├── Player/
│   │   │   │   └── InteractionDetector.cs
│   │   │   │   └── PlayerInventory.cs
│   │   │   │   └── FPSController.cs
│   │   │   └── UI/
│   │   │       └── InteractionUI.cs
│   │   └── Editor/
│   ├── ScriptableObjects/
│       └── Items/ 
│   ├── Prefabs/
│   ├── Materials/
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [ENES ERAY AKSOY] |
| E-posta | [enesaksoy250@gmail.com] |
| LinkedIn | [https://www.linkedin.com/in/enes-aksoy-8b656226b/] |
| GitHub | [https://github.com/enesaksoy250] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
