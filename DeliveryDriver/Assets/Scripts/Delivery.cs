using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    Color32 carColorhasPackage = new Color32(1, 1, 1, 1);
    [SerializeField]
    Color32 carColornoPackage = new Color32(1, 1, 1, 1);
    [SerializeField]
    float destroyDelay = 0.5f;
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;
    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = carColorhasPackage;
            Destroy(other.gameObject, destroyDelay);
        }
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered!");
            hasPackage = false;
            spriteRenderer.color = carColornoPackage;
        }
    }
}

