using SteamVRTest.Patterns.ObjectPoolScripts;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

namespace SteamVRTest.Interaction
{
	public class InteractableObject : MonoBehaviour, IPoolable
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private InteractableObjectType _objectType;

		[SerializeField]
		private InteractableHoverEvents _hoverEvents;

		#region Events
		public event UnityAction HandHoverBeginEvent
		{
			add => _hoverEvents.onHandHoverBegin.AddListener(value);
			remove => _hoverEvents.onHandHoverBegin.RemoveListener(value);
		}

		public event UnityAction HandHoverEndEvent
		{
			add => _hoverEvents.onHandHoverEnd.AddListener(value);
			remove => _hoverEvents.onHandHoverEnd.RemoveListener(value);
		}

		public event UnityAction OnAttachedToHandEvent
		{
			add => _hoverEvents.onAttachedToHand.AddListener(value);
			remove => _hoverEvents.onAttachedToHand.RemoveListener(value);
		}

		public event UnityAction OnDetachedFromHandEvent
		{
			add => _hoverEvents.onDetachedFromHand.AddListener(value);
			remove => _hoverEvents.onDetachedFromHand.RemoveListener(value);
		}
		#endregion

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
