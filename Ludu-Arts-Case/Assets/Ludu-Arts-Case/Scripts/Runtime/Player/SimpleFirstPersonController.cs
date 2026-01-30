using UnityEngine;

namespace LuduArtsCase.Runtime.Player
{
    /// <summary>
    /// Test sahnesi için basit FPS karakter kontrolcüsü.
    /// WASD ile hareket ve Mouse ile bakış sağlar.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class SimpleFirstPersonController : MonoBehaviour
    {
        #region Fields

        [Header("Movement Settings")]
        [Tooltip("Yürüme hızı.")]
        [SerializeField] private float m_MoveSpeed = 5.0f;

        [Tooltip("Mouse hassasiyeti.")]
        [SerializeField] private float m_MouseSensitivity = 2.0f;

        [Header("References")]
        [Tooltip("Kamera transform referansı (Bakış için).")]
        [SerializeField] private Transform m_CameraTransform;

        // Private components
        private CharacterController m_CharacterController;
        private float m_VerticalRotation = 0f;

        #endregion

        #region Unity Methods

        private void Start()
        {
            m_CharacterController = GetComponent<CharacterController>();

            // Mouse imlecini gizle ve kilitle
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();

            // ESC'ye basınca mouse'u serbest bırak (Debug için)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// WASD tuşlarını okuyarak karakteri hareket ettirir.
        /// </summary>
        private void HandleMovement()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Hareket vektörünü oluştur (Karakterin yönüne göre)
            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            // Yerçekimi basitçe eklenebilir ama test için şart değil
            // Şimdilik sadece X ve Z düzleminde hareket yeterli
            m_CharacterController.Move(move * m_MoveSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Mouse hareketini okuyarak kamerayı ve gövdeyi döndürür.
        /// </summary>
        private void HandleRotation()
        {
            float mouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity;

            // Yukarı/Aşağı bakış (Kamerayı döndür)
            m_VerticalRotation -= mouseY;
            m_VerticalRotation = Mathf.Clamp(m_VerticalRotation, -90f, 90f);

            if (m_CameraTransform != null)
            {
                m_CameraTransform.localRotation = Quaternion.Euler(m_VerticalRotation, 0f, 0f);
            }

            // Sağa/Sola bakış (Gövdeyi döndür)
            transform.Rotate(Vector3.up * mouseX);
        }

        #endregion
    }
}