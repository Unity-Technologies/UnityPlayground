using UnityEngine;
using System.Collections;

public class DestroyAction : MonoBehaviour, IGameplayAction
{
	//who gets destroyed in the collision?
	public Enums.Targets target = Enums.Targets.OtherObject;
	// assign an effect (explosion? particles?) or object to be created (instantiated) when the one gets destroyed
	public GameObject deathEffect;


	// Happens when this objects hits another one
	public void ExecuteAction(GameObject otherObject)
	{
		if(deathEffect != null)
		{
			GameObject newObject = Instantiate<GameObject>(deathEffect);
			//move the effect depending on who needs to be destroyed
			newObject.transform.position = (target == Enums.Targets.OtherObject) ? otherObject.transform.position : this.transform.position;
		}

		//remove the gameObject from the scene (destroy)
		if(target == Enums.Targets.OtherObject)
		{
			Destroy(otherObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
