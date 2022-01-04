using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFish : MonoBehaviour
{

    public BonusManager bm;

    private void Start()
    {
        int rand = Random.Range(0, 3);
        Quaternion rot = Quaternion.Euler(0f, rand * 90f, 0f);
        transform.parent.transform.rotation = rot;
    }

    private void OnTriggerEnter(Collider other)
    {
        bm.TriggerHeal();
        GetComponent<MeshRenderer>().enabled = false;
    }
}
