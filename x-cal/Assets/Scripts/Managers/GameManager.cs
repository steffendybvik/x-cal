using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int lootObjectsCollected;
    public int enemiesKilled;
    public Text scoreText;

    private int numberOfObjects;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        lootObjectsCollected = 0;
        FindObjects();
        scoreText.text = "Objects collected: " + lootObjectsCollected.ToString() + " / " + numberOfObjects.ToString() +
            " /n Enemies killed: ";
    }

    
    private void FindObjects() {
        numberOfObjects = GameObject.FindGameObjectsWithTag("LootObject").Length;
        numberOfObjects = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void AddScore(int i)
    {
        Debug.Log("Picked up object");
        Debug.Log(i);
        lootObjectsCollected += i;
        scoreText.text = lootObjectsCollected.ToString() + " / " + numberOfObjects.ToString();
    }
}