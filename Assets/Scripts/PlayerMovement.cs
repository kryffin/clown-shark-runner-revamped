using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController cc;

    public float speed = 1f;

    public InputAction mvtInput;

    private Vector2 mvt;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Input
        mvt = mvtInput.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Movement
        cc.Move(mvt.normalized * speed);
    }

    private void OnEnable()
    {
        mvtInput.Enable();
    }

    private void OnDisable()
    {
        mvtInput.Disable();
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }

}
