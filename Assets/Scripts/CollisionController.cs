using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Wow mais c'est génial ici");
    }
}
