using System;
using UnityEngine;

namespace DogHouse.Core.Data
{
    /// <summary>
    /// Logos contains a collection
    /// of Logos. 
    /// </summary>
    [Serializable]
    public class Logos 
    {
        #region Public Variables
        public Logo[] LogosValue => m_logos;
        #endregion

        #region Private Variables
        [SerializeField]
        private Logo[] m_logos = null;
        #endregion
    }
}
