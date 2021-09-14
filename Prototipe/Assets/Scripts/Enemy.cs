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

    private void Awake()
    {
        SaveObject saveObject = new SaveObject
        {
            pos = transform.position,
        };
        string json = JsonUtility.ToJson(saveObject);
       // Debug.Log(json);

        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
      //  Debug.Log(loadedSaveObject.pos);

    }

    private void Start()
    {
        lvl = FindObjectOfType<Levels>();
        Cheats.increaseEnemySpeed += IncreaseSpeed;
        Cheats.killEnemy += Kill;
        enlightened = lvl.itIsDay;
        wayPointIndex = 0;
    }

    private void Update()
    {
        if (target != null)
        { 
            Vector3 direction = target.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f)
        {
            SetNextTarget();
        }

        if (Input.GetKeyDown(KeyCode.S))
            Save();
        }
    }

    void SetNextTarget()
    {
        for (int i = 0; i < target.Targets.Count; i++)
        {
            
        }
        target = target.Targets[UnityEngine.Random.Range(0, target.Targets.Count)];        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            target = other.gameObject.GetComponent<Waypoint>().Targets[UnityEngine.Random.Range(0, other.gameObject.GetComponent<Waypoint>().Targets.Count)];

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
            
           
            if(life <= 0)
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

    private void Save()
    {
        Vector3 enemyPos = transform.position;

        SaveObject saveObject = new SaveObject {
            pos = enemyPos,
        };

        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }

    private void IncreaseSpeed()
    {
        speed += 10;
    }

    private void Kill()
    {
        if(life > 0)
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
