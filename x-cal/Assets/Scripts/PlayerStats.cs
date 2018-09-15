using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerstats;

    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
        
        scoreText.text = score.ToString() + " / 1";
    }


    public void AddScore(int i)
    {
        Debug.Log("Picked up object");
        Debug.Log(i);
        score += i;
        scoreText.text = score.ToString() + " / 1";
    }
}