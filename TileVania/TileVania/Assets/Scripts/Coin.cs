using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSFX;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);
            
            Destroy(gameObject);
        }
    }
}
