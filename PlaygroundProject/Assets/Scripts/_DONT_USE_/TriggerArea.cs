using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class TriggerArea : MonoBehaviour
{
	// if true, the trigger reacts only to the player
	public bool playerOnly = false;

	protected bool CheckIfPlayerOnly(Collider2D other)
	{
		if(playerOnly)
		{
			if(other.gameObject.CompareTag("Player")
				|| other.gameObject.CompareTag("Player2"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return true;
		}
	}
}
