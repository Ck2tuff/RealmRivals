using UnityEngine;
using UnityEngine.AI; 

public class UnitController : MonoBehaviour
{
    [Header("Stats")]
    public float health = 100f;
    public float attackRange = 2f;
    public float attackRate = 1f; 
    public float damage = 10f;
    public string enemyTag = "Enemy"; 

    [Header("References")]
    public Transform currentTarget;
    private NavMeshAgent navAgent;
    private float nextAttackTime = 0f;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        FindNearestTarget();
    }

    void Update()
    {
        if (currentTarget == null)
        {
            FindNearestTarget();
            return; 
        }

        float distance = Vector3.Distance(transform.position, currentTarget.position);

        // MOVEMENT & ATTACK LOGIC
        if (distance <= attackRange)
        {
            navAgent.isStopped = true;
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + (1f / attackRate);
            }
        }
        else
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(currentTarget.position);
        }
    }

    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < shortestDistance)
            {
                shortestDistance = dist;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            currentTarget = nearestEnemy.transform;
        }
    }

    void Attack()
    {
        // Placeholder for dealing damage
        Debug.Log(transform.name + " attacks " + currentTarget.name + " for " + damage + " damage!");
    }
}
