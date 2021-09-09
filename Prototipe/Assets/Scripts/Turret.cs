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
    private bool preventShootOnSpawn;

    [Header("SetUps")]
    public Transform pivot;
    public Transform target;
    public GameObject cannonBallPrefab;
    public Transform cannonBallSpawn;
    public float turnSpeed = 10.0f;

    public int price;
    public enum Type
    {
        One,
        Two,
        Three,
        Four
    }
    public Type type;
    public bool unlocked;

    void Start()
    {
        preventShootOnSpawn = false;
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
        //UILibrary.UnlockTurretOneEvent += UnlockTurret;
        unlocked = false;
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
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Enemy actualEnemyFocus = null;
        foreach (Enemy enemy in enemies)
        {

            /// apunta al más cercano
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance && enemy.enlightened)
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
        if(preventShootOnSpawn)
        { 
        Debug.Log("Shoot");
        GameObject bulletGO = (GameObject)Instantiate(cannonBallPrefab, cannonBallSpawn.position, cannonBallSpawn.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
        }
        preventShootOnSpawn = true;
    }

    private void Save()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void UnlockTurret()
    {
        unlocked = true;
    }

    private void OnDisable()
    {
       // UILibrary.UnlockTurretOneEvent -= UnlockTurret;
    }
}
