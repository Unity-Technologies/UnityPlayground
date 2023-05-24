using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("")]
public class UIItemScript : MonoBehaviour
{
	public Image resourceIcon;
	public Text resourceAmount;

	public void ShowNumber(int n)
	{
		resourceAmount.text = n.ToString();
	}

	public void DisplayIcon(Sprite s)
	{
		resourceIcon.sprite = s;
	}
}
