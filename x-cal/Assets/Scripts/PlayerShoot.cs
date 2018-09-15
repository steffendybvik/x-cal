using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject projectile;
    public GameObject fireTransform;
    public float minForce = 10f;
    public float maxForce = 20f;
    public float maxChargeTime = 0.75f;

    [SerializeField]
    public static int throwDamagePerShot = 50;

    public float timeBetweenBullets = 1.0f;

    public float timer;

    private int shootableMask;

    void Start () {
        timer = timeBetweenBullets;
	}
	

	void Update () {
        timer += Time.deltaTime;


        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Throw();
        }
    }

    private void Throw(){
        timer = 0f;
        var temp = Instantiate(projectile, fireTransform.transform.position, transform.rotation);
        temp.GetComponent<Rigidbody>().AddRelativeForce(0, 0, minForce);
    }
}