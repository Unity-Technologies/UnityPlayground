using Playground.Scripts.Utilities;
using UnityEngine;

namespace Playground.Attributes
{
	[AddComponentMenu("Playground/Attributes/Bullet")]
	public class BulletAttribute : MonoBehaviour
	{
		[HideInInspector]
		public int playerId;

		//This will create a dialog window asking for which dialog to add
		private void Reset()
		{
			Utils.Collider2DDialogWindow(gameObject, true);
		}
	}
}
