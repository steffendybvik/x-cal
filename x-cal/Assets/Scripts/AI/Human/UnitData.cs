using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class UnitData : MonoBehaviour {

    public enum AISTATE { IDLE = 0, CHASE = 1, ATTACK = 2, RANGEDATTACK = 3, FLEE=4, HEAL=5}
    public AISTATE CurrentState = AISTATE.IDLE;

    public NavMeshAgent agent;
    public GameObject target;
    public Collider visionRange;


    public Text statusText;
    public bool isRangedUnit;
    public bool enemyInRange;

    public float AttackDamage = 40f;


    public float idleUtility = 0.2f;
    public float chaseUtility = 0.0f;
    public float attackUtility = 0.0f;
    public float rangedAttackUtility = 0.0f;
    public float fleeUtility = 0.0f;
    public float healUtility = 0.0f;

    public float time;
    public float consumptionInterval;

    private EnemyHealth enemyHealth;

    private void Awake() {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyInRange = false;

        ChangeState(CurrentState);
    }

    public void ChangeState(AISTATE NewState) {
        StopAllCoroutines();
        CurrentState = NewState;
        switch(NewState) {
            case AISTATE.IDLE:
                StartCoroutine(Idle());
                break;
            case AISTATE.CHASE:
                StartCoroutine(Chase());
                break;
            case AISTATE.ATTACK:
                StartCoroutine(Attack());
                break;
            case AISTATE.RANGEDATTACK:
                StartCoroutine(RangedAttack());
                break;
            case AISTATE.FLEE:
                StartCoroutine(Flee());
                break;
            case AISTATE.HEAL:
                StartCoroutine(Heal());
                break;

        }
        statusText.text = CurrentState.ToString();
    }

    public IEnumerator Idle() {
        Vector3 Point = RandomPointOnNavMesh();

        float WaitTimeIdle = 10f;
        float ElapsedTimeIdle = 0f;
        while (CurrentState == AISTATE.IDLE) {
            ElapsedTimeIdle += Time.deltaTime;

            this.agent.SetDestination(Point);
            if (ElapsedTimeIdle >= WaitTimeIdle) {


                ElapsedTimeIdle = 0f;
                Point = RandomPointOnNavMesh();
            }
        yield return null;
        }
    }

    public IEnumerator Chase() {
        while (CurrentState == AISTATE.CHASE) {
            agent.SetDestination(target.transform.position);
        yield return null;
        }
    }

    public IEnumerator Attack() {

        while (CurrentState == AISTATE.ATTACK) {
        

            if (target.GetComponent<PlayerHealth>() != null)
            {
                var tar = target.GetComponent<PlayerHealth>();
                if (tar != null)
                {
                    tar.TakeDamage(AttackDamage);
                }
            }
            yield return null;
        }
    }

    public IEnumerator RangedAttack()
    {
        while (CurrentState == AISTATE.RANGEDATTACK) {
            yield return null;
        }
    }

    public IEnumerator Flee() {
        while (CurrentState == AISTATE.FLEE) {
            if (enemyInRange) {
                RunAway();
            }

            yield return null;
        }
    }

    public IEnumerator Heal() {

        while (CurrentState == AISTATE.HEAL) {
        
            enemyHealth.Heal(2f);
            yield return null;
        }
    }

    public Vector3 RandomPointOnNavMesh() {
        float Radius = 20f;
        Vector3 Point = this.transform.position + Random.insideUnitSphere * Radius;
        NavMeshHit NH;
        NavMesh.SamplePosition(Point, out NH, Radius, NavMesh.AllAreas);
        return NH.position;
    }

    private void RunAway(){
        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 dirToTarget = transform.position - target.transform.position;

        Vector3 newPos = transform.position + dirToTarget;
        agent.SetDestination(newPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            enemyInRange = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            enemyInRange = false;
            target = null;
        }
    }
}
