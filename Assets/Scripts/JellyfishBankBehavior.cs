using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishBankBehavior : MonoBehaviour
{

    private GameClock gc;
    public Vector2 direction;
    private float speed;

    private void Start()
    {
        gc = FindObjectOfType<GameClock>();
        speed = Random.Range(0.1f, 1.5f);
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * direction * gc.GetScale() * Time.fixedDeltaTime);
    }
}
