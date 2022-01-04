using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameClock gc;

    public GameMenuController gmc;
    public CameraShake cs;

    public ParticleSystem trailPs;
    public ParticleSystem healPs;
    public ParticleSystem hurtPs;
    public ParticleSystem deathPs;

    private AudioManager am;

    public int maxHealth = 3;
    private int health;

    private float distance = 0f;
    private int hits = 0;

    private bool isGameOver = false;

    private void Start()
    {
        am = FindObjectOfType<AudioManager>();

        health = maxHealth;
    }

    private void Update()
    {
        if (!isGameOver)
            distance += 1f * gc.GetScale() * Time.deltaTime;
    }

    public void TakeDamage(bool isLarge)
    {
        if (isGameOver)
            return;

        if (isLarge)
        {
            cs.Shake();
            am.Play("LargeHurt");
        }
        else
            am.Play("Hurt");


        health--;
        hits++;

        hurtPs.Play();

        UpdateHealth();

        if (health <= 0)
            Death();
    }

    public void RestoreHealth(int amount)
    {
        health += amount;

        am.Play("Heal");

        healPs.Play();

        UpdateHealth();
    }

    private void UpdateHealth()
    {
        var em = trailPs.emission;
        em.rateOverTime = health;
    }

    private void Death()
    {
        isGameOver = true;

        am.Play("Death");

        GetComponent<BonusManager>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;

        FindObjectOfType<ObstacleSpawner>().enabled = false;
        FindObjectOfType<BonusSpawner>().enabled = false;

        Cursor.visible = true;

        gc.GameOver();
        gmc.UpdateDistance(distance);
        gmc.UpdateHits(hits);
        deathPs.Play();
        gmc.GameOver();
    }

}
