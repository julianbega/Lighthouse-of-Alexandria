using UnityEngine;
using System;
using System.IO;

public class Enemy : MonoBehaviour
{
    public float speed;
    //public Transform target;
    public Waypoint target;
    public int wayPointIndex;
    public bool enlightened;
    public int life;
    public int myPath;

    public Bullet bullet;
    public static Action SubtractLives;
    public static Action GainMoney;
    static public event Action EnemyDie;
    static public event Action DestroyCannonBall;
    public Levels lvl;
    private Cheats cheat;
    private void Start()
    {
        cheat = FindObjectOfType<Cheats>();
        lvl = FindObjectOfType<Levels>();
        Cheats.increaseEnemySpeed += IncreaseSpeed;
        Cheats.killEnemy += Kill;
        enlightened = lvl.askIfDay();
        wayPointIndex = 0;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime * cheat.speed, Space.World);

            if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f)
            {
                SetNextTarget();
            }
        }
    }

    void SetNextTarget()
    {
        if (target.targets.Count != target.openTargets.Count)
        {
            for (int i = 0; i < target.targets.Count; i++)
            {
                Debug.Log("Llega0");
                Ray ray = new Ray(transform.position, -(transform.position - target.targets[i].transform.position).normalized);
                Debug.DrawLine(transform.position, target.targets[i].transform.position, Color.red);
                Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
                Debug.DrawRay(ray.origin, ray.direction, Color.green, 3f);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Vector3.Distance(transform.position, target.targets[i].transform.position)))
                {
                //if (Physics.Raycast(transform.position, (transform.position - target.targets[i].transform.position).normalized, Vector3.Distance(transform.position, target.targets[i].transform.position), 9))
                //if (Physics.Raycast(transform.position, (transform.position - target.targets[i].transform.position).normalized, Vector3.Distance(transform.position, target.targets[i].transform.position)))
                    Debug.Log("Llega1");
                }
                else
                {
                    Debug.Log("Llega2");
                    if (!target.openTargets.Contains(target.targets[i]))
                    {
                        target.openTargets.Add(target.targets[i]);
                    }
                }
            }
        }
        target = target.openTargets[UnityEngine.Random.Range(0, target.openTargets.Count)];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            target = other.gameObject.GetComponent<Waypoint>().targets[UnityEngine.Random.Range(0, other.gameObject.GetComponent<Waypoint>().targets.Count)];

        }
        if (other.gameObject.CompareTag("Light"))
        {
            enlightened = true;
            return;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            DestroyCannonBall?.Invoke();
            life -= bullet.damage;


            if (life <= 0)
            {
                Destroy(this.gameObject);
                GainMoney?.Invoke();
                EnemyDie?.Invoke();
            }
            return;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            enlightened = false;
            return;
        }
    }

    private void IncreaseSpeed()
    {
        speed += 10;
    }

    private void Kill()
    {
        if (life > 0)
        {
            life = 0;
            Destroy(gameObject);
            EnemyDie?.Invoke();
        }
    }

    private void OnDisable()
    {
        Cheats.increaseEnemySpeed -= IncreaseSpeed;
        Cheats.killEnemy -= Kill;
    }
}
