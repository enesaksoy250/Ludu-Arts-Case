using UnityEngine;

namespace LuduArtsCase.Runtime.Interactables
{
    /// <summary>
    /// Basit açılıp kapanan kapı mekanizması.
    /// </summary>
    public class InteractableDoor : BaseInteractable
    {
        #region Fields

        [Header("Door Settings")]
        [Tooltip("Kapı şu an açık mı?")]
        [SerializeField] private bool m_IsOpen = false;

        [Tooltip("Açılma açısı.")]
        [SerializeField] private float m_OpenAngle = 90f;

        [Tooltip("Kapanma açısı (Genelde 0).")]
        [SerializeField] private float m_CloseAngle = 0f;

        [Tooltip("Kapı hareket hızı.")]
        [SerializeField] private float m_AnimationSpeed = 5.0f;

        // Hedef rotasyonu tutan değişken
        private Quaternion m_TargetRotation;

        #endregion

        #region Unity Methods

        private void Start()
        {
            UpdateTargetRotation();
        }

        private void Update()
        {
            // Yumuşak geçiş (Lerp/Slerp)
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
            ToggleDoor();
            return true; // Etkileşim başarılı
        }

        /// <summary>
        /// Kapı durumunu tersine çevirir (Açıksa kapatır, kapalıysa açar).
        /// </summary>
        private void ToggleDoor()
        {
            m_IsOpen = !m_IsOpen;
            UpdateTargetRotation();

            // Opsiyonel: Mesajı güncelle
            m_PromptMessage = m_IsOpen ? "Close Door" : "Open Door";
        }

        private void UpdateTargetRotation()
        {
            float targetAngle = m_IsOpen ? m_OpenAngle : m_CloseAngle;
            // Sadece Y ekseninde döndürüyoruz (Kapı menteşesi)
            m_TargetRotation = Quaternion.Euler(0, targetAngle, 0);
        }

        #endregion
    }
}