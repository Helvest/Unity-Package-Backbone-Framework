using System;
using HelvestSL;
using StypeMachine;
using UnityEngine;

namespace BackboneFramework
{
	[RequireComponent(typeof(MonoServiceLocator))]
	[RequireComponent(typeof(MonoTypeMachine))]
	public abstract class Backbone : MonoBehaviour
	{

		#region Variables

		[field: SerializeField]
		public MonoServiceLocator SL { get; private set; } = default;

		[field: SerializeField]
		public MonoTypeMachine SM { get; private set; } = default;

		[Header("Configs")]
		[SerializeField]
		private bool _dontDestroyOnLoad = true;

		#endregion

		#region Init

		protected virtual void Awake()
		{
			if (_dontDestroyOnLoad)
			{
				DontDestroyOnLoad(gameObject);
			}
		}

		protected virtual void OnEnable()
		{
			SL.Add(this);
		}

		protected virtual void OnDisable()
		{
			SL.Remove(this);
		}

		#endregion

		#region Service Locator

		public bool Add<T>(T instance) where T : MonoBehaviour
		{
			return SL.Add(instance);
		}

		public bool Remove<T>() where T : class
		{
			return SL.Remove<T>();
		}

		public bool TryGetIfNull<T>(ref T instance, Action<T> callback = null) where T : class
		{
			return SL.TryGetIfNull(ref instance, callback);
		}

		#endregion

		#region State Machine

		public void SetState<t>() where t : MonoBehaviour
		{
			SM.SetState<t>();
		}

		public void SetState<t>(t instance) where t : MonoBehaviour
		{
			SM.SetState(instance);
		}

		public void SetState(Type type)
		{
			SM.SetState(type);
		}

		public Type State
		{
			get => SM.State;
			set => SM.State = value;
		}

		#endregion

		#region OnValidate

		protected virtual void OnValidate()
		{
			if (SL == null)
			{
				SL = GetComponent<MonoServiceLocator>();
			}

			if (SM == null)
			{
				SM = GetComponent<MonoTypeMachine>();
			}
		}

		#endregion

	}

}
