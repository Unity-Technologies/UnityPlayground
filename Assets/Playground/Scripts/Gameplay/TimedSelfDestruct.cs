using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Gameplay/Timed Self-Destruct")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#TimedSelfDestruct%EF%BC%88%E4%B8%80%E5%AE%9A%E6%99%82%E9%96%93%E5%BE%8C%E3%81%AB%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%82%92%E6%B6%88%E3%81%99%EF%BC%89")]
public class TimedSelfDestruct : MonoBehaviour
{
    // After this time, the object will be destroyed
    // この秒数が経過した時にオブジェクトを破棄する
    public float timeToDestruction;

    void Start()
    {
        Invoke("DestroyMe", timeToDestruction);
    }

    // This function will destroy this object :(
    void DestroyMe()
    {
        Destroy(gameObject);

        // Bye bye!
    }
}
