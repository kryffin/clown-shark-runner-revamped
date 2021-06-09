using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusUI : MonoBehaviour
{

    public Image display;
    public Sprite[] bonusImages;

    private void Start()
    {
        display = GetComponent<Image>();
    }

    public void PickUp(int bonus)
    {
        if (bonus == -1)
        {
            display.enabled = false;
            return;
        }

        display.enabled = true;
        display.sprite = bonusImages[bonus];
    }

}
