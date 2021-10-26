﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage;
    private Cheats cheat;
    private void Start()
    {
        cheat = FindObjectOfType<Cheats>();
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
        float distanceThisFrame = speed * Time.deltaTime * cheat.speed;   
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(this.gameObject);
    }
}