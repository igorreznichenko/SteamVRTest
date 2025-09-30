using TMPro;
using UnityEngine;

namespace SteamVRTest
{
	public class ScorePanel : MonoBehaviour
	{
		[SerializeField]
		private ScoreManager _scoreManager;

		[SerializeField]
		private TMP_Text _score;

		private void Start()
		{
			_score.text = _scoreManager.Score.ToString();
		}

		private void OnEnable()
		{
			SubscribeEvents();
		}

		private void OnDisable()
		{
			UnsubscribeEvents();
		}

		private void SubscribeEvents()
		{
			_scoreManager.ScoreChangedEvent += OnScoreChangedEventHandler;
		}

		private void UnsubscribeEvents()
		{
			_scoreManager.ScoreChangedEvent -= OnScoreChangedEventHandler;
		}

		private void OnScoreChangedEventHandler(int score)
		{
			_score.text = score.ToString();
		}
	}
}
