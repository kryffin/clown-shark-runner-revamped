using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPickup : MonoBehaviour
{
    private GameClock gc;

    public ParticleSystem pickupPs;

    private float rotationSpeed = 30f;

    public BonusManager bm;

    private void Start()
    {
        gc = FindObjectOfType<GameClock>();

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(45f, 0f, 45f);
        transform.rotation = rotation;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime * gc.GetUnscaledScale(), rotationSpeed * Time.deltaTime * gc.GetUnscaledScale(), rotationSpeed * Time.deltaTime * gc.GetUnscaledScale()));
    }

    private void OnTriggerEnter(Collider other)
    {
        pickupPs.Play();

        bm.Trigger();
        GetComponent<MeshRenderer>().enabled = false;
    }

}
