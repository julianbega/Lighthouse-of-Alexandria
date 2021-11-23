using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;
    //public Transform target;
    public Waypoint target;
    public int wayPointIndex;
    public bool enlightened;
    public int life;
    public int moneyAtDeath;
    public int myPath;
    private float inicialSpeed;
    private float halfSpeed;

    private Bullet bullet;
    public static Action SubtractLives;
    public static Action <int>GainMoney;
    static public event Action EnemyDie;
    static public event Action DestroyCannonBall;
    public LevelManager lvl;
    private bool firstRotation;

    public UIHealthBar healthBar;
    public GameObject healthBarGO;
    private bool alreadyDie;
    public bool onFire;
    public GameObject fire;
    public bool armored;

    [SerializeField] private float speedRotation;
    private float maxTimeAnim = 1.0f;
    private float timerAnim;

    private void Start()
    {
        lvl = FindObjectOfType<LevelManager>();
        Cheats.killEnemy += Kill;
        enlightened = lvl.AskIfDay();
        wayPointIndex = 0;
        firstRotation = true;
        healthBar.SetMaxHealth(life);
        alreadyDie = false;
        halfSpeed = speed / 2;
        inicialSpeed = speed;
    }

    private void Update()
    {
        healthBarGO.SetActive(enlightened);  // activa o desactiva la barra de vida si está o no iluminada
        if (firstRotation)
        {
            if (target != null)
            {
                Quaternion targetRotation = Quaternion.identity;
                Vector3 targetDirection = (target.transform.position - transform.position).normalized; //cambiar
                targetRotation = (Quaternion.LookRotation(targetDirection));
                transform.rotation = targetRotation;
                firstRotation = !firstRotation;
            }
        }
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;           
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f)
            {
                SetNextTarget();
                StartCoroutine(RotationInterpolate());
            }
        }
        while (onFire)
        {
            enlightened = true;
        }
        if (life <= 0)
        {
            Kill();
        }
    }

    void SetNextTarget()
    {
        if (target.targets.Count != target.openTargets.Count)
        {
            for (int i = 0; i < target.targets.Count; i++)
            {
                //timerRotation = 0.0f;
                Ray ray = new Ray(transform.position, -(transform.position - target.targets[i].transform.position).normalized);
                Debug.DrawLine(transform.position, target.targets[i].transform.position, Color.red);
                Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
                Debug.DrawRay(ray.origin, ray.direction, Color.green, 3f);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Vector3.Distance(transform.position, target.targets[i].transform.position))){}
                else
                {
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
            target = other.gameObject.GetComponent<Waypoint>().targets[0];

        }
        if (other.gameObject.CompareTag("Light"))
        {
            enlightened = true;
            return;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            life = 0;
            SubtractLives?.Invoke();
            EnemyDie?.Invoke();
            Destroy(this.gameObject);
            return;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            bullet = other.gameObject.GetComponent<Bullet>();
            DestroyCannonBall?.Invoke();

            if(armored)
            { 
                if(bullet.penetrationProyectiles)
                {
                    life -= bullet.damage;
                }
            }
            else
            {
                life -= bullet.damage;
            }

            healthBar.SetHealth(life);
            if (life <= 0 && alreadyDie == false)
            {
                life = 0;
                alreadyDie = true;
                GainMoney?.Invoke(moneyAtDeath);
                EnemyDie?.Invoke();
                Destroy(this.gameObject);
                return;
            }
            if (bullet.fireProyectiles && !onFire)
            {
                StartCoroutine(OnFire());
            }
            if (bullet.slowProyectiles)
            {
                StartCoroutine(Slowed());
            }
            return;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            if (!lvl.AskIfDay())
            {
                if(onFire == false)
                enlightened = false;
            }
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            enlightened = true;
            return;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            life = 0;
            SubtractLives?.Invoke();
            EnemyDie?.Invoke();
            Destroy(this.gameObject);
            return;
        }
    }
    private void IncreaseSpeed()
    {
        speed += 10;
    }

    private void Kill()
    {
        life = 0;
        alreadyDie = true;
        GainMoney?.Invoke(moneyAtDeath);
        EnemyDie?.Invoke();
        Destroy(this.gameObject);
        return;
    }

    private void OnDisable()
    {
        Cheats.killEnemy -= Kill;
    }

    IEnumerator RotationInterpolate()
    {
        while (timerAnim < maxTimeAnim)
        {
            timerAnim += Time.deltaTime;
            Quaternion targetRotation = Quaternion.identity;
            Vector3 targetDirection = (target.transform.position - transform.position).normalized; //cambiar
            targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, targetRotation, speedRotation);
            yield return null;
        }
        timerAnim = 0.0f;
    }

    IEnumerator OnFire()
    {
        onFire = true;
        fire.SetActive(true);        
        yield return new WaitForSeconds(2.0f);

        onFire = false;
        fire.SetActive(false);
    }
    IEnumerator Slowed()
    {
        speed = halfSpeed;
        yield return new WaitForSeconds(2.0f);
        speed = inicialSpeed;
    }
}
