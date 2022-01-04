using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{

    public BonusManager bm;

    public GameObject bonusPrefab;
    public GameObject pearlShellPrefab;
    public GameObject fishHookPrefab;

    private float spawnClock = 0.5f;
    private float spawnDelay = 6f;

    private Vector3 startVelocity = new Vector3(0f, 0f, -15f);

    private void Update()
    {
        if (Time.time >= spawnClock + spawnDelay)
        {
            float rng = Random.Range(0f, 1f);

            if (rng < 0.33f)
                SpawnPearlShell();
            else if (rng < 0.66f)
                SpawnFishHook();
            else
                SpawnBonus();

            spawnClock = Time.time;
        }
    }

    private void SpawnBonus()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), Random.Range(1f, 14f), 60f);
        GameObject coral = Instantiate(bonusPrefab, spawnPos, Quaternion.identity, this.transform);
        coral.GetComponent<Rigidbody>().velocity = startVelocity;
        coral.GetComponent<BonusPickup>().bm = bm;
    }

    private void SpawnPearlShell()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), -0.5f, 60f);
        GameObject pearlShell = Instantiate(pearlShellPrefab, spawnPos, Quaternion.identity, this.transform);
        pearlShell.GetComponent<Rigidbody>().velocity = startVelocity;
        pearlShell.transform.Find("Bonus").GetComponent<Rigidbody>().velocity = startVelocity;
        pearlShell.transform.Find("Bonus").GetComponent<BonusPickup>().bm = bm;
    }

    private void SpawnFishHook()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), Random.Range(5.5f, 13f), 60f);
        GameObject fishHook = Instantiate(fishHookPrefab, spawnPos, Quaternion.identity, this.transform);
        fishHook.GetComponent<Rigidbody>().velocity = startVelocity;
        fishHook.transform.Find("Pivot").Find("Fish").GetComponent<Rigidbody>().velocity = startVelocity;
        fishHook.transform.Find("Pivot").Find("Fish").GetComponent<HealingFish>().bm = bm;
    }
}
