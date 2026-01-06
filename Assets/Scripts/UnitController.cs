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
        // Check if the target still exists and has the TowerHealth component
        TowerHealth tower = currentTarget.GetComponent<TowerHealth>();

        if (tower != null)
        {
            // DEAL DAMAGE to the Tower
            tower.TakeDamage(damage);
        }
        // Future logic: else if (currentTarget has a UnitController script) -> Unit-to-Unit combat
    }
