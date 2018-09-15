using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSplash : MonoBehaviour
{

    public float projectileMaxDamage = 50f;
    public float projectileExplosionForce = 100f;
    public float projectileMaxLifeTime = 2f;
    public float projectileExplotionRadius = 1f;

    private void Start() {
        Destroy(this.gameObject, projectileMaxLifeTime);
    }

    private void OnCollisionEnter(Collision col)
    {

    }
}
