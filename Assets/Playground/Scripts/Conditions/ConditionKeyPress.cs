using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Key Press")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/#ConditionKeyPress%EF%BC%88%E6%8C%87%E5%AE%9A%E3%81%97%E3%81%9F%E3%82%AD%E3%83%BC%E3%81%8C%E6%8A%BC%E3%81%95%E3%82%8C%E3%81%9F%E3%82%89%E3%82%A2%E3%82%AF%E3%82%B7%E3%83%A7%E3%83%B3%E3%82%92%E7%99%BA%E5%8B%95%E3%81%99%E3%82%8B%EF%BC%89")]
public class ConditionKeyPress : ConditionBase
{
    public KeyCode keyToPress = KeyCode.Space;

    [Header("Type of Event")]
    public KeyEventTypes eventType = KeyEventTypes.JustPressed;

    public float frequency = 0.5f;
    private float timeLastEventFired;

    private void Start()
    {
        timeLastEventFired = -frequency;
    }

    private void Update()
    {
        switch (eventType)
        {
            case KeyEventTypes.JustPressed:
                if (Input.GetKeyDown(keyToPress))
                {
                    ExecuteAllActions(null);
                }
                break;
            case KeyEventTypes.Released:
                if (Input.GetKeyUp(keyToPress))
                {
                    ExecuteAllActions(null);
                }
                break;
            case KeyEventTypes.KeptPressed:
                if (Time.time >= timeLastEventFired + frequency
                    && Input.GetKey(keyToPress))
                {
                    ExecuteAllActions(null);
                    timeLastEventFired = Time.time;
                }
                break;
        }
    }




    public enum KeyEventTypes
    {
        JustPressed,
        Released,
        KeptPressed
    }



}