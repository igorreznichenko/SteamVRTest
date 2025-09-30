using SteamVRTest.Patterns.ObjectPoolScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SteamVRTest.Interaction
{
	public class InteractableObject: MonoBehaviour, IPoolable
	{
		[SerializeField]
		private InteractableObjectType _objectType;

		public InteractableObjectType ObjectType => _objectType;

		public event UnityAction<IPoolable> ReturnToPoolEvent;

		public void ReturnToPool()
		{
			gameObject.SetActive(false);
			ReturnToPoolEvent?.Invoke(this);
		}
	}
}
