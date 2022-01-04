using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{

    public Image cooldownBar;

    private Color buffColor = new Color(0f, .75f, 0f, 1f);
    private Color debuffColor = new Color(.75f, 0f, 0f, 1f);

    private float cooldownClock = 0f;
    private float cooldownDuration = 0f;
    private bool isCooldown = false;

    private void Start()
    {
        cooldownBar = GetComponent<Image>();
        cooldownBar.fillAmount = 0f;
    }

    private void Update()
    {
        if (isCooldown)
        {
            cooldownBar.fillAmount = 1f - ((Time.time - cooldownClock) / cooldownDuration);

            if (Time.time > cooldownClock + cooldownDuration)
                ResetCooldown();
        }
    }

    public void StartCooldown(float duration, bool debuff)
    {
        cooldownClock = Time.time;
        cooldownDuration = duration;

        if (debuff)
            cooldownBar.color = debuffColor;
        else
            cooldownBar.color = buffColor;

        isCooldown = true;
    }

    private void ResetCooldown()
    {
        cooldownBar.fillAmount = 0f;

        isCooldown = false;
    }
}
