using UnityEngine;
using System.Linq;
using System.Collections.Generic;

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
        private GameObject m_keyboardMouseInput;

        [SerializeField]
        private GameObject m_gamepadService;

        private InputState m_state = InputState.KEYBOARD;
        #endregion

        #region Main Methods
        private void OnEnable() => SwitchInputSystems();
        private void Update()   => SwitchInputSystems();
        #endregion

        #region Utility Methods
        private void SwitchInputSystems()
        {
            bool connected = DetermineIfGamepadIsConnected();

            if(connected && m_state == InputState.KEYBOARD)
            {
                SetState(InputState.CONTROLLER);
            }

            if(!connected && m_state == InputState.CONTROLLER)
            {
                SetState(InputState.KEYBOARD);
            }
        }

        private bool DetermineIfGamepadIsConnected()
        {
            string[] deviceNames = Input.GetJoystickNames();

            List<string> deviceList = deviceNames
                                        .Where(x => x.Length > 0)
                                        .ToList();

            return deviceList.Count > 0;
        }

        private void SetState(InputState state)
        {
            m_state = state;
            if(m_state == InputState.CONTROLLER)
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
