using UnityEngine;

namespace SteamVRTest.Interaction
{
	public abstract class InteractableObjectFactoryBase : MonoBehaviour
	{
		public abstract InteractableObject Create(InteractableObjectType interactableObjectType);
	}
}
