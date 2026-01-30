using UnityEngine;
using LuduArtsCase.Runtime.Core;

namespace LuduArtsCase.Runtime.Interactables
{
    /// <summary>
    /// Tüm etkileşilebilir nesneler için temel soyut sınıf.
    /// IInteractable arayüzünü implemente eder ve ortak özellikleri barındırır.
    /// </summary>
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Base Settings")]
        [Tooltip("Oyuncuya gösterilecek temel etkileşim mesajı.")]
        [SerializeField] protected string m_PromptMessage = "Interact";

        [Tooltip("Nesne şu an etkileşime açık mı?")]
        [SerializeField] protected bool m_IsInteractable = true;

        #endregion

        #region Properties

        /// <inheritdoc/>
        public virtual string InteractionPrompt => m_PromptMessage;

        /// <inheritdoc/>
        public virtual bool CanInteract => m_IsInteractable;

        #endregion

        #region Methods

        /// <summary>
        /// Etkileşim mantığı türetilen sınıflarda (Door, Chest vb.) özelleştirilmelidir.
        /// </summary>
        /// <param name="interactor">Etkileşimi yapan obje.</param>
        /// <returns>Etkileşim başarılı oldu mu?</returns>
        public abstract bool OnInteract(GameObject interactor);

        #endregion
    }
}