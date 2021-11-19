using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage;
    public bool fireProyectiles;
    public bool penetrationProyectiles;
    public bool slowProyectiles;
    private void Start()
    {
        Enemy.DestroyCannonBall += HitTarget;
    }
    private void OnDisable()
    {
        Enemy.DestroyCannonBall -= HitTarget;
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

    void HitTarget()
    {
        Destroy(this.gameObject);
    }
}
