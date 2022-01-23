using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Turret : MonoBehaviour
{
    public enum type
    {
        Catapult, Archer, Scorpion, Canon
    }
    [Header("TowerStats")]
    public float range;
    public int power;
    public float attacksPerSecond;
    private float fireCountdown = 0f;
    private bool preventShootOnSpawn;
    public type towerType;
    [Header("SetUps")]
    public Transform pivot;
    public Transform target;
    public GameObject cannonBallPrefab;
    public Transform cannonBallSpawn;
    public float turnSpeed = 10.0f;

    public int price;
    public int turretLvl;
    public new Light light;

    public Color baseLightColor;
    public Color alarmColor;
    //private Turret actualTurret;

    [Header("PowerUps")]
    public bool fireProyectiles;
    public bool penetrationProyectiles;
    public bool slowProyectiles;
    public bool alarm;
    private bool alreadyAlarming;
    static public event Action<int> OpenUpgradeSystem;
    //static public event Action<Turret> SelectedTurret;

    public GameObject rangeSprite;

    public static event Action OpenUpgradeShop;
    private const int indexActivation = 2;

    void Start()
    {
        fireProyectiles = false;
        penetrationProyectiles = false;
        slowProyectiles = false;
        alarm = false;
        preventShootOnSpawn = false;
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
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Enemy actualEnemyFocus = null;
        foreach (Enemy enemy in enemies)
        {

            /// apunta al más cercano
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                if (enemy.enlightened)
                {
                    actualEnemyFocus = enemy;
                }
                else
                {
                    if (alarm && !alreadyAlarming && shortestDistance <= range)
                        StartCoroutine(Alarm());
                }

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
        if (preventShootOnSpawn)
        {
            Debug.Log("Shoot");
            GameObject bulletGO = (GameObject)Instantiate(cannonBallPrefab, cannonBallSpawn.position, cannonBallSpawn.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)
                bullet.Seek(target);
            bullet.damage = power;
            bullet.towerType = towerType;
            bullet.fireProyectiles = fireProyectiles;
            bullet.penetrationProyectiles = penetrationProyectiles;
            bullet.slowProyectiles = slowProyectiles;
        }

        switch (towerType)
        {
            case type.Catapult:
                AkSoundEngine.PostEvent("attack_cannontower", this.gameObject);
                break;
            case type.Archer:
                if (fireProyectiles)
                {
                    AkSoundEngine.PostEvent("attack_archertower_fire", this.gameObject);
                }
                else
                {
                    AkSoundEngine.PostEvent("attack_archertower", this.gameObject);
                }
                break;
            case type.Scorpion:
                if (fireProyectiles)
                {
                    AkSoundEngine.PostEvent("attack_crossbowtower_fire", this.gameObject);
                }
                else
                {
                    AkSoundEngine.PostEvent("attack_crossbowtower", this.gameObject);
                }
                break;
            case type.Canon:
                AkSoundEngine.PostEvent("attack_cannontower", this.gameObject);

                break;
            default:
                break;
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
        OpenUpgradeSystem?.Invoke(indexActivation);
        //actualTurret = this;
        //SelectedTurret?.Invoke(actualTurret);
        ConstructionManager.instance.selectedTurret = this;
    }
    private void OnMouseEnter()
    {
        rangeSprite.SetActive(true);
    }
    private void OnMouseExit()
    {
        rangeSprite.SetActive(false);
    }

    private void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            ConstructionManager.instance.selectedTurret = this;
            OpenUpgradeShop?.Invoke();

        }
    }

    IEnumerator Alarm()
    {
        alreadyAlarming = true;
        light.color = alarmColor;
        yield return new WaitForSeconds(0.25f);
        light.color = baseLightColor;
        yield return new WaitForSeconds(0.25f);
        light.color = alarmColor;
        yield return new WaitForSeconds(0.25f);
        light.color = baseLightColor;
        alreadyAlarming = false;

    }
}
