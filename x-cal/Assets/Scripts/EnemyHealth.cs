using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10;
    public float maxHealth = 100;
    public Slider healthbar;

    private float elapsedTime = 0;
    private float waitTime = 1.5f;

    void Awake() {

        healthbar.value = health / maxHealth;
    }


    public void TakeDamage(float amount)
    {
            
        health -= amount;
        healthbar.value = health / maxHealth;

        if (health <= 0) {
            Die();
        }

    }

    public void Heal(float amount) {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= waitTime) {

            health += amount;
            health = Mathf.Clamp(health, 0, 100);
            healthbar.value = health / maxHealth;
            elapsedTime = 0f;
        }
    }


    void Die() {
        Destroy(this.gameObject);
    }
}