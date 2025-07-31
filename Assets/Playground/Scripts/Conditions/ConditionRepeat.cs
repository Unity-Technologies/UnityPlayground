using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Playground/Conditions/Condition Repeat")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#ConditionRepeat%EF%BC%88%E4%B8%80%E5%AE%9A%E6%99%82%E9%96%93%E3%81%8A%E3%81%8D%E3%81%AB%E3%82%A2%E3%82%AF%E3%82%B7%E3%83%A7%E3%83%B3%E3%82%92%E7%99%BA%E5%8B%95%E3%81%99%E3%82%8B%EF%BC%89")]
public class ConditionRepeat : ConditionBase
{
    public float initialDelay = 0f;
    public float frequency = 1f;

    private float timeLastEventFired;

    private void Start()
    {
        timeLastEventFired = initialDelay - frequency;
    }

    private void Update()
    {
        if (Time.time >= timeLastEventFired + frequency)
        {
            ExecuteAllActions(null);
            timeLastEventFired = Time.time;
        }
    }
}