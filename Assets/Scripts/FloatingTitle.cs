using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTitle : MonoBehaviour
{
    public Transform pivot;
    public Animator animator;

    private bool isDisplayed = true;

    private Vector3 fromPosition = new Vector3(0f, 0f, 7f);
    private Vector3 toPosition = new Vector3(0f, 0f, -7f);
    private float frequency = .5f;

    private void Update()
    {
        if (isDisplayed)
        {
            Quaternion from = Quaternion.Euler(fromPosition);
            Quaternion to = Quaternion.Euler(toPosition);

            float lerp = 0.5f * (1.0f + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * frequency));
            pivot.localRotation = Quaternion.Lerp(from, to, lerp);
        }
    }

    public void Ascend()
    {
        animator.SetTrigger("Ascend");
    }

    public void Descend()
    {
        animator.SetTrigger("Descend");
    }
}
