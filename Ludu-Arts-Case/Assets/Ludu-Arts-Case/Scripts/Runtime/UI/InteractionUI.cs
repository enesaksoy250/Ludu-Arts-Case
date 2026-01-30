using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro kütüphanesi
using LuduArtsCase.Runtime.Player;
using LuduArtsCase.Runtime.Core;

namespace LuduArtsCase.Runtime.UI
{
    /// <summary>
    /// InteractionDetector'dan gelen eventleri dinleyerek ekrandaki
    /// etkileşim yazılarını ve progress bar'ı güncelleyen sınıf.
    /// </summary>
    public class InteractionUI : MonoBehaviour
    {
        #region Fields

        [Header("References")]
        [Tooltip("Dinlenecek dedektör scripti.")]
        [SerializeField] private InteractionDetector m_Detector;

        [Header("UI Elements")]
        [Tooltip("Tüm prompt panelini açıp kapatmak için ana obje.")]
        [SerializeField] private GameObject m_PromptContainer;

        [Tooltip("Etkileşim mesajı (Örn: Press E to Open).")]
        [SerializeField] private TextMeshProUGUI m_PromptText;

        [Tooltip("Basılı tutma işlemi için dolan bar (Image Fill).")]
        [SerializeField] private Image m_ProgressBar;

        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            if (m_Detector != null)
            {
                m_Detector.OnInteractableChanged += HandleInteractableChanged;
                m_Detector.OnInteractionProgress += HandleInteractionProgress;
            }
        }

        private void OnDisable()
        {
            if (m_Detector != null)
            {
                m_Detector.OnInteractableChanged -= HandleInteractableChanged;
                m_Detector.OnInteractionProgress -= HandleInteractionProgress;
            }
        }

        private void Start()
        {
            // Başlangıçta gizle
            HidePrompt();
        }

        #endregion

        #region Methods

        private void HandleInteractableChanged(IInteractable interactable)
        {
            if (interactable != null)
            {
                ShowPrompt(interactable);
            }
            else
            {
                HidePrompt();
            }
        }

        private void HandleInteractionProgress(float progress)
        {
            if (m_ProgressBar != null)
            {
                m_ProgressBar.fillAmount = progress;
            }
        }

        private void ShowPrompt(IInteractable interactable)
        {
            if (m_PromptContainer != null) m_PromptContainer.SetActive(true);

            if (m_PromptText != null)
            {
                m_PromptText.text = interactable.InteractionPrompt;
            }

            // Barı sıfırla
            if (m_ProgressBar != null) m_ProgressBar.fillAmount = 0f;
        }

        private void HidePrompt()
        {
            if (m_PromptContainer != null) m_PromptContainer.SetActive(false);
        }

        #endregion
    }
}