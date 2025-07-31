using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Destroy Action")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#DestroyAction%EF%BC%88%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%82%92%E7%A0%B4%E5%A3%8A%E3%81%99%E3%82%8B%EF%BC%89")]
public class DestroyAction : Action
{
	//who gets destroyed in the collision?
	//どのオブジェクトが破棄されるかを設定する
	public Enums.Targets target = Enums.Targets.ObjectThatCollided;
	// assign an effect (explosion? particles?) or object to be created (instantiated) when the one gets destroyed
	//爆発エフェクトやパーティクルエフェクトのプレハブを指定できる。オブジェクトが破棄された時にその場に生成するオブジェクト（プレハブ）を指定する。
	public GameObject deathEffect;


	//OtherObject is null when this Action is called from a Condition that is not collision-based
	//変数 otherObject には衝突相手が渡されるが、衝突と関係ない Action で破棄された場合は otherObject には null が渡される。
	public override bool ExecuteAction(GameObject otherObject)
	{
		if(deathEffect != null)
		{
			GameObject newObject = Instantiate<GameObject>(deathEffect);
			
			//move the effect depending on who needs to be destroyed
			//相手が破棄されるのか、自分が破棄されるのかによってエフェクトが生成される座標を変える
			Vector3 otherObjectPos = (otherObject == null) ? this.transform.position : otherObject.transform.position;
			newObject.transform.position = (target == Enums.Targets.ObjectThatCollided) ? otherObjectPos : this.transform.position;
		}

		//remove the GameObject from the scene (destroy)
		//オブジェクトを破棄する（シーンから取り除く）
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

        //always returns true
		//常に true を返す
        return true;
	}
}
