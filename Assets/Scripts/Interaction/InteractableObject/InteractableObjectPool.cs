using SteamVRTest.Interaction;
using SteamVRTest.Patterns.ObjectPoolScripts;

namespace SteamVRTest.Interaction
{
	public class InteractableObjectPool : ObjectPool<InteractableObject>
	{
		public InteractableObjectType InteractableObjectType
		{
			get
			{
				InteractableObject interactableObject = _prefabObject.GetComponent<InteractableObject>();

				return interactableObject.ObjectType;
			}
		}
	}
}
