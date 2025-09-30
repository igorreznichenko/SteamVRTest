using UnityEngine;
using UnityEngine.Events;

namespace SteamVRTest
{
	public class ScoreManager : MonoBehaviour
	{
		private int _score = 0;

		public int Score
		{
			get => _score;
			set
			{
				if (_score != value)
				{
					_score = value;
					OnScoreChanged(value);
				}
			}
		}

		public event UnityAction<int> ScoreChangedEvent = default;

		private void OnScoreChanged(int value)
		{
			ScoreChangedEvent?.Invoke(value);
		}

		public void AddScore(int score)
		{
			Score += score;
		}
	}
}
