using SteamVRTest.Interaction;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace SteamVRTest.UI
{
	public class BoardPanel : MonoBehaviour
	{
		[SerializeField]
		private InteractableManager _interactableManager;

		[Header("UI")]
		[SerializeField]
		private UIElement _addCubeButton;

		[SerializeField]
		private UIElement _addSphereButton;

		[SerializeField]
		private UIElement _removeAllButton;

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
			_addCubeButton.onHandClick.AddListener(OnAddCubeButtonClickEventHandler);
			_addSphereButton.onHandClick.AddListener(OnAddSphereButtonClickEventHandler);
			_removeAllButton.onHandClick.AddListener(OnRemoveAllButtonClickEventHandler);
		}

		private void UnsubscribeEvents()
		{
			_addCubeButton.onHandClick.RemoveListener(OnAddCubeButtonClickEventHandler);
			_addSphereButton.onHandClick.RemoveListener(OnAddSphereButtonClickEventHandler);
			_removeAllButton.onHandClick.RemoveListener(OnRemoveAllButtonClickEventHandler);
		}

		public void Initialize(InteractableManager interactableManager)
		{
			_interactableManager = interactableManager;
		}

		private void OnAddCubeButtonClickEventHandler(Hand arg0)
		{
			_interactableManager.CreateInteractable(InteractableObjectType.Cube);
		}

		private void OnAddSphereButtonClickEventHandler(Hand arg0)
		{
			_interactableManager.CreateInteractable(InteractableObjectType.Sphere);
		}

		private void OnRemoveAllButtonClickEventHandler(Hand arg0)
		{
			_interactableManager.ClearInteractables();
		}
	}
}