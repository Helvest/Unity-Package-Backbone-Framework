using StypeMachine;
using UnityEngine;

namespace Helvest.Framework
{

	public abstract class GameModeBase : MonoBehaviour, IState
	{
		public GameManager GameManager { get; private set; }

		protected virtual void Start()
		{
			GameManager = SL.Get<GameManager>();
		}

		protected virtual void OnEnable()
		{
			SL.AddOrDestroy(this);
		}

		protected virtual void OnDisable()
		{
			SL.Remove(this);
		}

		public virtual void EnterState()
		{
			if (useDebug)
			{
				Debug.Log("Enter Mode " + GetType().Name);
			}
		}

		public virtual void ExitState()
		{
			if (useDebug)
			{
				Debug.Log("Exit Mode " + GetType().Name);
			}
		}

		public virtual void UpdateState() { }

		public bool useDebug = false;

	}
}
