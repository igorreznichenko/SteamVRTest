using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

namespace SteamVRTest
{
	public class LaserPointer : SteamVR_LaserPointer
	{
		public override void OnPointerIn(PointerEventArgs e)
		{
			base.OnPointerIn(e);

			if (e.target != null)
			{
				InputModule.instance.HoverBegin(e.target.gameObject);
			}
		}

		public override void OnPointerClick(PointerEventArgs e)
		{
			base.OnPointerClick(e);

			if (e.target != null)
			{
				InputModule.instance.Submit(e.target.gameObject);

				if (e.target.TryGetComponent(out Button button))
				{
					button.onClick?.Invoke();
				}
			}
		}

		public override void OnPointerOut(PointerEventArgs e)
		{
			base.OnPointerOut(e);

			if (e.target != null)
			{
				InputModule.instance.HoverEnd(e.target.gameObject);
			}
		}
	}
}
