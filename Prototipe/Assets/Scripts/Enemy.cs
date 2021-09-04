using UnityEngine;
using System;
using System.IO;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public int wayPointIndex;
    public bool enlightened;
    public int life;
    public int myPath;

    public Bullet bullet;
    public static Action SubtractLives;
    public static Action GainMoney;
    static public event Action EnemyDie;
    static public event Action DestroyCannonBall;
    public Waypoints wp;

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
        wp = FindObjectOfType<Waypoints>(); 
        Cheats.increaseEnemySpeed += IncreaseSpeed;
        Cheats.killEnemy += Kill;
        //Debug.Log(transform.position);

        wayPointIndex = 0;
       

    }

    private void Update()
    {
        if (target != null)
        { 
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            SetNextTarget();
        }

        if (Input.GetKeyDown(KeyCode.S))
            Save();
        }
    }

    void SetNextTarget()
    {

        switch (myPath)
        {
            case 1:
                NextTargetInPath(wp.Path1);
                break;
            case 2:
                NextTargetInPath(wp.Path2);
                break;
            case 3:
                NextTargetInPath(wp.Path3);
                break;
            case 4:
                NextTargetInPath(wp.Path4);
                break;
            case 5:
                NextTargetInPath(wp.Path5);
                break;
            case 6:
                NextTargetInPath(wp.Path6);
                break;
            case 7:
                NextTargetInPath(wp.Path7);                
                break;
            case 8:
                NextTargetInPath(wp.Path8);                
                break;
            case 9:
                NextTargetInPath(wp.Path9);
                break;
            case 10:
                NextTargetInPath(wp.Path10);
                break;
            case 11:
                NextTargetInPath(wp.Path11);
                break;
            case 12:
                NextTargetInPath(wp.Path12);
                break;
            case 13:
                NextTargetInPath(wp.Path13);
                break;
            case 14:
                NextTargetInPath(wp.Path14);
                break;
            case 15:
                NextTargetInPath(wp.Path15);
                break;
            case 16:
                NextTargetInPath(wp.Path16);
                break;
            case 17:
                NextTargetInPath(wp.Path17);
                break;
            case 18:
                NextTargetInPath(wp.Path18);
                break;
            case 19:
                NextTargetInPath(wp.Path19);
                break;
            case 20:
                NextTargetInPath(wp.Path20); 
                break;
            case 21:
                NextTargetInPath(wp.Path21);
                break;
            case 22:
                NextTargetInPath(wp.Path22);
                break;
            case 23:
                NextTargetInPath(wp.Path23);
                break;
            case 24:
                NextTargetInPath(wp.Path24);
                break;
            case 25:
                NextTargetInPath(wp.Path25);
                break;
            case 26:
                NextTargetInPath(wp.Path26);
                break;
            case 27:
                NextTargetInPath(wp.Path27);
                break;
            case 28:
                NextTargetInPath(wp.Path28);
                break;
            case 29:
                NextTargetInPath(wp.Path29);
                break;
            case 30:
                NextTargetInPath(wp.Path30);
                break;
            case 31:
                NextTargetInPath(wp.Path31);
                break;
            case 32:
                NextTargetInPath(wp.Path32);
                break;
            case 33:
                NextTargetInPath(wp.Path33);
                break;
            case 34:
                NextTargetInPath(wp.Path34);
                break;
            case 35:
                NextTargetInPath(wp.Path35);
                break;
            case 36:
                NextTargetInPath(wp.Path36);
                break;
            case 37:
                NextTargetInPath(wp.Path37);
                break;
            case 38:
                NextTargetInPath(wp.Path38);
                break;
            case 39:
                NextTargetInPath(wp.Path39);
                break;
            case 40:
                NextTargetInPath(wp.Path40);
                break;

        }
        /*if (wayPointIndex < wp.Length)
        {
            wayPointIndex++;
        }*/
        //target = Waypoints.enemyMovmentPoints[wavePointIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            Debug.Log("está en start " + other.gameObject.name);
            if (other.gameObject.name == "Start1")
            { 
                myPath = UnityEngine.Random.Range(1, 6);
                switch (myPath)
                {
                    case 1:
                        target = wp.Path1[0];
                        break;
                    case 2:
                        target = wp.Path2[0];
                        break;
                    case 3:
                        target = wp.Path3[0];
                        break;
                    case 4:
                        target = wp.Path4[0];
                        break;
                    case 5:
                        target = wp.Path5[0];
                        break;
                    default:
                        break;
                }
            }
            if (other.gameObject.name == "Start2")
            { 
                myPath = UnityEngine.Random.Range(6, 16);
                switch (myPath)
                {
                    case 6:
                        target = wp.Path6[0];
                        break;
                    case 7:
                        target = wp.Path7[0];
                        break;
                    case 8:
                        target = wp.Path8[0];
                        break;
                    case 9:
                        target = wp.Path9[0];
                        break;
                    case 10:
                        target = wp.Path10[0];
                        break;
                    case 11:
                        target = wp.Path11[0];
                        break;
                    case 12:
                        target = wp.Path12[0];
                        break;
                    case 13:
                        target = wp.Path13[0];
                        break;
                    case 14:
                        target = wp.Path14[0];
                        break;
                    case 15:
                        target = wp.Path15[0];
                        break;
                    default:
                        break;
                }
            }
            if (other.gameObject.name == "Start3")
            {
                myPath = UnityEngine.Random.Range(16, 23);
                switch (myPath)
                {
                    case 16:
                        target = wp.Path16[0];
                        break;
                    case 17:
                        target = wp.Path17[0];
                        break;
                    case 18:
                        target = wp.Path18[0];
                        break;
                    case 19:
                        target = wp.Path19[0];
                        break;
                    case 20:
                        target = wp.Path20[0];
                        break;
                    case 21:
                        target = wp.Path21[0];
                        break;
                    case 22:
                        target = wp.Path22[0];
                        break;
                    default:
                        break;
                }
            }
            if (other.gameObject.name == "Start4")
            {
                myPath = UnityEngine.Random.Range(23, 38);
                switch (myPath)
                {                    
                    case 23:
                        target = wp.Path23[0];
                        break;
                    case 24:
                        target = wp.Path24[0];
                        break;
                    case 25:
                        target = wp.Path25[0];
                        break;
                    case 26:
                        target = wp.Path26[0];
                        break;
                    case 27:
                        target = wp.Path27[0];
                        break;
                    case 28:
                        target = wp.Path28[0];
                        break;
                    case 29:
                        target = wp.Path29[0];
                        break;
                    case 30:
                        target = wp.Path30[0];
                        break;
                    case 31:
                        target = wp.Path31[0];
                        break;
                    case 32:
                        target = wp.Path32[0];
                        break;
                    case 33:
                        target = wp.Path33[0];
                        break;
                    case 34:
                        target = wp.Path34[0];
                        break;
                    case 35:
                        target = wp.Path35[0];
                        break;
                    case 36:
                        target = wp.Path36[0];
                        break;
                    case 37:
                        target = wp.Path37[0];
                        break;
                    default:
                        break;
                }
                    
            }
            if (other.gameObject.name == "Start5")
            {
               
                myPath = UnityEngine.Random.Range(38, 41);
                switch (myPath)
                {
                    
                    case 38:
                        target = wp.Path38[0];
                        break;
                    case 39:
                        target = wp.Path39[0];
                        break;
                    case 40:
                        target = wp.Path40[0];
                        break;
                    default:
                        break;
                }
            }
            return;
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
        speed += 1;
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
    private void NoMorePath()
    {
        Destroy(this.gameObject);
        SubtractLives?.Invoke();
        EnemyDie?.Invoke();
        return;
    }
    private void NextTargetInPath(Transform[] path)
    {
        if (wayPointIndex < path.Length)
        {
            wayPointIndex++;
            target = path[wayPointIndex];
        }
        else
        {
            NoMorePath();
        }
    }

    private void OnDisable()
    {
        Cheats.increaseEnemySpeed -= IncreaseSpeed;
        Cheats.killEnemy -= Kill;
    }
}
