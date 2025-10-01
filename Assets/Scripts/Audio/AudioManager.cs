using SteamVRTest.Extensions;
using UnityEngine;

namespace SteamVRTest.Audio
{
	public class AudioManager : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _audioSource;

		public void Play(Sound sound)
		{
			Stop();

			_audioSource.SetSound(sound);
			_audioSource.Play();
		}

		public void Stop()
		{
			if (_audioSource.isPlaying)
			{
				_audioSource.Stop();
			}
		}
	}
}
