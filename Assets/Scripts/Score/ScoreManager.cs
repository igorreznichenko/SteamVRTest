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
			private	set
			{
				if (_score != value)
				{
					_score = value;
					OnScoreChanged(value);
				}
			}
		}

		#region Events
		[SerializeField]
		private UnityEvent<int> _scoreChangedEvent;

		public event UnityAction<int> ScoreChangedEvent
		{
			add => _scoreChangedEvent.AddListener(value);
			remove => _scoreChangedEvent.RemoveListener(value);
		}

		[SerializeField]
		private UnityEvent<int> _pointsRewardedEvent;

		public event UnityAction<int> PointsRewardedEvent
		{
			add => _pointsRewardedEvent.AddListener(value);
			remove => _pointsRewardedEvent.RemoveListener(value);
		}

		private void OnScoreChanged(int value)
		{
			_scoreChangedEvent?.Invoke(value);
		}
		#endregion

		private const int MIN_SCORE_VALUE = 0;

		public void AddScore(int score)
		{
			Score += score;
			_pointsRewardedEvent?.Invoke(score);
		}

		public void ResetScore()
		{
			Score = MIN_SCORE_VALUE;
		}
	}
}
