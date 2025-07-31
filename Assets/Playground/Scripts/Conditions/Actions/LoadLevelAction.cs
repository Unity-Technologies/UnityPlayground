using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("Playground/Actions/Load Level")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#LoadLevelAction%EF%BC%88%E3%82%B7%E3%83%BC%E3%83%B3%E3%82%92%E5%88%87%E3%82%8A%E6%9B%BF%E3%81%88%E3%82%8B%EF%BC%89")]
public class LoadLevelAction : Action
{
    public string levelName = SAME_SCENE;

    public const string SAME_SCENE = "0";

    //Loads a new Unity scene, or reload the current one (it means all objects are reset)
    //別のシーンをロードするか、もしくは現在のシーンをリロードする。リロードすると全てのオブジェクトはリセットされる。
    public override bool ExecuteAction(GameObject dataObject)
    {
        if (levelName == SAME_SCENE)
        {
            //just restart the level
            //現在のシーンをリロードする
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        else
        {
            //load another scene
            //別のシーン（指定されたシーン）をロードする
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }

        return true;
    }
}