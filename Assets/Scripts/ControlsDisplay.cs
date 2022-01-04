using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsDisplay : MonoBehaviour
{
    private Image img;
    public Sprite[] layouts;

    private float clock = 0f;
    private float delay = 1f;

    private int cur = 0;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if (clock < Time.time)
        {
            img.sprite = layouts[cur];
            cur = 1 - cur;

            clock = Time.time + delay;
        }
    }
}
