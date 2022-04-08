using HelvestSL;
using StypeMachine;
using UnityEngine;

[RequireComponent(typeof(MonoServiceLocator))]
[RequireComponent(typeof(MonoTypeMachine))]
public abstract class Backbone : MonoBehaviour, IHoldSL, IHoldTM
{

	#region Variables

	public ServiceLocator SL => ServiceLocator.SL;

	[field: SerializeField, Header("Backbone")]
	public MonoServiceLocator ServiceLocator { get; private set; } = default;

	public TypeMachine TM => StateMachine.TM;

	[field: SerializeField]
	public MonoTypeMachine StateMachine { get; private set; } = default;

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

	#region OnValidate

	protected virtual void OnValidate()
	{
		if (ServiceLocator == null)
		{
			ServiceLocator = GetComponent<MonoServiceLocator>();
		}

		if (StateMachine == null)
		{
			StateMachine = GetComponent<MonoTypeMachine>();
		}
	}

	#endregion

}
