using UnityEngine;

namespace Michsky.UI.FieldCompleteMainMenu
{
    public class DevConsoleUI : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private GameObject consoleObject = null;
        [SerializeField]
        private KeyCode hotkey = KeyCode.F12;

        private bool isOn = false;

        private void Start()
        {
            SetVisible(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(hotkey))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            SetVisible(!isOn);
        }

        public void SetVisible(bool visible)
        {
            consoleObject.SetActive(visible);
            isOn = visible;
        }

    }
}