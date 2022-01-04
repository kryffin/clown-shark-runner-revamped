using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject[] coralPrefabs;
    public GameObject chestPrefab;
    public GameObject boatPrefab;
    public GameObject narwhalPrefab;
    public GameObject statuePrefab;
    public GameObject[] bankPrefabs;

    private float obstacleSpeed = -15f;
    private float narwhalSpeed = -30f;

    private float depth = 80f;

    private float spawnClock = 0f;
    private float spawnDelay = 1f;

    //Status spawn points
    private Vector3[] statueSpawns =
    {
        new Vector3(14.87f, -6.88f),
        new Vector3(-22.3f, -3.7f),
        new Vector3(-2f, -15.4f)
    };

    private float[] statueRotations =
    {
        44.85f,
        -64.71f,
        -7.48f
    };

    private void Update()
    {
        if (Time.time >= spawnClock + spawnDelay)
        {
            float rng = Random.Range(0f, 1f);

            if (rng < .05f)
                SpawnBoat();
            else if (rng < .1f)
                SpawnChest();
            else if (rng < .35f)
                SpawnNarwhal();
            else if (rng < .4f)
                SpawnStatue();
            else if (rng < .65f)
                SpawnJellyfishBank();
            else
                SpawnCoral();

            spawnClock = Time.time;
        }
    }

    private void SpawnCoral()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), -1f, depth);
        int rand = Random.Range(0, coralPrefabs.Length);
        GameObject coral = Instantiate(coralPrefabs[rand], spawnPos, Quaternion.identity);

        coral.transform.localScale = new Vector3(Random.Range(1f, 4f), Random.Range(1f, 4f), Random.Range(0.8f, 1.2f));
        coral.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, obstacleSpeed);
    }

    private void SpawnChest()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), -1f, depth);
        GameObject chest = Instantiate(chestPrefab, spawnPos, Quaternion.identity);

        float scale = Random.Range(.8f, 2f);
        chest.transform.localScale = new Vector3(scale, scale, scale);

        float rotation = Random.Range(-45f, 45f);
        chest.transform.eulerAngles = new Vector3(0f, 0f, rotation);

        chest.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, obstacleSpeed);
    }

    private void SpawnBoat()
    {
        Vector3 spawnPos = new Vector3(4f, 11f, depth);
        GameObject boat = Instantiate(boatPrefab, spawnPos, Quaternion.identity);

        boat.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, obstacleSpeed);
    }

    private void SpawnNarwhal()
    {
        Vector3 spawnPos = Vector3.zero;

        float rng = Random.Range(0f, 1f);
        if (rng <= 0.33f)
            spawnPos = new Vector3(player.position.x, player.position.y - 0.5f, depth);
        else
            spawnPos = new Vector3(Random.Range(-10f, 10f), Random.Range(6f, 14f), depth);

        GameObject narwhal = Instantiate(narwhalPrefab, spawnPos, Quaternion.identity);

        narwhal.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, narwhalSpeed);
    }

    private void SpawnStatue()
    {
        int rand = Random.Range(0, statueSpawns.Length);
        Vector3 spawnPos = statueSpawns[rand];
        spawnPos.z = depth;

        GameObject statue = Instantiate(statuePrefab, spawnPos, Quaternion.Euler(0f, 0f, statueRotations[rand]));

        statue.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, obstacleSpeed);
    }

    private void SpawnJellyfishBank()
    {
        int rand = Random.Range(0, bankPrefabs.Length);
        Vector3 spawnPos = new Vector3(0f, 7.5f, depth);

        GameObject bank = Instantiate(bankPrefabs[rand], spawnPos, Quaternion.identity);
    }
}
