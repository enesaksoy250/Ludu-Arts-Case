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
        [Header("Key Info")]
        public string KeyName;
        public string KeyId;
    }
}