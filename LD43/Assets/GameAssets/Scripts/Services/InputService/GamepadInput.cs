using System;
using DogHouse.Services;
using UnityEngine;
using static UnityEngine.Input;
using static DogHouse.Core.Services.ServiceLocator;

namespace DogHouse.General
{
    /// <summary>
    /// GamepadInput is an implementation of
    /// the input service. The gamepad input uses
    /// a game pad for input.
    /// </summary>
    public class GamepadInput : MonoBehaviour, IInputService
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
        #endregion

        #region Main Methods
        void OnEnable() => RegisterService();
        void OnDisable() => UnregisterService();

        void Update()
        {
            DetermineMovementVector();
            //DetermineConfirmButtonPressed();                                  //TODO : Replace these. Automated input system
            //DetermineDeclineButtonPressed();
        }

        public void RegisterService()   => Register<IInputService>(this);
        public void UnregisterService() => Unregister<IInputService>(this);
        #endregion

        #region Utility Methods
        private void DetermineMovementVector()
        {
            CalculateMoveVector();
            if (m_moveVector.magnitude < 0.2f) return;

            OnMovementVectorCalculated?.Invoke(m_moveVector);
        }

        private void DetermineConfirmButtonPressed()
        {
            float confirmButton = 0f;
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            confirmButton = GetAxis(CONFIRM_WIN);
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
            confirmButton = GetAxis(CONFIRM_OSX);
#endif

            if (confirmButton > 05f) OnConfirmButtonPressed?.Invoke();
        }

        private void DetermineDeclineButtonPressed()
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
        private void CalculateMoveVector()
        {
            m_moveVector.x = GetAxis(HORIZONTAL_AXIS);
            m_moveVector.y = GetAxis(VERTICAL_AXIS);
        }
        #endregion
    }
}
