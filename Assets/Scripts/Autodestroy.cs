using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{

    private Rigidbody rb;
    public bool isLarge = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Autodestroys moving objects when passing behind the player
    private void Update()
    {
        if (rb.position.z < -5f && !isLarge)
            Destroy(gameObject);
        else if (rb.position.z < -55f)
            Destroy(gameObject);
    }
}
