using UnityEngine;

namespace SteamVRTest.Interaction
{
	public class SpawnPoint : MonoBehaviour
	{
		[SerializeField]
		private InteractableObjectType _target;

		public InteractableObjectType Target => _target;
	}
}
