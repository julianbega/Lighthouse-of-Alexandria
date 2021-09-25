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
    private bool firstRotation;

    public HealthBar healthBar;
    public GameObject healthBarGO;
    private void Start()
    {
        cheat = FindObjectOfType<Cheats>();
        lvl = FindObjectOfType<Levels>();
        Cheats.killEnemy += Kill;
        enlightened = lvl.askIfDay();
        wayPointIndex = 0;
        firstRotation = true;
        healthBar.SetMaxHealth(life);
        
    }

    private void Update()
    {
        healthBarGO.SetActive(enlightened);  // activa o desactiva la barra de vida si está o no iluminada
        if (firstRotation)
        {
            Quaternion targetRotation = Quaternion.identity;
            Vector3 targetDirection = (target.transform.position - transform.position).normalized; //cambiar
            targetRotation = (Quaternion.LookRotation(targetDirection));
            transform.rotation = targetRotation;
            firstRotation = !firstRotation;

        }
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;           
            transform.Translate(direction.normalized * speed * Time.deltaTime * cheat.speed, Space.World);

            if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f)
            {
                SetNextTarget();
                Quaternion targetRotation = Quaternion.identity;
                Vector3 targetDirection = ( target.transform.position - transform.position).normalized; //cambiar
                targetRotation = (Quaternion.LookRotation(targetDirection));
                transform.rotation = targetRotation;
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
                if (Physics.Raycast(ray, out hit, Vector3.Distance(transform.position, target.targets[i].transform.position))){}
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
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
            EnemyDie?.Invoke();
            return;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            DestroyCannonBall?.Invoke();
            life -= bullet.damage;

            healthBar.SetHealth(life);
            if (life <= 0)
            {
                Destroy(this.gameObject);
                GainMoney?.Invoke();
                EnemyDie?.Invoke();
                SubtractLives?.Invoke();
                return;
            }
            return;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            if (!lvl.askIfDay())
            {
                enlightened = false;
            }
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
        Cheats.killEnemy -= Kill;
    }
}
