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
    [Header("LivesColor")]
    private MeshRenderer renderer;
    public Material hp1;
    public Material hp2;
    public Material hp3;
    public Material hp4;
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
        renderer = this.gameObject.GetComponent<MeshRenderer>();
        switch (life)
        {
            case 4:
                renderer.material = hp4;
                break;
            case 3:
                renderer.material = hp3;
                break;
            case 2:
                renderer.material = hp2;
                break;
            case 1:
                renderer.material = hp1;
                break;
            default:
                break;
        }
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
                if (wayPointIndex < wp.Path1.Length)
                {
                    wayPointIndex++;
                    target = wp.Path1[wayPointIndex];
                }
                else 
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 2:
                if (wayPointIndex < wp.Path2.Length)
                {
                    wayPointIndex++;
                    target = wp.Path2[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 3:
                if (wayPointIndex < wp.Path3.Length)
                {
                    wayPointIndex++;
                    target = wp.Path3[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 4:
                if (wayPointIndex < wp.Path4.Length)
                {
                    wayPointIndex++;
                    target = wp.Path4[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 5:
                if (wayPointIndex < wp.Path5.Length)
                {
                    wayPointIndex++;
                    target = wp.Path5[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 6:
                if (wayPointIndex < wp.Path6.Length)
                {
                    wayPointIndex++;
                    target = wp.Path6[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 7:
                if (wayPointIndex < wp.Path7.Length)
                {
                    wayPointIndex++;
                    target = wp.Path7[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 8:
                if (wayPointIndex < wp.Path8.Length)
                {
                    wayPointIndex++;
                    target = wp.Path8[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 9:
                if (wayPointIndex < wp.Path9.Length)
                {
                    wayPointIndex++;
                    target = wp.Path9[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 10:
                if (wayPointIndex < wp.Path10.Length)
                {
                    wayPointIndex++;
                    target = wp.Path10[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 11:
                if (wayPointIndex < wp.Path11.Length)
                {
                    wayPointIndex++;
                    target = wp.Path11[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 12:
                if (wayPointIndex < wp.Path12.Length)
                {
                    wayPointIndex++;
                    target = wp.Path12[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 13:
                if (wayPointIndex < wp.Path13.Length)
                {
                    wayPointIndex++;
                    target = wp.Path13[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 14:
                if (wayPointIndex < wp.Path14.Length)
                {
                    wayPointIndex++;
                    target = wp.Path14[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 15:
                if (wayPointIndex < wp.Path15.Length)
                {
                    wayPointIndex++;
                    target = wp.Path15[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 16:
                if (wayPointIndex < wp.Path16.Length)
                {
                    wayPointIndex++;
                    target = wp.Path16[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 17:
                if (wayPointIndex < wp.Path17.Length)
                {
                    wayPointIndex++;
                    target = wp.Path17[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 18:
                if (wayPointIndex < wp.Path18.Length)
                {
                    wayPointIndex++;
                    target = wp.Path18[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 19:
                if (wayPointIndex < wp.Path19.Length)
                {
                    wayPointIndex++;
                    target = wp.Path19[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 20:
                if (wayPointIndex < wp.Path20.Length)
                {
                    wayPointIndex++;
                    target = wp.Path20[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 21:
                if (wayPointIndex < wp.Path21.Length)
                {
                    wayPointIndex++;
                    target = wp.Path21[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 22:
                if (wayPointIndex < wp.Path22.Length)
                {
                    wayPointIndex++;
                    target = wp.Path22[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 23:
                if (wayPointIndex < wp.Path23.Length)
                {
                    wayPointIndex++;
                    target = wp.Path23[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 24:
                if (wayPointIndex < wp.Path24.Length)
                {
                    wayPointIndex++;
                    target = wp.Path24[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 25:
                if (wayPointIndex < wp.Path25.Length)
                {
                    wayPointIndex++;
                    target = wp.Path25[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 26:
                if (wayPointIndex < wp.Path26.Length)
                {
                    wayPointIndex++;
                    target = wp.Path26[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 27:
                if (wayPointIndex < wp.Path27.Length)
                {
                    wayPointIndex++;
                    target = wp.Path27[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 28:
                if (wayPointIndex < wp.Path28.Length)
                {
                    wayPointIndex++;
                    target = wp.Path28[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 29:
                if (wayPointIndex < wp.Path29.Length)
                {
                    wayPointIndex++;
                    target = wp.Path29[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 30:
                if (wayPointIndex < wp.Path30.Length)
                {
                    wayPointIndex++;
                    target = wp.Path30[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 31:
                if (wayPointIndex < wp.Path31.Length)
                {
                    wayPointIndex++;
                    target = wp.Path31[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 32:
                if (wayPointIndex < wp.Path32.Length)
                {
                    wayPointIndex++;
                    target = wp.Path32[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 33:
                if (wayPointIndex < wp.Path33.Length)
                {
                    wayPointIndex++;
                    target = wp.Path33[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 34:
                if (wayPointIndex < wp.Path34.Length)
                {
                    wayPointIndex++;
                    target = wp.Path34[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 35:
                if (wayPointIndex < wp.Path35.Length)
                {
                    wayPointIndex++;
                    target = wp.Path35[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 36:
                if (wayPointIndex < wp.Path36.Length)
                {
                    wayPointIndex++;
                    target = wp.Path36[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 37:
                if (wayPointIndex < wp.Path37.Length)
                {
                    wayPointIndex++;
                    target = wp.Path37[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 38:
                if (wayPointIndex < wp.Path38.Length)
                {
                    wayPointIndex++;
                    target = wp.Path38[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 39:
                if (wayPointIndex < wp.Path39.Length)
                {
                    wayPointIndex++;
                    target = wp.Path39[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
                break;
            case 40:
                if (wayPointIndex < wp.Path40.Length)
                {
                    wayPointIndex++;
                    target = wp.Path40[wayPointIndex];
                }
                else
                {
                    Destroy(this.gameObject);
                    SubtractLives?.Invoke();
                    EnemyDie?.Invoke();
                    return;
                }
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
            
            switch (life)
            {
                case 3:
                    renderer.material = hp3;
                    speed += 3;
                    break;
                case 2:
                    renderer.material = hp2;
                    speed += 3;
                    break;
                case 1:
                    renderer.material = hp1;
                    speed += 3;
                    break;
                default:
                    break;
            }
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

    private void OnDisable()
    {
        Cheats.increaseEnemySpeed -= IncreaseSpeed;
        Cheats.killEnemy -= Kill;
    }
}
