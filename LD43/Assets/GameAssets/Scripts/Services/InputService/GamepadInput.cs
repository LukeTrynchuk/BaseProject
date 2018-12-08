using System;
using System.Collections.Generic;
using DogHouse.Services;
using DogHouse.Core.Services;
using UnityEngine;
using static UnityEngine.Input;

namespace DogHouse.General
{
    /// <summary>
    /// GamepadInput is an implementation of
    /// the input service. The gamepad input uses
    /// a game pad for input.
    /// </summary>
    public class GamepadInput : BaseService<IInputService>, IInputService
    {
        #region Public Variables
        public event Action<Vector2> OnMovementVectorCalculated;
        public event Action OnConfirmButtonPressed;
        public event Action OnDeclineButtonPressed;
        #endregion

        #region Private Variables
        private Vector2 m_moveVector = new Vector2();

        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";
        private const string CONFIRM_WIN = "ConfirmButton_WIN";
        private const string CONFIRM_OSX = "ConfirmButton_OSX";
        private const string DECLINE_WIN = "DeclineButton_WIN";
        private const string DECLINE_OSX = "DeclineButton_OSX";

        private delegate void InputMethod();
        private List<InputMethod> m_inputMethods;
        #endregion

        #region Main Methods
        void Start()
        {
            m_inputMethods = new List<InputMethod>();
            m_inputMethods.Add(new InputMethod(CalculateMovementVector));
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
            CalculateVector();
            if (m_moveVector.magnitude < 0.2f) return;

            OnMovementVectorCalculated?.Invoke(m_moveVector);
        }

        private void CheckConfirmButtonPressed()
        {
            float confirmButton = 0f;
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            confirmButton = GetAxis(CONFIRM_WIN);
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
            confirmButton = GetAxis(CONFIRM_OSX);
#endif

            if (confirmButton > 05f) OnConfirmButtonPressed?.Invoke();
        }

        private void CheckDeclineButtonPressed()
        {
            float declineButton = 0f;
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            declineButton = GetAxis(DECLINE_WIN);
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
            declineButton = GetAxis(DECLINE_OSX);
#endif

            if (declineButton > 05f) OnDeclineButtonPressed?.Invoke();
        }
        #endregion

        #region Low Level Functions
        private void CalculateVector()
        {
            m_moveVector.x = GetAxis(HORIZONTAL_AXIS);
            m_moveVector.y = GetAxis(VERTICAL_AXIS);
        }
        #endregion
    }
}
