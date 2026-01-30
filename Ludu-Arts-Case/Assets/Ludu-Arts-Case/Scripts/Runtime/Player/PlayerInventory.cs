using System.Collections.Generic;
using UnityEngine;
using LuduArtsCase.ScriptableObjects.Items;

namespace LuduArtsCase.Runtime.Player
{
    /// <summary>
    /// Oyuncunun topladığı eşyaları (şimdilik sadece anahtarlar) tutan basit envanter sistemi.
    /// </summary>
    public class PlayerInventory : MonoBehaviour
    {
        #region Fields

        [Header("Inventory")]
        [SerializeField] private List<KeyDataSO> m_Keys = new List<KeyDataSO>();

        #endregion

        #region Methods

        /// <summary>
        /// Envantere anahtar ekler.
        /// </summary>
        public void AddKey(KeyDataSO key)
        {
            if (!m_Keys.Contains(key))
            {
                m_Keys.Add(key);
                Debug.Log($"Anahtar alındı: {key.KeyName}");
            }
        }

        /// <summary>
        /// Belirtilen anahtarın envanterde olup olmadığını kontrol eder.
        /// </summary>
        public bool HasKey(KeyDataSO key)
        {
            return m_Keys.Contains(key);
        }

        #endregion
    }
}