using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishBehavior : MonoBehaviour
{
    private GameClock gc;

    private float rotationSpeed;
    private int direction;
    private Vector2 randMvt;

    private void Start()
    {
        gc = FindObjectOfType<GameClock>();

        Quaternion rot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        transform.rotation = rot;

        rotationSpeed = Random.Range(5f, 45f);
        direction = Random.Range(0, 1);
        if (direction == 0)
            direction = -1;
        randMvt = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
    }

    private void FixedUpdate()
    {
        transform.Translate(randMvt * Time.fixedDeltaTime * gc.GetUnscaledScale());
        transform.Rotate(new Vector3(0f, direction * rotationSpeed * Time.fixedDeltaTime * gc.GetUnscaledScale(), 0f));
    }
}
