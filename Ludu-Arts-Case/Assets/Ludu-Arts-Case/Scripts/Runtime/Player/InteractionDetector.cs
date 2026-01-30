using System;
using UnityEngine;
using LuduArtsCase.Runtime.Core;

namespace LuduArtsCase.Runtime.Player
{
    /// <summary>
    /// Oyuncunun bakış yönündeki etkileşilebilir nesneleri tespit eden sınıf.
    /// </summary>
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields

        // Serialized private instance fields (m_ prefix kuralı)
        [Header("Detection Settings")]
        [SerializeField] private float m_InteractionRange = 3.0f;
        [SerializeField] private LayerMask m_InteractableLayer;
        [SerializeField] private Transform m_RayOrigin;

        [Header("Debug")]
        [SerializeField] private bool m_ShowDebugGizmos = true;

        // Non-serialized private instance fields
        private IInteractable m_CurrentInteractable;
        private RaycastHit m_HitInfo;

        #endregion

        #region Events

        /// <summary>
        /// Etkileşilebilir bir nesne bulunduğunda veya kaybedildiğinde tetiklenir.
        /// UI güncellemesi için kullanılır.
        /// </summary>
        public event Action<IInteractable> OnInteractableChanged;

        #endregion

        #region Unity Methods

        private void Update()
        {
            DetectInteractable();
            HandleInput();
        }

        private void OnDrawGizmos()
        {
            if (m_ShowDebugGizmos && m_RayOrigin != null)
            {
                Gizmos.color = m_CurrentInteractable != null ? Color.green : Color.red;
                Gizmos.DrawRay(m_RayOrigin.position, m_RayOrigin.forward * m_InteractionRange);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raycast atarak karşıdaki IInteractable nesnesini tespit eder.
        /// </summary>
        private void DetectInteractable()
        {
            if (m_RayOrigin == null) return;

            // Raycast atıyoruz
            bool hitSomething = Physics.Raycast(
                m_RayOrigin.position,
                m_RayOrigin.forward,
                out m_HitInfo,
                m_InteractionRange,
                m_InteractableLayer
            );

            IInteractable detectedInteractable = null;

            if (hitSomething)
            {
                // Collider üzerindeki IInteractable bileşenini al
                detectedInteractable = m_HitInfo.collider.GetComponent<IInteractable>();
            }

            // Durum değişikliği kontrolü (Optimization: Sadece değişince event fırlat)
            if (detectedInteractable != m_CurrentInteractable)
            {
                m_CurrentInteractable = detectedInteractable;
                OnInteractableChanged?.Invoke(m_CurrentInteractable);
            }
        }

        /// <summary>
        /// Kullanıcı girdisini (E tuşu) dinler.
        /// </summary>
        private void HandleInput()
        {
            // İleride Input System'e çevrilebilir.
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (m_CurrentInteractable != null && m_CurrentInteractable.CanInteract)
                {
                    m_CurrentInteractable.OnInteract(gameObject);
                }
            }
        }

        #endregion
    }
}