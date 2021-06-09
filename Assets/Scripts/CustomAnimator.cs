using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimator : MonoBehaviour
{

    private GameClock gc;

    private MeshFilter mf;

    public Mesh[] frames;
    private int curFrame = 0;
    private bool asc;

    public bool isNotLooping = false;

    public float delay;

    private float clk = 0f;
 
    private void Start()
    {
        gc = FindObjectOfType<GameClock>();
        mf = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        if (clk < Time.time)
        {
            mf.mesh = frames[curFrame];
            if (isNotLooping)
            {
                curFrame = ++curFrame % frames.Length;
            }
            else
                NextFrame();

            clk = Time.time + (delay / gc.GetScale());
        }
    }

    private void NextFrame()
    {
        if (asc && curFrame + 1 < frames.Length) //ascending
            curFrame++;
        else if (!asc && curFrame - 1 >= 0) //descending
            curFrame--;
        else if (asc) //ascending but encountered upper bound
        {
            curFrame--;
            asc = false;
        }
        else if (!asc) //ascending but encountered lower bound
        {
            curFrame++;
            asc = true;
        }
    }
}
