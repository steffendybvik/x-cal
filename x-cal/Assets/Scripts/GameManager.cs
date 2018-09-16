using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score;
    public Text scoreText;

    private int numberOfObjects;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        score = 0;
        FindNumberOfLootObjects();
        scoreText.text = score.ToString() + " / " + numberOfObjects.ToString();
    }

    
    private void FindNumberOfLootObjects() {
        numberOfObjects = GameObject.FindGameObjectsWithTag("LootObject").Length;
    }

    public void AddScore(int i)
    {
        Debug.Log("Picked up object");
        Debug.Log(i);
        score += i;
        scoreText.text = score.ToString() + " / " + numberOfObjects.ToString();
    }
}