using UnityEngine;

namespace LuduArtsCase.Runtime.Interactables
{
    /// <summary>
    /// Basılı tutarak açılan sandık.
    /// </summary>
    public class InteractableChest : BaseInteractable
    {
        #region Fields

        [Header("Chest Settings")]
        [SerializeField] private bool m_IsOpen = false;
        [SerializeField] private float m_OpenAngle = -120f; // Sandık kapağı genelde arkaya açılır
        [SerializeField] private Transform m_LidTransform; // Kapak objesi
        [SerializeField] private float m_AnimationSpeed = 4.0f;

        private Quaternion m_TargetRotation;

        #endregion

        #region Unity Methods

        private void Start()
        {
            // Başlangıç ayarları
            m_InteractionType = Runtime.Core.InteractionType.Hold; // Enum'ı Hold yapıyoruz
            m_HoldDuration = 2.0f; // 2 saniye basılı tut
            m_PromptMessage = "Hold E to Open";

            if (m_LidTransform == null)
            {
                // Eğer atanmadıysa childlardan bulmaya çalış
                m_LidTransform = transform.GetChild(0);
            }

            UpdateTargetRotation();
        }

        private void Update()
        {
            if (m_LidTransform != null && Quaternion.Angle(m_LidTransform.localRotation, m_TargetRotation) > 0.1f)
            {
                m_LidTransform.localRotation = Quaternion.Slerp(
                    m_LidTransform.localRotation,
                    m_TargetRotation,
                    Time.deltaTime * m_AnimationSpeed
                );
            }
        }

        #endregion

        #region Methods

        public override bool OnInteract(GameObject interactor)
        {
            if (!m_IsOpen)
            {
                OpenChest();
                return true;
            }
            return false;
        }

        private void OpenChest()
        {
            m_IsOpen = true;
            m_IsInteractable = false; // Açıldıktan sonra tekrar etkileşilemez
            m_PromptMessage = ""; // Yazıyı kaldır
            UpdateTargetRotation();

            Debug.Log("Sandık açıldı! (Ganimet sesi burada çalacak)");
        }

        private void UpdateTargetRotation()
        {
            float targetX = m_IsOpen ? m_OpenAngle : 0f;
            m_TargetRotation = Quaternion.Euler(targetX, 0, 0);
        }

        #endregion
    }
}