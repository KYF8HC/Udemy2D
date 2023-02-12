using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = .5f;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = initialPosition + 
                                (Vector3)Random.insideUnitCircle * 
                                shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}