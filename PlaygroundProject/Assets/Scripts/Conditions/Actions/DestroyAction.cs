using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Destroy Action")]
public class DestroyAction : Action
{
	//who gets destroyed in the collision?
	public Enums.Targets target = Enums.Targets.ObjectThatCollided;
	// assign an effect (explosion? particles?) or object to be created (instantiated) when the one gets destroyed
	public GameObject deathEffect;


	// Happens when this objects hits another one
	public override bool ExecuteAction(GameObject otherObject)
	{
		if(deathEffect != null)
		{
			GameObject newObject = Instantiate<GameObject>(deathEffect);
			//move the effect depending on who needs to be destroyed
			newObject.transform.position = (target == Enums.Targets.ObjectThatCollided) ? otherObject.transform.position : this.transform.position;
		}

		//remove the gameObject from the scene (destroy)
		if(target == Enums.Targets.ObjectThatCollided)
		{
			if(otherObject != null)
			{
				Destroy(otherObject);
				return true;
			}
			else
			{
				return false; //no object is destroyed
			}
		}
		else
		{
			Destroy(gameObject);
			return true;
		}
	}
}
