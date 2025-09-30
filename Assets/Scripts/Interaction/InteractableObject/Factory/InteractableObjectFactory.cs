using System.Linq;
using UnityEngine;

namespace SteamVRTest.Interaction
{
	public class InteractableObjectFactory : InteractableObjectFactoryBase
	{
		[SerializeField]
		private InteractableObjectPool[] _pools;

		public override InteractableObject Create(InteractableObjectType interactableObjectType)
		{
			InteractableObjectPool pool = _pools.First(x => x.InteractableObjectType == interactableObjectType);

			InteractableObject result = pool.GetObjectFromPool();

			result.gameObject.SetActive(true);

			return result;
		}
	}
}
