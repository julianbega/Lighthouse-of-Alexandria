using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage;
    public bool fireProyectiles;
    public bool penetrationProyectiles;
    public bool slowProyectiles;
    public Turret.type towerType;
    private Turret turret;
    private void Start()
    {
        Enemy.DestroyCannonBall += HitTargett;
        turret = FindObjectOfType<Turret>();
    }
    private void OnDisable()
    {
        Enemy.DestroyCannonBall -= HitTargett;
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    { 
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;   
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        if (target == null)
        {
            Destroy(this.gameObject);
        }
    }

    void HitTargett()
    {
        AkSoundEngine.PostEvent("impact_" + turret.soundEvent, this.gameObject);
        Destroy(gameObject);
    }

    void HitTarget()
    {
        switch (towerType)
        {
            case Turret.type.Catapult:
                AkSoundEngine.PostEvent("impact_cannontower", this.gameObject);
                break;
            case Turret.type.Archer:
                AkSoundEngine.PostEvent("impact_archertower", this.gameObject);
                break;
            case Turret.type.Scorpion:
                AkSoundEngine.PostEvent("impact_crossbowtower", this.gameObject);
                break;
            case Turret.type.Canon:
                AkSoundEngine.PostEvent("impact_cannontower", this.gameObject);
                break;
            default:
                break;
        }
        Destroy(this.gameObject);
    }
}
