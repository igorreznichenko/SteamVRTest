using SteamVRTest.Audio;
using SteamVRTest.Interaction;
using SteamVRTest.UI;
using UnityEngine;

namespace SteamVRTest.Entry
{
	public class MainSceneEntryPoint : MonoBehaviour
	{
		[Header("Managers")]
		[SerializeField]
		private ScoreManager _scoreManager;

		[SerializeField]
		private InteractableManager _interactableManager;

		[Header("UI")]
		[SerializeField]
		private ScorePanel _scorePanel;

		[SerializeField]
		private BoardPanel _boardPanel;

		[Header("Audio")]
		[SerializeField]
		private AudioManager _audioManager;

		[SerializeField]
		private Sound _grabSound;

		private void Start()
		{
			Initialize();
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
			_interactableManager.CreateInteractableObjectEvent += OnCreateInteractableObjectEventHandler;
			_interactableManager.RemoveInteractableObjectEvent += OnRemoveInteractableObjectEventHandler;
		}

		private void UnsubscribeEvents()
		{
			_interactableManager.CreateInteractableObjectEvent -= OnCreateInteractableObjectEventHandler;
			_interactableManager.RemoveInteractableObjectEvent -= OnRemoveInteractableObjectEventHandler;
		}

		private void OnCreateInteractableObjectEventHandler(InteractableObject interactableObject)
		{
			interactableObject.OnAttachedToHandEvent += PlayGrabAudio;
		}

		private void OnRemoveInteractableObjectEventHandler(InteractableObject interactableObject)
		{
			interactableObject.OnAttachedToHandEvent -= PlayGrabAudio;
		}

		private void Initialize()
		{
			_scorePanel.Initialize(_scoreManager);
			_boardPanel.Initialize(_interactableManager);
		}

		private void PlayGrabAudio()
		{
			_audioManager.Play(_grabSound);
		}
	}
}
