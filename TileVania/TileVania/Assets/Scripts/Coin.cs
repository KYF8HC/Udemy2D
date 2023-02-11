using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] int pointForCoin = 100;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointForCoin);
            AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);          
            Destroy(gameObject);
        }
    }
}
