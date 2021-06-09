using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankObstacle : MonoBehaviour
{
    public bool triggered = false;

    public void Trigger()
    {
        triggered = true;
    }
}
