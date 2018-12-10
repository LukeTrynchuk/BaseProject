using UnityEngine;
using System;

namespace DogHouse.General
{
    /// <summary>
    /// TimeAmount encapsulates a float value
    /// that represents an amount of time.
    /// </summary>
    [Serializable]
    public class TimeAmount
    {
        #region Public Variables
        public float Time => m_time;
        #endregion

        #region Private Variables
        [SerializeField]
        private float m_time = default(float);
        #endregion
    }
}
