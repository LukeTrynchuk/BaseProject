using UnityEngine;

namespace DogHouse.Core.GameObject
{
    /// <summary>
    /// The Do Not Destroy On Load script will
    /// tag the current game object that this
    /// component is attached to become an
    /// object that is not destroyed on scene
    /// load.
    /// </summary>
    public class DoNotDestroyOnLoad : MonoBehaviour
    {
        #region Main Methods
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }
}
