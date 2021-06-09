using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTiler : MonoBehaviour
{

    private Rigidbody rb;
    public Transform nextTile;
    public GameObject tile;

    private bool spawned = false;
    private Vector3 startVelocity = new Vector3(0f, 0f, -15f);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = startVelocity;
    }

    private void Update()
    {
        if (!spawned && rb.position.z <= -5f)
            SpawnTile();

        if (rb.position.z <= -84f)
            Destroy(gameObject);
    }

    private void SpawnTile()
    {
        GameObject spawnedTile = Instantiate(tile, nextTile.position, Quaternion.identity);
        spawnedTile.name = "Ground";
        spawned = true;
    }
}
