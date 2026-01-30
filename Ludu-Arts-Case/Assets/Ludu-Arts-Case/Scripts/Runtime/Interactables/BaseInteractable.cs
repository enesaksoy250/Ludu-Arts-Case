using UnityEngine;
using LuduArtsCase.Runtime.Core;

namespace LuduArtsCase.Runtime.Interactables
{
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Base Settings")]
        [SerializeField] protected string m_PromptMessage = "Interact";
        [SerializeField] protected bool m_IsInteractable = true;

        [Header("Interaction Type")]
        [Tooltip("Etkileşim türü: Anlık mı, Basılı tutmalı mı?")]
        [SerializeField] protected InteractionType m_InteractionType = InteractionType.Instant;

        [Tooltip("Hold türü için saniye cinsinden süre.")]
        [SerializeField] protected float m_HoldDuration = 1.0f;

        #endregion

        #region Properties

        public virtual string InteractionPrompt => m_PromptMessage;
        public virtual bool CanInteract => m_IsInteractable;

        // Yeni Property'ler
        public InteractionType Type => m_InteractionType;
        public float HoldDuration => m_HoldDuration;

        #endregion

        #region Methods

        public abstract bool OnInteract(GameObject interactor);

        #endregion
    }
}