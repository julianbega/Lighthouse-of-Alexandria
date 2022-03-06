using UnityEngine;
using System;
using System.Collections;
public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage;
    public bool fireProyectiles;
    public bool penetrationProyectiles;
    public bool slowProyectiles;
    public Turret.type towerType;
    public string soundEvent;
    private void Start()
    {
        Enemy.DestroyCannonBall += HitTarget;
        StartCoroutine(DestroyOnTime());
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
        AkSoundEngine.PostEvent("impact_" + soundEvent, this.gameObject);
    }

    public IEnumerator DestroyOnTime()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
}
