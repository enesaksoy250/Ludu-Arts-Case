using UnityEngine;
using LuduArtsCase.Runtime.Core;

namespace LuduArtsCase.Runtime.Interactables
{
    // [RequireComponent(typeof(AudioSource))]  <-- ARTIK GEREK YOK, SİLDİK
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Base Settings")]
        [SerializeField] protected string m_PromptMessage = "Interact";
        [SerializeField] protected bool m_IsInteractable = true;

        [Header("Interaction Type")]
        [SerializeField] protected InteractionType m_InteractionType = InteractionType.Instant;
        [SerializeField] protected float m_HoldDuration = 1.0f;

        [Header("Feedback (Bonus)")]
        [Tooltip("Etkileşim sırasında çalacak ses.")]
        [SerializeField] protected AudioClip m_InteractSound;

        [Tooltip("Bakınca rengi değişecek mesh.")]
        [SerializeField] protected Renderer m_Renderer;

        [Tooltip("Highlight rengi.")]
        [SerializeField] protected Color m_HighlightColor = Color.yellow;

        // AudioSource referansına gerek kalmadı
        private Color m_OriginalColor;
        private Material m_OriginalMaterial;

        #endregion

        #region Properties

        public virtual string InteractionPrompt => m_PromptMessage;
        public virtual bool CanInteract => m_IsInteractable;
        public InteractionType Type => m_InteractionType;
        public float HoldDuration => m_HoldDuration;

        #endregion

        #region Unity Methods

        protected virtual void Awake()
        {
            // AudioSource GetComponent SİLİNDİ

            if (m_Renderer != null)
            {
                m_OriginalMaterial = m_Renderer.material;
                m_OriginalColor = m_OriginalMaterial.color;
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public abstract bool OnInteract(GameObject interactor);

        // --- GÜNCELLENEN SES METODU ---
        protected void PlaySound()
        {
            // Eğer ses dosyası varsa ve AudioManager sahnedeyse çal
            if (m_InteractSound != null)
            {
                if (AudioManager.Instance != null)
                {
                    // Sesin pozisyonu bu objenin olduğu yer olsun
                    AudioManager.Instance.PlaySFX(m_InteractSound, transform.position);
                }
                else
                {
                    Debug.LogWarning("AudioManager sahnede bulunamadı!");
                }
            }
        }

        /// <inheritdoc/>
        public virtual void OnFocus()
        {
            if (m_Renderer != null)
            {
                m_Renderer.material.color = m_HighlightColor;
            }
        }

        /// <inheritdoc/>
        public virtual void OnLoseFocus()
        {
            if (m_Renderer != null)
            {
                m_Renderer.material.color = m_OriginalColor;
            }
        }

        #endregion
    }
}