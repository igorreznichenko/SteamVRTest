using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SteamVRTest.Interaction
{
	public class InteractableManager : MonoBehaviour
	{
		[SerializeField]
		private InteractableObjectFactoryBase _factory;

		[SerializeField]
		private SpawnPoint[] _spawnPoints;

		private List<InteractableObject> _interacrables = new List<InteractableObject>();

		public void CreateInteractable(InteractableObjectType objectType)
		{
			InteractableObject interactableObject = _factory.Create(objectType);

			SpawnPoint spawnPoint = _spawnPoints.First(x => x.Target == objectType);

			interactableObject.transform.SetPositionAndRotation(spawnPoint.transform.position, spawnPoint.transform.rotation);

			_interacrables.Add(interactableObject);
		}

		public void ClearInteractables()
		{
			_interacrables.ForEach(x => x.ReturnToPool());

			_interacrables.Clear();
		}
	}
}
