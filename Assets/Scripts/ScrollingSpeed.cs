using UnityEngine;

public class ScrollingSpeed : MonoBehaviour
{
    private GameClock gc;
    private Rigidbody rb;

    public bool isNarwhal = false;

    private void Start()
    {
        gc = FindObjectOfType<GameClock>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isNarwhal)
            rb.velocity = new Vector3(0f, 0f, -(30f * gc.GetScale()));
        else
            rb.velocity = new Vector3(0f, 0f, -(15f * gc.GetScale()));
    }
}
