using System.Collections.Generic;
using System;
using static UnityEngine.Debug;

namespace DogHouse.Core.Services
{
    /// <summary>
    /// The Service Locator is a singleton
    /// class that allows for the registering
    /// of callbacks and access to individual
    /// services.
    /// </summary>
	public sealed class ServiceLocator 
	{
		#region Private Variables
		private static ServiceLocator m_instance;

        private static Dictionary < string, object > m_serviceDictionary
        {
            get
            {
                if (m_instance == null) Initialize();
                return serviceDictionary;
            }

            set{ serviceDictionary = value; }
        }
		
        private static Dictionary < string, List<Action>> m_callbackDictionary
        {
            get
            {
                if (m_instance == null) Initialize();
                return callbackDictionary;
            }

            set{ callbackDictionary = value; }
        }

        private static Dictionary<string, object>       serviceDictionary;
        private static Dictionary<string, List<Action>> callbackDictionary;
		#endregion

		#region Main Methods
		public static void Register < T >(T service)
		{
            if (CheckServiceIsRegistered<T>())  ReplaceServiceInstance<T>(service);
            if (!CheckServiceIsRegistered<T>()) SetServiceInstance    <T>(service);
            DispatchRegistrationHandles <T>();
		}

		public static void Unregister<T>(object Service)
		{
			if (!CheckServiceIsRegistered<T> ())    return;
            if (FetchService<T>() == null)          return;
            if (!FetchService<T>().Equals(Service)) return;

            UnregisterService<T>();
		}

		public static T FetchService <T>() =>
                CheckServiceIsRegistered<T>() 
                    ? FetchServiceInstance<T>() 
                    : default(T);

		public static void AddRegistrationHandler<T>(Action callback)
		{
			if (CheckServiceIsRegistered<T> ()) callback ();
			AddHandle<T> (callback);
		}
		#endregion

		#region Utility Methods
        private static void ReplaceServiceInstance<T>(T NewService)
		{
            SendServiceReplacementWarning<T>();
            m_serviceDictionary[typeof(T).Name] = NewService;
		}

		private static void DispatchRegistrationHandles<T>()
		{
            if (!CheckHandleIsRegistered<T>()) return;
		    DispatchHandles (m_callbackDictionary [typeof(T).Name]);
		}
		#endregion

		#region Low Level Functions
		private static void RemoveHandles<T>()
		{
			if (!CheckHandleIsRegistered<T> ()) return;
			m_callbackDictionary.Remove (typeof(T).Name);
		}

		private static void Initialize()
		{
			if (m_instance != null) return;

			m_instance           = new ServiceLocator ();
			serviceDictionary    = new Dictionary < string, object >();
			callbackDictionary   = new Dictionary < string, List<Action>> ();
		}

		private static void AddHandle<T>(Action Handle)
		{
			if(!CheckHandleIsRegistered<T>())
				m_callbackDictionary [typeof(T).Name] = new List<Action> ();

			m_callbackDictionary [typeof(T).Name].Add (Handle);
		}

		private static void DispatchHandles(List<Action> Handles)
		{
			foreach (Action handle in Handles) handle?.Invoke();
		}

        private static bool CheckHandleIsRegistered<T>()        =>
            m_callbackDictionary.ContainsKey(typeof(T).Name);

		private static void UnregisterService<T>()              =>
			m_serviceDictionary [typeof(T).Name] = default(T);

        private static void SendServiceReplacementWarning<T>()  =>
            LogWarning($"Service : {typeof(T).Name} is being replaced.");

        private static bool CheckServiceIsRegistered<T>()       =>
            m_serviceDictionary.ContainsKey(typeof(T).Name);

        private static T FetchServiceInstance<T>()              =>
            (T)m_serviceDictionary[typeof(T).Name];

        private static void SetServiceInstance<T>(T instance)   =>
            m_serviceDictionary[typeof(T).Name] = instance;

        #endregion
    }
}
