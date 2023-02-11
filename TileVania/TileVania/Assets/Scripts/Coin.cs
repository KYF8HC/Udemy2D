using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] int pointForCoin = 100;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameSession>().AddToScore(pointForCoin);
            AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);          
            Destroy(gameObject);
        }
    }
}
