using UnityEngine;

namespace LuduArtsCase.ScriptableObjects.Items
{
    /// <summary>
    /// Anahtar türlerini tanımlayan veri dosyası.
    /// Her farklı anahtar (Kırmızı, Mavi, Demir) için bir tane oluşturulur.
    /// </summary>
    [CreateAssetMenu(fileName = "NewKeyData", menuName = "LuduArts/Inventory/Key Data")]
    public class KeyDataSO : ScriptableObject
    {
        #region Fields

        [Header("Key Info")]
        [Tooltip("Anahtarın oyunda görünen adı.")]
        [SerializeField] private string m_KeyName;

        [Tooltip("Sistemsel benzersiz kimliği (örn: key_red).")]
        [SerializeField] private string m_KeyId;

        #endregion

        #region Properties

        public string KeyName => m_KeyName;
        public string KeyId => m_KeyId;

        #endregion
    }
}