using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour {

    private PlayerStats playerStats;
    public int objectValue = 1;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Ran over object");
            Debug.Log(playerStats);
            playerStats.AddScore(objectValue);
        }
    }

    
}
