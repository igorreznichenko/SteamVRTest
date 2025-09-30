using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SteamVRTest.Patterns.ObjectPoolScripts
{
	public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
	{
		[SerializeField]
		protected GameObject _prefabObject;

		[SerializeField]
		private Transform _parent;

		[SerializeField]
		private List<T> _freeObjects = new List<T>();

		private List<T> _busyObjects = new List<T>();

		public virtual T GetObjectFromPool()
		{
			T result;

			if (_freeObjects.Count > 0)
			{
				result = _freeObjects.First();

				ApplyTransform(result);

				_freeObjects.Remove(result);
				_busyObjects.Add(result);
			}
			else
			{
				GameObject resultGameObject = Instantiate(_prefabObject, Vector3.zero, Quaternion.identity);

				result = resultGameObject.GetComponent<T>();

				ApplyTransform(result);

				_busyObjects.Add(result);
			}

			result.ReturnToPoolEvent += OnReturnObjectToPool;

			return result;
		}

		private void ApplyTransform(T pooledObject)
		{
			pooledObject.transform.SetParent(_parent, false);
			pooledObject.transform.SetAsLastSibling();
		}

		private void OnReturnObjectToPool(IPoolable obj)
		{
			obj.ReturnToPoolEvent -= OnReturnObjectToPool;

			_freeObjects.Add((T)obj);
			_busyObjects.Remove((T)obj);
		}
	}
}
