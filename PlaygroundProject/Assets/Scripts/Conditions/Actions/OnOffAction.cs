using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/On-Off")]
public class OnOffAction : Action
{
	public GameObject objectToAffect;
	public bool justMakeInvisible;


	// Changes the object state from active to inactive, and viceversa
	public override bool ExecuteAction(GameObject dataObject)
	{
		if(objectToAffect != null)
		{
			if(!justMakeInvisible)
			{
				objectToAffect.SetActive(!objectToAffect.activeSelf);
			}
			else
			{
				//in this case, we just make the object invisible
				SpriteRenderer sr = objectToAffect.GetComponent<SpriteRenderer>();
				if(sr != null)
				{
					sr.enabled = !sr.enabled;					
				}
				else
				{
					//the object doesn't have a Sprite Renderer component so the action can't be performed!
					return false;
				}
			}

			return true;
		}
		else
		{
			return false;
		}
	}
}
