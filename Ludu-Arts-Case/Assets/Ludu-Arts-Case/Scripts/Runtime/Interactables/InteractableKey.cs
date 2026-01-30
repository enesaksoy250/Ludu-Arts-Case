using UnityEngine;
using LuduArtsCase.Runtime.Player;
using LuduArtsCase.ScriptableObjects.Items;

namespace LuduArtsCase.Runtime.Interactables
{
    /// <summary>
    /// Oyuncu tarafından toplanabilen anahtar nesnesi.
    /// </summary>
    public class InteractableKey : BaseInteractable
    {
        #region Fields

        [Header("Key Settings")]
        [SerializeField] private KeyDataSO m_KeyData;

        #endregion

        #region Methods

        public override bool OnInteract(GameObject interactor)
        {
            // Oyuncunun envanterine eriş
            PlayerInventory inventory = interactor.GetComponent<PlayerInventory>();

            if (inventory != null && m_KeyData != null)
            {
                inventory.AddKey(m_KeyData);

                // Anahtarı sahneden kaldır (yok et)
                PlaySound();
                Destroy(gameObject);
                return true;
            }

            return false;
        }

        #endregion
    }
}