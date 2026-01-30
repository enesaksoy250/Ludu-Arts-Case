using UnityEngine;

namespace LuduArtsCase.Runtime.Core
{
    /// <summary>
    /// Oyuncu ile etkileşime girebilen tüm nesnelerin uygulaması gereken temel arayüz.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// UI üzerinde gösterilecek etkileşim metni. (Örn: "Press E to Open")
        /// </summary>
        string InteractionPrompt { get; }

        /// <summary>
        /// Nesnenin şu anda etkileşime uygun olup olmadığını belirtir.
        /// </summary>
        bool CanInteract { get; }

        /// <summary>
        /// Etkileşim gerçekleştiğinde çağrılır.
        /// </summary>
        /// <param name="interactor">Etkileşimi başlatan obje (Genelde Player).</param>
        /// <returns>Etkileşim başarılı oldu mu?</returns>
        bool OnInteract(GameObject interactor);

        /// <summary>
        /// Oyuncu nesneye bakmaya başladığında çağrılır (Highlight için).
        /// </summary>
        void OnFocus();

        /// <summary>
        /// Oyuncu nesneden gözünü çektiğinde çağrılır.
        /// </summary>
        void OnLoseFocus();
    }
}