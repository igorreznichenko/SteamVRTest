using SteamVRTest.Audio;
using UnityEngine;

namespace SteamVRTest.Extensions
{
	public static class AudioSourceExtensions
	{
		public static void SetSound(this AudioSource audioSource, Sound sound)
		{
			audioSource.clip = sound.Clip;
			audioSource.volume = sound.Volume;
		}
	}
}
