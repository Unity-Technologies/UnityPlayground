using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Health System")]
[HelpURL("https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/#HealthSystemAttribute%EF%BC%88HP_%E8%BF%BD%E5%8A%A0%EF%BC%89")]
public class HealthSystemAttribute : MonoBehaviour
{
    public int health = 3;

    private UIScript ui;
    private int maxHealth;

    // Will be set to 0 or 1 depending on how the GameObject is tagged
    // it's -1 if the object is not a player
    // Tag が Player ならば 0、Player2 なら 1、そのどちらでもないなら -1 がセットされる。
    private int playerNumber;

    private void Start()
    {
        // Find the UI in the scene and store a reference for later use
        ui = GameObject.FindObjectOfType<UIScript>();

        // Set the player number based on the GameObject tag
        // Tag によって異なる値を playerNumber に代入する
        switch (gameObject.tag)
        {
            case "Player":
                playerNumber = 0;
                break;
            case "Player2":
                playerNumber = 1;
                break;
            default:
                playerNumber = -1;
                break;
        }

        // Notify the UI so it will show the right initial amount
        // Health の初期値で UI を更新する
        if (ui != null && playerNumber != -1)
        {
            ui.SetHealth(health, playerNumber);
        }

        //note down the maximum health to avoid going over it when the player gets healed
        //回復した時に初期値を超えないように、初期値を Health の最大値として保存しておく
        maxHealth = health;
    }


    // changes the energy from the player
    // also notifies the UI (if present)
    // Health の値を変更し、UI を更新する
    public void ModifyHealth(int amount)
    {
        //avoid going over the maximum health by forcin
        //Health の最大値を超えないようにする
        if (health + amount > maxHealth)
        {
            amount = maxHealth - health;
        }

        health += amount;

        // Notify the UI so it will change the number in the corner
        // UI に表示されている Health の値を更新する
        if (ui != null && playerNumber != -1)
        {
            ui.ChangeHealth(amount, playerNumber);
        }

        //DEAD
        //死んだ
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
