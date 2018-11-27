using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DogHouse.Core.Services
{
    /// <summary>
    /// The Service Reference is a class that
    /// contains the reference from the Service
    /// Locator to a particular Service.
    /// </summary>
	public class ServiceReference<T> where T: class
	{
		#region Public Variables
		public T Reference => ServiceLocator.GetService<T>();
		#endregion

		#region Private Variables
		private T instance;
		#endregion

		#region Main Methods
		public void AddRegistrationHandle(Action Handle)
		{
			ServiceLocator.AddOnRegisterHandle<T> (Handle);
		}

		public bool isRegistered() => (Reference == null) ? false : true;
		#endregion
	}
}
