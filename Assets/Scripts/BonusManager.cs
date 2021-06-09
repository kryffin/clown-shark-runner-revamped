using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{

    enum Bonuses
    {
        HighSpeed,
        BabyShark,
        SlowTime
    }

    public PlayerMovement pm;
    public PlayerStats ps;
    public CharacterController cc;
    public CustomAnimator ca;

    public BonusUI bUI;
    public CooldownBar cb;

    public InputAction useBonusInput;

    private AudioManager am;

    public GameClock gc;

    private int bonus = -1;
    private bool isUsed = false;

    // High Speed Pick Up
    public ParticleSystem speedLines;
    private float highSpeed = 0.4f;
    private float memSpeedHs;
    private bool isHighSpeed = false;

    private float hsClock = 0f;
    private float hsDuration = 5f;

    // Health Up
    private int heal = 1;

    // Baby Shark
    public GameObject sharkModel;
    public GameObject fishModel;
    private bool isBabyShark = false;

    private float bsClock = 0f;
    private float bsDuration = 5f;

    //Slow Time
    public CameraInverter ci;
    private bool isTimeSlowed = false;

    private float stClock = 0f;
    private float stDuration = 6f;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        ps = GetComponent<PlayerStats>();
        cc = GetComponent<CharacterController>();
        am = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (useBonusInput.triggered)
            UseBonus();

        if (isHighSpeed)
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 75f, 0.05f);
        else
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, 0.02f);

        if (isHighSpeed && hsClock + hsDuration < Time.time)
            HS_Reset();

        if (isBabyShark && bsClock + bsDuration < Time.time)
            BS_Reset();

        if (isTimeSlowed && stClock + stDuration < Time.time)
            ST_Reset();
    }

    public void Trigger()
    {
        if (bonus != -1)
            return;

        am.Play("Bonus");

        bonus = Random.Range(0, System.Enum.GetValues(typeof(Bonuses)).Length);

        bUI.PickUp(bonus);
    }

    public void TriggerHeal()
    {
        HU_Trigger();
    }

    private void UseBonus()
    {
        if (isUsed)
            return;

        isUsed = true;

        switch (bonus)
        {
            case -1: //No Bonus
                Debug.LogWarning("No bonus held !");
                isUsed = false;
                break;

            case (int)Bonuses.HighSpeed:
                HS_Trigger();
                break;

            case (int)Bonuses.BabyShark:
                BS_Trigger();
                break;

            case (int)Bonuses.SlowTime:
                ST_Trigger();
                break;

            default:
                Debug.LogWarning("Unknown bonus used !");
                break;
        }
    }

    private void ResetBonus()
    {
        isUsed = false;
        bonus = -1;
        bUI.PickUp(bonus);
    }

    private void HS_Trigger()
    {
        am.Play("SpeedUp");

        memSpeedHs = pm.GetSpeed();
        pm.SetSpeed(highSpeed);

        gc.AccelerateTime();

        speedLines.Play();

        cb.StartCooldown(hsDuration, false);

        isHighSpeed = true;
        hsClock = Time.time;
    }

    private void HS_Reset()
    {
        pm.SetSpeed(memSpeedHs);

        gc.DecelerateTime();

        speedLines.Stop();

        ResetBonus();

        isHighSpeed = false;
    }

    private void HU_Trigger()
    {
        ps.RestoreHealth(heal);
    }

    private void BS_Trigger()
    {
        am.Play("BabyShark");

        cc.radius = 0.25f;
        cc.height = 0.5f;

        sharkModel.SetActive(false);
        fishModel.SetActive(true);

        cb.StartCooldown(bsDuration, false);

        isBabyShark = true;
        bsClock = Time.time;
    }

    private void BS_Reset()
    {
        cc.radius = 0.5f;
        cc.height = 1f;

        fishModel.SetActive(false);
        sharkModel.SetActive(true);

        ResetBonus();

        isBabyShark = false;
    }

    private void ST_Trigger()
    {
        am.Play("SlowTime");
        am.SetPitch("Soundtrack", 0.5f);

        //invert screen colors
        ci.Invert();

        //modify timescale
        gc.SlowTime();

        cb.StartCooldown(stDuration, false);

        isTimeSlowed = true;
        stClock = Time.time;
    }

    private void ST_Reset()
    {
        am.SetPitch("Soundtrack", 1f);

        //uninvert screen colors
        ci.Invert();

        //reset timeScale
        gc.UnslowTime();

        ResetBonus();

        isTimeSlowed = false;
    }

    private void OnEnable()
    {
        useBonusInput.Enable();
    }

    private void OnDisable()
    {
        useBonusInput.Disable();
    }

}
