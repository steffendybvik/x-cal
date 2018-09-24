using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour {


    public int objectValue = 1;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            GameManager.instance.AddScore(objectValue);
            Destroy(this.gameObject);
        }
    }

    
}
