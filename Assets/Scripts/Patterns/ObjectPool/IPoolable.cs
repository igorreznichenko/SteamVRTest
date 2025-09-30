using UnityEngine.Events;

namespace SteamVRTest.Patterns.ObjectPoolScripts
{
	public interface IPoolable
	{
		public event UnityAction<IPoolable> ReturnToPoolEvent;

		public void ReturnToPool();
	}
}
