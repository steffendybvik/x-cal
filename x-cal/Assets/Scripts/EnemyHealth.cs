using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public float currentHealth;
    public Slider healthbar;


    bool isDead;


    void Awake()
    {

        currentHealth = startingHealth;
        healthbar.value = currentHealth / startingHealth;
    }

    void Update()
    {

    }


    public void TakeDamage(float amount)
    {
        if (isDead)
            return;
            
        currentHealth -= amount;
        healthbar.value = currentHealth / startingHealth;

        if (currentHealth <= 0)
        {
            Die();
        }

    }


    void Die()
    {
        isDead = true;

        Destroy(this.gameObject);
    }
}