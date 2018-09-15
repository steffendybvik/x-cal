using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSplash : MonoBehaviour
{

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy") {
            Destroy(GetComponent<Rigidbody>());
            var temp = col.gameObject.GetComponent<EnemyHealth>();
            var damage = PlayerThrow.throwDamagePerShot;
            temp.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Obstacle") {
            Destroy(GetComponent<Rigidbody>());
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Ground") {
            Destroy(GetComponent<Rigidbody>());
            Destroy(this.gameObject, 0.3f);
        }
    }
}
