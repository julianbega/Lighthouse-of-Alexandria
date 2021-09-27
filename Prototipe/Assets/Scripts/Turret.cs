using System;
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

    private Cheats cheat;
    public int price;
    private Turret actualTurret;

    static public event Action OpenUpgradeSystem;
    static public event Action<Turret> SelectedTurret;

    public GameObject rangeSprite;

    void Start()
    {
        cheat = FindObjectOfType<Cheats>();
        preventShootOnSpawn = false;
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(pivot.rotation, lookrotation, Time.deltaTime * turnSpeed * cheat.speed).eulerAngles;
        pivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / attacksPerSecond;
        }
        fireCountdown -= Time.deltaTime * cheat.speed;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnMouseDown()
    {
        OpenUpgradeSystem?.Invoke();
        actualTurret = this;
        SelectedTurret?.Invoke(actualTurret);
    }
    private void OnMouseEnter()
    {
        rangeSprite.SetActive(true);
    }
    private void OnMouseExit()
    {
        rangeSprite.SetActive(false);
    }

}
