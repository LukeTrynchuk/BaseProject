using UnityEngine;
using System;
using System.Collections.Generic;
using DogHouse.Core.Services;
using static UnityEngine.Input;
using static UnityEngine.Vector2;

namespace DogHouse.Services
{
    /// <summary>
    /// KeyboardAndMouseInput is an implementation
    /// of the input service using the keyboard and
    /// mouse and devices.
    /// </summary>
    public class KeyboardAndMouseInput : BaseService<IInputService>, IInputService
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

        private const float INPUT_DEADZONE = 0.2f;

        private delegate void InputMethod();
        private List<InputMethod> m_inputMethods;
        #endregion

        #region Main Methods
        void Start()
        {
            m_inputMethods = new List<InputMethod>();
            m_inputMethods.Add(new InputMethod(CalculateMovementVector));
            m_inputMethods.Add(new InputMethod(CheckConfirmButtonPressed));
            m_inputMethods.Add(new InputMethod(CheckDeclineButtonPressed));
        }

        void Update()
        {
            foreach (InputMethod method in m_inputMethods)
                method?.Invoke();
        }
        #endregion

        #region Utility Methods
        private void CalculateMovementVector()
        {
            Vector2 movementVec = CalculateRawAxisMovement();
            movementVec.Normalize();

            if (movementVec.magnitude > INPUT_DEADZONE)
            {
                OnMovementVectorCalculated?.Invoke(movementVec);
            }
        }

        private void CheckConfirmButtonPressed()
        {
            if (GetKeyUp(m_confirmKey))
            {
                OnConfirmButtonPressed?.Invoke();
            }
        }

        private void CheckDeclineButtonPressed()
        {
            if (GetKeyUp(m_declineKey))
            {
                OnDeclineButtonPressed?.Invoke();
            }
        }
        #endregion

        #region Low Level Functions
        private Vector2 CalculateRawAxisMovement()
        {
            Vector2 vec = new Vector2();
            if (GetKeyDown(m_movementUpKey)) vec += up;
            if (GetKeyDown(m_movementLeftKey)) vec += left;
            if (GetKeyDown(m_movementDownKey)) vec += down;
            if (GetKeyDown(m_movementRightKey)) vec += right;
            return vec;
        }
        #endregion
    }
}
