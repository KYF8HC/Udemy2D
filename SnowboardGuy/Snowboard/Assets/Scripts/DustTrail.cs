using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
   [SerializeField] ParticleSystem trail;
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            trail.Play();
        }
    }
    void OnCollisionExit2D(Collision2D other) 
    {
            trail.Stop();
    }
}
