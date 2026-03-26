using Playground.BaseClasses;
using Playground.Utilities;
using UnityEngine;

namespace Playground.Conditions.Actions
{
	[AddComponentMenu("Playground/Actions/Destroy Action")]
	public class DestroyAction : Action
	{
		//who gets destroyed in the collision?
		public Enums.Targets target = Enums.Targets.ObjectThatCollided;
		// assign an effect (explosion? particles?) or object to be created (instantiated) when the one gets destroyed
		public GameObject deathEffect;


		//OtherObject is null when this Action is called from a Condition that is not collision-based
		public override bool ExecuteAction(GameObject otherObject)
		{
			if(deathEffect != null)
			{
				GameObject newObject = Instantiate<GameObject>(deathEffect);
			
				//move the effect depending on who needs to be destroyed
				Vector3 otherObjectPos = (otherObject == null) ? transform.position : otherObject.transform.position;
				newObject.transform.position = (target == Enums.Targets.ObjectThatCollided) ? otherObjectPos : transform.position;
			}

			//remove the GameObject from the scene (destroy)
			if(target == Enums.Targets.ObjectThatCollided)
			{
				if(otherObject != null)
				{
					Destroy(otherObject);
				}
			}
			else
			{
				Destroy(gameObject);
			}

			return true; //always returns true
		}
	}
}
