using System;
using UnityEngine;
using LuduArtsCase.Runtime.Core;
using LuduArtsCase.Runtime.Interactables; // BaseInteractable erişimi için

namespace LuduArtsCase.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields

        [Header("Detection Settings")]
        [SerializeField] private float m_InteractionRange = 3.0f;
        [SerializeField] private LayerMask m_InteractableLayer;
        [SerializeField] private Transform m_RayOrigin;

        [Header("Debug")]
        [SerializeField] private bool m_ShowDebugGizmos = true;

        // State variables
        private BaseInteractable m_CurrentInteractable; // IInteractable yerine Base cast ediyoruz
        private RaycastHit m_HitInfo;
        private float m_CurrentHoldTime = 0f;
        private bool m_IsHolding = false;

        #endregion

        #region Events

        public event Action<IInteractable> OnInteractableChanged;

        // UI Progress Bar için yeni event (0 ile 1 arası değer döner)
        public event Action<float> OnInteractionProgress;

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

        private void DetectInteractable()
        {
            if (m_RayOrigin == null) return;

            bool hitSomething = Physics.Raycast(
                m_RayOrigin.position,
                m_RayOrigin.forward,
                out m_HitInfo,
                m_InteractionRange,
                m_InteractableLayer
            );

            // DEĞİŞİKLİK BURADA: IInteractable yerine BaseInteractable arıyoruz
            BaseInteractable detectedInteractable = null;

            if (hitSomething)
            {
                // Parent kontrolü (Düzeltilmiş hali)
                detectedInteractable = m_HitInfo.collider.GetComponentInParent<BaseInteractable>();
            }

            // Eğer odaklanılan nesne değiştiyse
            if (detectedInteractable != m_CurrentInteractable)
            {
                // 1. Eski nesneye "Artık sana bakmıyorum" de
                if (m_CurrentInteractable != null)
                {
                    m_CurrentInteractable.OnLoseFocus();
                }

                // Değişikliği kaydet
                m_CurrentInteractable = detectedInteractable;

                // 2. Yeni nesneye "Sana bakıyorum" de
                if (m_CurrentInteractable != null)
                {
                    m_CurrentInteractable.OnFocus();
                }

                // Event fırlat (UI için)
                OnInteractableChanged?.Invoke(m_CurrentInteractable);

                ResetHold();
            }
        }

        private void HandleInput()
        {
            if (m_CurrentInteractable == null || !m_CurrentInteractable.CanInteract)
            {
                ResetHold();
                return;
            }

            switch (m_CurrentInteractable.Type)
            {
                case InteractionType.Instant:
                    HandleInstantInteraction();
                    break;
                case InteractionType.Hold:
                    HandleHoldInteraction();
                    break;
            }
        }

        private void HandleInstantInteraction()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                m_CurrentInteractable.OnInteract(gameObject);
            }
        }

        private void HandleHoldInteraction()
        {
            if (Input.GetKey(KeyCode.E))
            {
                m_IsHolding = true;
                m_CurrentHoldTime += Time.deltaTime;

                // Progress oranını hesapla (0.0 -> 1.0)
                float progress = Mathf.Clamp01(m_CurrentHoldTime / m_CurrentInteractable.HoldDuration);
                OnInteractionProgress?.Invoke(progress);

                // Süre doldu mu?
                if (m_CurrentHoldTime >= m_CurrentInteractable.HoldDuration)
                {
                    m_CurrentInteractable.OnInteract(gameObject);
                    ResetHold(); // İşlem bitince sıfırla
                }
            }
            else
            {
                ResetHold();
            }
        }

        private void ResetHold()
        {
            if (m_IsHolding || m_CurrentHoldTime > 0)
            {
                m_IsHolding = false;
                m_CurrentHoldTime = 0f;
                OnInteractionProgress?.Invoke(0f); // UI'ı sıfırla
            }
        }

        #endregion
    }
}