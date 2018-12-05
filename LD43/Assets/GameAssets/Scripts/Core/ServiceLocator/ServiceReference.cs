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
		public T Reference => ServiceLocator.FetchService<T>();
		#endregion

		#region Main Methods
		public void AddRegistrationHandle(Action Handle) =>
			ServiceLocator.AddRegistrationHandler<T> (Handle);

		public bool IsRegistered() => (Reference != null);
		#endregion
	}
}
