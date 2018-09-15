using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

    public GameObject target;
    private Transform lastPosition;
    private UnitMovement unitMovement;

    private void Awake()
    {
        unitMovement = GetComponent<UnitMovement>();
    }


    //TODO

    /*

    Restrict pathrequests made
    Dont send pathrequest when in range


    */

    void Start () {

        CheckforPlayer();
	}

    private void Update()
    {
        if (target != null) {


            
            unitMovement.RequestMovement(target.transform);


        }
    }

    private void CheckforPlayer(){
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void FindNearest() {

    }
}
