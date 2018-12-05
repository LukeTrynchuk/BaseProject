using UnityEngine;
using System.Linq;
using static UnityEngine.Input;

namespace DogHouse.Services
{
    /// <summary>
    /// InputMethodManager is a component that controls
    /// which method of input is used.
    /// </summary>
    public class InputMethodManager : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private GameObject m_keyboardMouseInput = null;

        [SerializeField]
        private GameObject m_gamepadService = null;

        private InputState m_state = InputState.KEYBOARD;

        private bool GamepadIsConnected
        {
            get
            {
                return GetJoystickNames().Where(x => x.Length > 0)
                                         .ToList().Count > 0;
            }
        }
        #endregion

        #region Main Methods
        private void OnEnable() => SwitchInputSystems();
        private void Update() => SwitchInputSystems();
        #endregion

        #region Utility Methods
        private void SwitchInputSystems()
        {
            if (GamepadIsConnected && m_state == InputState.KEYBOARD)
            {
                SetState(InputState.CONTROLLER);
            }

            if (!GamepadIsConnected && m_state == InputState.CONTROLLER)
            {
                SetState(InputState.KEYBOARD);
            }
        }

        private void SetState(InputState state)
        {
            m_state = state;
            if (m_state == InputState.CONTROLLER)
            {
                m_gamepadService.SetActive(true);
                m_keyboardMouseInput.SetActive(false);
                return;
            }

            m_gamepadService.SetActive(false);
            m_keyboardMouseInput.SetActive(true);
        }
        #endregion
    }

    public enum InputState
    {
        KEYBOARD,
        CONTROLLER
    }
}
