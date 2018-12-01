using UnityEngine;
using UnityEngine.UI;

namespace DogHouse.Core.UI
{
    /// <summary>
    /// InvokeButtonOnClick will take in a button and 
    /// will invoke the button's OnClick event.
    /// </summary>
    public class InvokeButtonOnClick : MonoBehaviour 
    {
        #region Private Variables
        [SerializeField]
        private Button m_button;
        #endregion
        
        #region Main Methods
        public void OnClick()
        {
            m_button?.onClick?.Invoke();
        }
        #endregion
    }
}
