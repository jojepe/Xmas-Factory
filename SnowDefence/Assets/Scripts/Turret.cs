using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
public class Turret : MonoBehaviour
{
    private Transform target;
    
    [Header("Unity Setup")]
    public Transform partToRotate;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject smoke;

    [Header("Gun Specs")] 
    public string turretType;
    public int cost;
    public int costToRepair;
    public float turnSpeed = 10f;
    public float range = 15f;
    public float fireRate = 1f;

    [Header("Firethrower")]
    public bool isFirethrower = false;
    public GameObject fireparticle;
    

    //[HideInInspector]
    public int initialDuration = 10;
    //[HideInInspector]
    public float duration;
    
    private float fireCountdown = 0f;
    private bool isWorking = true;
    
    
    void Start()
    {
        GameEvent.current.onWaveChanged += decreaseDuration;
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        duration = initialDuration;
    }

    void Update()
    {
        
        if (duration > 0)
        {
            isWorking = true;
        }
        
        if (duration < 0)
        {
            smoke.SetActive(true);
            isWorking = false;
            partToRotate.rotation = Quaternion.Euler(25f, -90f, 0f);
            if (isFirethrower)
            {
                fireparticle.SetActive(false);
            }
        }
        
        if(!isWorking)
            return;

        fireCountdown -= Time.deltaTime;
        
        if (target == null)
        {
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
    }

    private void decreaseDuration()
    {
        if (duration >= 0)
        {
            duration--;
        }
    }
    
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    
    void UpdateTarget()
    {
        if(!isWorking)
            return;
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range && isWorking)
        {
            if (isFirethrower)
            {
                fireparticle.SetActive(true);
            }
            target = nearestEnemy.transform;
            
        }
        else
        {
            target = null;
            if (isFirethrower)
            {
                fireparticle.SetActive(false);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

}
