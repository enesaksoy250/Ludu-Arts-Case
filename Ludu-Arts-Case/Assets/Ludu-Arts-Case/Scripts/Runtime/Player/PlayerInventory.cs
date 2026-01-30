using System; // Action için gerekli
using System.Collections.Generic;
using UnityEngine;
using LuduArtsCase.ScriptableObjects.Items;

namespace LuduArtsCase.Runtime.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        #region Fields

        [Header("Inventory")]
        [SerializeField] private List<KeyDataSO> m_Keys = new List<KeyDataSO>();

        #endregion

        #region Events

        // UI'ın dinleyeceği event
        public event Action<KeyDataSO> OnKeyAdded;

        #endregion

        #region Methods

        public void AddKey(KeyDataSO key)
        {
            if (!m_Keys.Contains(key))
            {
                m_Keys.Add(key);
                Debug.Log($"Anahtar alındı: {key.KeyName}");

                // Eventi fırlat
                OnKeyAdded?.Invoke(key);
            }
        }

        public bool HasKey(KeyDataSO key)
        {
            return m_Keys.Contains(key);
        }

        #endregion

        #region Save/Load Helpers

        // Save sistemi için anahtarları dışarı veren metod
        public List<string> GetKeyIds()
        {
            List<string> ids = new List<string>();
            foreach (var key in m_Keys) ids.Add(key.KeyId);
            return ids;
        }

        // Save sisteminden yüklerken kullanacağımız metod
        public void LoadKey(KeyDataSO key)
        {
            if (!m_Keys.Contains(key))
            {
                m_Keys.Add(key);
                OnKeyAdded?.Invoke(key); // UI da güncellensin
            }
        }
        #endregion
    }
}