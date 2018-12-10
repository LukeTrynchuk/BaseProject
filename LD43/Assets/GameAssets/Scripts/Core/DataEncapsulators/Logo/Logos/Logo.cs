using UnityEngine;
using DogHouse.Core.Logo;
using System;

namespace DogHouse.Core.Data
{
    /// <summary>
    /// Logo class encapsulates a 
    /// Splash Screen scriptable object.
    /// </summary>
    [Serializable]
    public class Logo
    {
        #region Public Variables
        public SplashScreen LogoValue => m_logo;
        #endregion

        #region Private Variables
        [SerializeField]
        private SplashScreen m_logo = default(SplashScreen);
        #endregion
    }
}
