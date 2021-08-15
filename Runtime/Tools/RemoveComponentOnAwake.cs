using UnityEngine;

namespace Helvest.Tools
{

	public class RemoveComponentOnAwake : MonoBehaviour
	{
		[SerializeField]
		private Component _target;

		private void Awake()
		{
			Destroy(_target);
			Destroy(this);
		}

	}
}
