using Playground.BaseClasses;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Playground.Conditions.Actions
{
    [AddComponentMenu("Playground/Actions/Load Level")]
    public class LoadLevelAction : Action
    {
        public const string SAME_SCENE = "0";
        public string levelName = SAME_SCENE;


        //Loads a new Unity scene, or reload the current one (it means all objects are reset)
        public override bool ExecuteAction(GameObject dataObject)
        {
            if (levelName == SAME_SCENE)
                //just restart the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            else
                //load another scene
                SceneManager.LoadScene(levelName, LoadSceneMode.Single);

            return true;
        }
    }
}