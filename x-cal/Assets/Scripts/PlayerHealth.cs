using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    public float health;
    public float maxHealth = 100f;
    public Slider healthbar;

    void Awake () {

        health = maxHealth;
        healthbar.value = health / maxHealth;
    }
	
    public void TakeDamage(float amount){

        health -= amount;
        healthbar.value = health / maxHealth;

        if (health <= 0) {
            Die();
        }
    }

    private void Die(){
        Destroy(this.gameObject);
    }
}
