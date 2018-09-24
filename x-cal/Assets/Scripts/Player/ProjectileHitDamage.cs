using UnityEngine;

public class ProjectileHitDamage : MonoBehaviour
{

    public float projectileDamage = 50f;
    public ParticleSystem splashParticles;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            Destroy(GetComponent<Rigidbody>());
            var temp = collision.gameObject.GetComponent<EnemyHealth>();
            temp.TakeDamage(projectileDamage);

        }

        if (collision.gameObject.tag == "Obstacle") {
            Destroy(GetComponent<Rigidbody>());
        }

        if (collision.gameObject.tag == "Ground") {
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
