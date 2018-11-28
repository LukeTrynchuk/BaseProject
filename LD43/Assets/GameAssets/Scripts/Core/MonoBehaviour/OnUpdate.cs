using UnityEngine;
using UnityEngine.Events;

namespace DogHouse.Core.Mono
{
    /// <summary>
    /// OnUpdate will invoke a unity event
    /// each update.
    /// </summary>
    public class OnUpdate : MonoBehaviour 
    {
        #region Private Variables
        [SerializeField]
        private UnityEvent m_onUpdate;
        #endregion

        #region Main Methods
        private void Update() => m_onUpdate?.Invoke();
        #endregion
    }
}
