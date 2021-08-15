#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using StypeMachine;

namespace Helvest.Framework
{

	public class GameManager : TypeMachineController<GameModeBase>
	{

		#region Init

		protected override void Awake()
		{
#if UNITY_EDITOR
			SL.useDebugLog = useDebugForSL;
#endif
			base.Awake();

			var states = GetComponentsInChildren<GameModeBase>();

			foreach (var state in states)
			{
				AddState(state, state.EnterState, state.ExitState, state.UpdateState);
			}
		}

		protected override void OnEnable()
		{
			if (!SL.AddOrDestroy(this))
			{
				return;
			}

			if (_startState == null)
			{
				Debug.LogError("startState is null, GameManger can't start", this);

#if UNITY_EDITOR
				EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
				return;
			}

			SetState(_startState);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			SL.Remove(this);
		}

		#endregion

		#region Update

		protected virtual void Update()
		{
			typeMachine.UpdateState();
		}

		#endregion

		#region Debug

#if UNITY_EDITOR
		public bool useDebugForSL = false;
#endif

		#endregion

	}

}
