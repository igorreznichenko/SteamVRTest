using TMPro;
using UnityEngine;

namespace SteamVRTest.UI
{
	public class ScorePanel : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _score;

		private ScoreManager _scoreManager;

		public void Initialize(ScoreManager scoreManager)
		{
			UnsubscribeCurrentScoreManager();

			_scoreManager = scoreManager;
			_score.text = scoreManager.Score.ToString();
			_scoreManager.ScoreChangedEvent += OnScoreChangedEventHandler;
		}

		private void UnsubscribeCurrentScoreManager()
		{
			if (_scoreManager != null)
			{
				_scoreManager.ScoreChangedEvent -= OnScoreChangedEventHandler;
			}
		}

		private void OnScoreChangedEventHandler(int score)
		{
			_score.text = score.ToString();
		}

		private void OnDestroy()
		{
			UnsubscribeCurrentScoreManager();
		}
	}
}
