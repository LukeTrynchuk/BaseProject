using UnityEngine;
using UnityEngine.Events;

namespace DogHouse.General
{
    /// <summary>
    /// OnStart will invoke a unity event
    /// on start. This allows others to subscribe 
    /// to the event for quick prototyping.
    /// </summary>
    public class OnStart : MonoBehaviour 
    {
        #region Private Variables
        [SerializeField]
        private UnityEvent m_onStart;
        #endregion

        #region Main Methods
        private void Start() => m_onStart?.Invoke();
        #endregion
    }
}
