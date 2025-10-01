using UnityEngine;

namespace SteamVRTest.Audio
{
	[CreateAssetMenu(fileName = "Sound", menuName = "Scriptable Objects/Sound")]
	public class Sound : ScriptableObject
	{
		[SerializeField]
		private AudioClip _clip;

		[Range(0, 1)]
		[SerializeField]
		private float _volume;

		public AudioClip Clip => _clip;

		public float Volume => _volume;
	}
}
