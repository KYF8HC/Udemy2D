using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake = false;
    [SerializeField] int givenScore = 0;
    [SerializeField] bool Player;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamageClip();
            damageDealer.Hit();
        }
    }
    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
    void UpdateScore()
    {
        if(scoreKeeper != null && givenScore > 0)
        {
            scoreKeeper.UpdateScore(givenScore);
        }
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        UpdateScore();
        if(Player)
            levelManager.LoadGameOver();
    }
    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, 
                                                transform.position, 
                                                Quaternion.identity);
            Destroy(instance.gameObject, 
                    instance.main.duration + 
                    instance.main.startLifetime.constantMax);
        }
    }
    public int GetHealth()
    {
        return health;
    }
}