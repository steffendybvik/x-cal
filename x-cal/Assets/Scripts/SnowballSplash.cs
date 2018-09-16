using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSplash : MonoBehaviour
{
    public ParticleSystem splashParticles;
    public LayerMask damageable;

    public float projectileMaxDamage = 100f;
    public float projectileExplosionForce = 1000f;
    public float projectileMaxLifeTime = 2f;
    public float projectileExplotionRadius = 5f;

    private void Start() {
    }

    private void OnCollisionEnter(Collision collision) {
        Collider[] colliders = Physics.OverlapSphere(transform.position, projectileExplotionRadius, damageable);

        for (int i = 0; i < colliders.Length; i++) {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody) {
                continue;
            }
            targetRigidbody.AddExplosionForce(projectileExplosionForce, transform.position, projectileExplotionRadius);

            EnemyHealth targetHealth = targetRigidbody.GetComponent<EnemyHealth>();
            if (!targetHealth) {
                continue;
            }
            float damage = CalculateDamage(targetRigidbody.position);
            targetHealth.TakeDamage(damage);

        }
        splashParticles.Play();
        Destroy(this.gameObject, splashParticles.duration);
    }

    private float CalculateDamage(Vector3 targetPosition) {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (projectileExplotionRadius - explosionDistance) / projectileExplotionRadius;
        Debug.Log(relativeDistance);
        float damage = relativeDistance * projectileMaxDamage;

        damage = Mathf.Max(0f, damage);
        Debug.Log("calculated damage to be " + damage);
        return damage;
    }
}
