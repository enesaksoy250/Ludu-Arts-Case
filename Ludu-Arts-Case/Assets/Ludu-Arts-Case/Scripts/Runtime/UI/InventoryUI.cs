using UnityEngine;
using TMPro;
using LuduArtsCase.Runtime.Player;
using LuduArtsCase.ScriptableObjects.Items;

namespace LuduArtsCase.Runtime.UI
{
    /// <summary>
    /// Envantere gelen eşyaları ekranda listeler.
    /// </summary>
    public class InventoryUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerInventory m_PlayerInventory;
        [SerializeField] private Transform m_ItemContainer; // İtemlerin dizileceği yer
        [SerializeField] private GameObject m_ItemPrefab;   // Tek bir satırın prefabı

        private void OnEnable()
        {
            if (m_PlayerInventory != null)
                m_PlayerInventory.OnKeyAdded += HandleKeyAdded;
        }

        private void OnDisable()
        {
            if (m_PlayerInventory != null)
                m_PlayerInventory.OnKeyAdded -= HandleKeyAdded;
        }

        private void HandleKeyAdded(KeyDataSO key)
        {
            if (m_ItemPrefab == null || m_ItemContainer == null) return;

            // Yeni bir UI elemanı oluştur
            GameObject newItem = Instantiate(m_ItemPrefab, m_ItemContainer);

            // Text bileşenini bul ve yaz
            TextMeshProUGUI textComp = newItem.GetComponentInChildren<TextMeshProUGUI>();
            if (textComp != null)
            {
                textComp.text = "- " + key.KeyName;
            }
        }
    }
}