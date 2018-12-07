using UnityEngine;
using System;
using static DogHouse.Core.Services.ServiceLocator;
using static UnityEngine.Input;

namespace DogHouse.Services
{
    /// <summary>
    /// KeyboardAndMouseInput is an implementation
    /// of the input service using the keyboard and
    /// mouse and devices.
    /// </summary>
    public class KeyboardAndMouseInput : MonoBehaviour, IInputService
    {
        #region Public Variables
        public event Action<Vector2> OnMovementVectorCalculated;
        public event Action OnConfirmButtonPressed;
        public event Action OnDeclineButtonPressed;
        #endregion

        #region Private Variables
        [Header("Movement Keys")]
        [SerializeField]
        private KeyCode m_movementUpKey = KeyCode.A;

        [SerializeField]
        private KeyCode m_movementDownKey = KeyCode.A;

        [SerializeField]
        private KeyCode m_movementLeftKey = KeyCode.A;

        [SerializeField]
        private KeyCode m_movementRightKey = KeyCode.A;

        [Header("Confirm / Decline Keys")]
        [SerializeField]
        private KeyCode m_confirmKey = KeyCode.A;

        [SerializeField]
        private KeyCode m_declineKey = KeyCode.A;

        private Vector2 m_movementVector = new Vector2();
        private const float INPUT_DEADZONE = 0.2f;
        #endregion

        #region Main Methods
        void OnEnable() => RegisterService();
        void OnDisable() => UnregisterService();
        public void RegisterService() => Register<IInputService>(this);
        public void UnregisterService() => Unregister<IInputService>(this);

        void Update()
        {
            CalculateMovementVector();
            CheckConfirmButtonPressed();
            CheckDeclineButtonPressed();
        }
        #endregion

        #region Utility Methods
        private void CalculateMovementVector()
        {
            m_movementVector.x = 0;
            m_movementVector.y = 0;

            if(GetKeyDown(m_movementUpKey))
            {
                m_movementVector += Vector2.up;
            }

            if (GetKeyDown(m_movementLeftKey))
            {
                m_movementVector += Vector2.left;
            }

            if (GetKeyDown(m_movementDownKey))
            {
                m_movementVector += Vector2.down;
            }

            if (GetKeyDown(m_movementRightKey))
            {
                m_movementVector += Vector2.right;
            }

            m_movementVector.Normalize();
            if(m_movementVector.magnitude > INPUT_DEADZONE)
            {
                OnMovementVectorCalculated?.Invoke(m_movementVector);
            }
        }

        private void CheckConfirmButtonPressed()
        {
            if(GetKeyUp(m_confirmKey))
            {
                OnConfirmButtonPressed?.Invoke();
            }
        }

        private void CheckDeclineButtonPressed()
        {
            if(GetKeyUp(m_declineKey))
            {
                OnDeclineButtonPressed?.Invoke();
            }
        }
        #endregion
    }
}
