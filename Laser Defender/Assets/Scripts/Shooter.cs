using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField]GameObject projectilePrefab;
    [SerializeField]float projectileSpeed = 10f;
    [SerializeField]float projectileLifeTime = 5f;
    
    [Header("AI")]
    [SerializeField]bool useAI;
    [SerializeField]float firingRate = 1.5f;
    [SerializeField]float firingRateVariance = 0f;
    [SerializeField]float minimumfiringRate = 0.2f;

    [HideInInspector]public bool isFiring;
    Coroutine firingCoroutine;

    void Start()
    {
        if(useAI)
            isFiring = true;
    }
    void Update()
    {
        Fire();   
    }
    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
           firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    IEnumerator FireContinuosly()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                            transform.position, 
                                            Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
                rb.velocity = transform.up * projectileSpeed;
            Destroy(instance, projectileLifeTime);
            float spawnTime = UnityEngine.Random.Range(firingRate - firingRateVariance, 
                                        firingRate + firingRateVariance);
            spawnTime = Mathf.Clamp(spawnTime, minimumfiringRate, float.MaxValue);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    
}
