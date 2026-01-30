using UnityEngine;
using UnityEngine.Events;

namespace LuduArtsCase.Runtime.Interactables
{
    /// <summary>
    /// Açılıp kapanabilen ve başka nesneleri tetikleyen şalter/kol sınıfı.
    /// UnityEvent kullanarak loose-coupling (gevşek bağlılık) sağlar.
    /// </summary>
    public class InteractableSwitch : BaseInteractable
    {
        #region Fields

        [Header("Switch Settings")]
        [SerializeField] private bool m_IsOn = false;

        [Tooltip("Şalter kolunun döneceği transform.")]
        [SerializeField] private Transform m_HandleTransform;

        [Tooltip("Açık konudaki açı.")]
        [SerializeField] private float m_OnAngle = 45f;

        [Tooltip("Kapalı konumdaki açı.")]
        [SerializeField] private float m_OffAngle = -45f;

        [Tooltip("Animasyon hızı.")]
        [SerializeField] private float m_Speed = 5f;

        [Header("Events")]
        [Tooltip("Şalter açıldığında tetiklenir.")]
        public UnityEvent OnSwitchActivate;

        [Tooltip("Şalter kapandığında tetiklenir.")]
        public UnityEvent OnSwitchDeactivate;

        private Quaternion m_TargetRotation;

        #endregion

        #region Unity Methods

        private void Start()
        {
            UpdateTargetRotation();
            UpdatePrompt();
        }

        private void Update()
        {
            if (m_HandleTransform != null && Quaternion.Angle(m_HandleTransform.localRotation, m_TargetRotation) > 0.1f)
            {
                m_HandleTransform.localRotation = Quaternion.Slerp(
                    m_HandleTransform.localRotation,
                    m_TargetRotation,
                    Time.deltaTime * m_Speed
                );
            }
        }

        #endregion

        #region Methods

        public override bool OnInteract(GameObject interactor)
        {
            ToggleSwitch();
            return true;
        }

        private void ToggleSwitch()
        {
            m_IsOn = !m_IsOn;
            UpdateTargetRotation();
            UpdatePrompt();

            // İlgili eventi tetikle
            if (m_IsOn)
            {
                OnSwitchActivate?.Invoke();
                Debug.Log("Switch Açıldı! Olaylar tetikleniyor...");
            }
            else
            {
                OnSwitchDeactivate?.Invoke();
                Debug.Log("Switch Kapandı.");
            }
        }

        private void UpdateTargetRotation()
        {
            float angle = m_IsOn ? m_OnAngle : m_OffAngle;
            // X ekseninde döndürüyoruz (Aşağı/Yukarı)
            m_TargetRotation = Quaternion.Euler(angle, 0, 0);
        }

        private void UpdatePrompt()
        {
            m_PromptMessage = m_IsOn ? "Turn Off" : "Turn On";
        }

        #endregion
    }
}