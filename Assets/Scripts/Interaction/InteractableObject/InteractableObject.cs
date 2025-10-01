using SteamVRTest.Patterns.ObjectPoolScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SteamVRTest.Interaction
{
	public class InteractableObject : MonoBehaviour, IPoolable
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private InteractableObjectType _objectType;

		public InteractableObjectType ObjectType => _objectType;

		public event UnityAction<IPoolable> ReturnToPoolEvent;

		public void ReturnToPool()
		{
			_rigidbody.angularVelocity = Vector3.zero;
			gameObject.SetActive(false);
			ReturnToPoolEvent?.Invoke(this);
		}
	}
}
