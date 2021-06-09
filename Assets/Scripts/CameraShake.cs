using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private Transform cameraTransform;

    private float shake = 0f;
    private float shakeAmount = .2f;
    private float decreaseFactor = 1f;

    private void Start()
    {
        cameraTransform = transform;
    }

    private void Update()
    {
        if (shake > 0f)
        {
            cameraTransform.position += Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0f;
        }
    }

    public void Shake()
    {
        shake = .2f;
    }

}
