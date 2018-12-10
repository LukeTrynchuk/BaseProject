using UnityEngine;
using System;
using static UnityEngine.Mathf;

namespace DogHouse.Core.Data
{
    /// <summary>
    /// LowHighBounds encapsulates two floats that
    /// represent a low and high bound. 
    /// </summary>
    [Serializable]
    public class LowHighBounds
    {
        #region Public Variables
        public float Low => GetLowBound();
        public float High => GetHighBound();
        #endregion

        #region Private Variables
        [SerializeField]
        private float m_boundOne = default(float);

        [SerializeField]
        private float m_boundTwo = default(float);
        #endregion
        
        #region Main Methods
        private float GetLowBound() => Min(m_boundOne, m_boundTwo);
        private float GetHighBound() => Max(m_boundOne, m_boundTwo);
        #endregion
    }
}
