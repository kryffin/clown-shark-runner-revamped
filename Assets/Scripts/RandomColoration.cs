using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColoration : MonoBehaviour
{

    private Color[] colors =
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.magenta,
        Color.yellow,
        Color.cyan
    };

    public bool isJellyfish = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isJellyfish)
        {
            Color jellyfishColor = GetComponent<MeshRenderer>().material.color;
            jellyfishColor.r += Random.Range(-0.5f, 0.5f);
            jellyfishColor.g += Random.Range(-0.5f, 0.5f);
            jellyfishColor.b += Random.Range(-0.5f, 0.5f);

            GetComponent<MeshRenderer>().material.color = jellyfishColor;
            return;
        }

        Color color = colors[Random.Range(0, colors.Length)];
        color.r -= Random.Range(-color.r, color.r);
        color.g -= Random.Range(-color.g, color.g);
        color.b -= Random.Range(-color.b, color.b);

        GetComponent<MeshRenderer>().material.color = color;
    }

}
