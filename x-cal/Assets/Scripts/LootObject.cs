using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour {

    private PlayerScore playerScore;
    public int objectValue = 1;

    private void Start()
    {
        playerScore = GetComponent<PlayerScore>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Ran over object");
            Debug.Log(playerScore);
            playerScore.AddScore(objectValue);
        }
    }

    
}
