using UnityEngine;

namespace LuduArtsCase.Runtime.Core
{
    /// <summary>
    /// Oyundaki tüm ses efektlerini tek bir noktadan yöneten sistem.
    /// Singleton Pattern kullanır.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        #region Singleton

        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                // Sahne geçişlerinde yok olmasın (İsteğe bağlı)
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Belirtilen pozisyonda bir ses efekti çalar (3D Sound).
        /// </summary>
        /// <param name="clip">Çalınacak ses dosyası.</param>
        /// <param name="position">Sesin çıkacağı konum.</param>
        /// <param name="volume">Ses seviyesi (0-1).</param>
        public void PlaySFX(AudioClip clip, Vector3 position, float volume = 1.0f)
        {
            if (clip == null) return;

            // Belirtilen noktada geçici bir AudioSource oluşturur ve çalar
            AudioSource.PlayClipAtPoint(clip, position, volume);
        }

        #endregion
    }
}