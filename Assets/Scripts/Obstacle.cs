using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody rb;
    private bool triggered = false; //has the obstacle been triggered ?
    private BankObstacle bo;

    public bool isJellyfish = false;
    public bool isLarge = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (isJellyfish)
            bo = transform.parent.parent.GetComponent<BankObstacle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isJellyfish && !bo.triggered)
        {
            other.GetComponent<PlayerStats>().TakeDamage(isLarge);
            bo.Trigger();

            return;
        }

        if (!triggered)
        {
            other.GetComponent<PlayerStats>().TakeDamage(isLarge);

            triggered = true;
        }
    }
}
