using UnityEngine;
using LuduArtsCase.Runtime.Player; // Inventory erişimi için
using LuduArtsCase.ScriptableObjects.Items; // KeyDataSO için

namespace LuduArtsCase.Runtime.Interactables
{
    /// <summary>
    /// Açılıp kapanabilen, kilitlenebilen kapı sınıfı.
    /// </summary>
    public class InteractableDoor : BaseInteractable
    {
        #region Fields

        [Header("Door Settings")]
        [SerializeField] private bool m_IsOpen = false;
        [SerializeField] private float m_OpenAngle = 90f;
        [SerializeField] private float m_CloseAngle = 0f;
        [SerializeField] private float m_AnimationSpeed = 5.0f;

        [Header("Lock Settings")]
        [Tooltip("Bu kapı kilitli mi?")]
        [SerializeField] private bool m_IsLocked = false;

        [Tooltip("Kilidi açmak için gereken anahtar (Boşsa kilit açılmaz).")]
        [SerializeField] private KeyDataSO m_RequiredKey;

        [Tooltip("Kilitliyken gösterilecek mesaj.")]
        [SerializeField] private string m_LockedMessage = "Locked - Key Required";

        private Quaternion m_TargetRotation;

        #endregion

        #region Properties

        // Eğer kilitliyse Locked mesajını, değilse standart mesajı göster
        public override string InteractionPrompt => m_IsLocked ? m_LockedMessage : base.InteractionPrompt;

        #endregion

        #region Unity Methods

        private void Start()
        {
            UpdateTargetRotation();

            // Başlangıç durumuna göre prompt ayarla
            if (!m_IsLocked)
            {
                m_PromptMessage = m_IsOpen ? "Close Door" : "Open Door";
            }
        }

        private void Update()
        {
            if (Quaternion.Angle(transform.localRotation, m_TargetRotation) > 0.1f)
            {
                transform.localRotation = Quaternion.Slerp(
                    transform.localRotation,
                    m_TargetRotation,
                    Time.deltaTime * m_AnimationSpeed
                );
            }
        }

        #endregion

        #region Methods

        public override bool OnInteract(GameObject interactor)
        {
            // Eğer kilitliyse, anahtarı kontrol et
            if (m_IsLocked)
            {
                return TryUnlock(interactor);
            }

            // Kilitli değilse normal aç/kapa
            ToggleDoor();
            return true;
        }

        private bool TryUnlock(GameObject interactor)
        {
            PlayerInventory inventory = interactor.GetComponent<PlayerInventory>();

            if (inventory != null && inventory.HasKey(m_RequiredKey))
            {
                // Anahtar var, kilidi aç
                m_IsLocked = false;
                Debug.Log("Kapı kilidi açıldı!");

                // Kilidi açınca direkt kapıyı da açalım (Design tercihi)
                ToggleDoor();
                return true;
            }
            else
            {
                // Anahtar yok veya inventory bulunamadı
                Debug.Log("Anahtar gerekli!");
                // İleride buraya "Locked" sesi veya efekti eklenebilir
                return false;
            }
        }

        private void ToggleDoor()
        {
            m_IsOpen = !m_IsOpen;
            UpdateTargetRotation();
            m_PromptMessage = m_IsOpen ? "Close Door" : "Open Door";
            PlaySound();
        }

        private void UpdateTargetRotation()
        {
            float targetAngle = m_IsOpen ? m_OpenAngle : m_CloseAngle;
            m_TargetRotation = Quaternion.Euler(0, targetAngle, 0);
        }

        #endregion
    }
}