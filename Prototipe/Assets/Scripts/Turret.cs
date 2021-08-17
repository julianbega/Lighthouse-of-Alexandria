using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("TowerStats")]
    public float range;
    public float power;
    public float attacksPerSecond;
    private float fireCountdown = 0f;

    [Header("SetUps")]
    public string enemyTag = "Enemy";
    public Transform pivot;
    public Transform target;
    public GameObject cannonBallPrefab;
    public Transform cannonBallSpawn;
    public float turnSpeed = 10.0f;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
    }
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(pivot.rotation, lookrotation, Time.deltaTime * turnSpeed).eulerAngles;
        pivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / attacksPerSecond;
        }
        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject actualEnemyFocus = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                actualEnemyFocus = enemy;
            }
        }

        if (actualEnemyFocus != null && shortestDistance <= range)
        {
            target = actualEnemyFocus.transform;
        }
        else 
        {
            target = null;
        }
    }

    void Shoot()
    {
        Instantiate(cannonBallPrefab, cannonBallSpawn.position, cannonBallSpawn.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
