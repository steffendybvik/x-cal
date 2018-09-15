using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Image healthbar;


    CapsuleCollider capsuleCollider;
    bool isDead;


    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }

    void Update()
    {

    }


    public void TakeDamage(int amount)
    {

        if (isDead)
            return;
            
        currentHealth -= amount;
        healthbar.fillAmount = currentHealth / startingHealth;

        if (currentHealth <= 0)
        {
            Die();
        }

    }


    void Die()
    {
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it
        capsuleCollider.isTrigger = true;

        Destroy(this.gameObject);
    }
}