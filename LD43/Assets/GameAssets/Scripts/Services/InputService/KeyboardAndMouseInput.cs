using DogHouse.Core.Services;
using UnityEngine;
using System;

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
        private KeyCode m_movementUpKey;

        [SerializeField]
        private KeyCode m_movementDownKey;

        [SerializeField]
        private KeyCode m_movementLeftKey;

        [SerializeField]
        private KeyCode m_movementRightKey;

        [Header("Confirm / Decline Keys")]
        [SerializeField]
        private KeyCode m_confirmKey;

        [SerializeField]
        private KeyCode m_declineKey;

        private Vector2 m_movementVector = new Vector2();
        #endregion

        #region Main Methods
        void OnEnable() => RegisterService();
        void OnDisable() => UnregisterService();

        public void RegisterService()
        {
            ServiceLocator.Register<IInputService>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.Unregister<IInputService>(this);
        }

        void Update()
        {
            CalculateMovementVector();
            DetectConfirmButtonPressed();
            DetectDeclineButtonPressed();
        }
        #endregion

        #region Utility Methods
        private void CalculateMovementVector()
        {
            m_movementVector.x = 0;
            m_movementVector.y = 0;

            if(Input.GetKeyDown(m_movementUpKey))
            {
                m_movementVector += Vector2.up;
            }

            if (Input.GetKeyDown(m_movementLeftKey))
            {
                m_movementVector += Vector2.left;
            }

            if (Input.GetKeyDown(m_movementDownKey))
            {
                m_movementVector += Vector2.down;
            }

            if (Input.GetKeyDown(m_movementRightKey))
            {
                m_movementVector += Vector2.right;
            }

            m_movementVector.Normalize();
            if(m_movementVector.magnitude > 0.2f)
            {
                OnMovementVectorCalculated?.Invoke(m_movementVector);
            }
        }

        private void DetectConfirmButtonPressed()
        {
            if(Input.GetKeyUp(m_confirmKey))
            {
                OnConfirmButtonPressed?.Invoke();
            }
        }

        private void DetectDeclineButtonPressed()
        {
            if(Input.GetKeyUp(m_declineKey))
            {
                OnDeclineButtonPressed?.Invoke();
            }
        }
        #endregion
    }
}
