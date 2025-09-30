using UnityEngine;
using UnityEngine.Events;

namespace SteamVRTest
{
	public class TriggerZone : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent<Collider> _triggerEnterEvent;

		public event UnityAction<Collider> TriggerEnterEvent
		{
			add => _triggerEnterEvent.AddListener(value);
			remove => _triggerEnterEvent.RemoveListener(value);
		}

		[SerializeField]
		private UnityEvent<Collider> _triggerExitEvent;

		public event UnityAction<Collider> TriggerExitEvent
		{
			add => _triggerEnterEvent.AddListener(value);
			remove => _triggerExitEvent.RemoveListener(value);
		}

		private void OnTriggerEnter(Collider other)
		{
			_triggerEnterEvent?.Invoke(other);
		}

		private void OnTriggerExit(Collider other)
		{
			_triggerExitEvent.Invoke(other);
		}
	}
}
