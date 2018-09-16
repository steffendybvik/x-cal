using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public Rigidbody projectile;
    public Transform fireTransform;
    public Slider aimSlider;

    public float minForce = 10f;
    public float maxForce = 25f;
    public float maxChargeTime = 2f;
    public float timeBetweenBullets = 2.0f;

    [SerializeField]
    public static int damagePrShot = 50;

    private float timer;
    private float currentForce;
    private float chargeSpeed;
    private bool fired;

    private void OnEnable() {
        currentForce = minForce;
        aimSlider.value = minForce;
    }

    void Start () {
        timer = timeBetweenBullets;
        chargeSpeed = (maxForce - minForce) / maxChargeTime;
	}
	

	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeBetweenBullets) {
            aimSlider.value = minForce;
            if (currentForce >= maxForce && !fired) {
                currentForce = maxForce;
                Fire();

            } else if (Input.GetButtonDown("Fire1")) {
                fired = false;
                currentForce = minForce;

            } else if (Input.GetButton("Fire1") && !fired) {
                currentForce += chargeSpeed * Time.deltaTime;

                aimSlider.value = currentForce;


            } else if (Input.GetButtonUp("Fire1") && !fired) {
                Fire();
            }
            
        }
    }

    private void Fire(){
        timer = 0f;
        Rigidbody projectileInstance = Instantiate(projectile, fireTransform.position, fireTransform.rotation) as Rigidbody;
        projectileInstance.velocity = currentForce * fireTransform.forward;

        currentForce = minForce;
    }
}