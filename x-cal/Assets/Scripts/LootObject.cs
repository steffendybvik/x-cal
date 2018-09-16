using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour {

    public GameManager gameManager;

    public int objectValue = 1;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Ran over object");
            Debug.Log(gameManager.score);
            //playerScore.AddScore(objectValue);
        }
    }

    
}
