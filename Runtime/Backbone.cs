using UnityEngine;

[RequireComponent(typeof(MonoServiceLocator))]
[RequireComponent(typeof(MonoTypeMachine))]
public abstract class Backbone : MonoBehaviour
{

	#region Variables

	[field: SerializeField, Header("Backbone")]
	public MonoServiceLocator SL { get; private set; } = default;

	[field: SerializeField]
	public MonoTypeMachine TM { get; private set; } = default;

	#endregion

	#region Init

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
		if (SL == null)
		{
			SL = GetComponent<MonoServiceLocator>();
		}

		if (TM == null)
		{
			TM = GetComponent<MonoTypeMachine>();
		}
	}

	#endregion

}
