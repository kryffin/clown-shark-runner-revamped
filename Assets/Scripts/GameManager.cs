using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public InputAction esc;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (esc.triggered)
            SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        esc.Enable();
    }

    private void OnDisable()
    {
        esc.Disable();
    }

}
