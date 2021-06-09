using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject controlsScreen;
    public GameObject aboutScreen;

    public FloatingTitle ft;

    private bool isControlsScreenActive = false;
    private bool isAboutScreenActive = false;

    private void Start()
    {
        titleScreen.SetActive(true);
        controlsScreen.SetActive(false);
        aboutScreen.SetActive(false);

        ft.Descend();
    }

    public void Play()
    {
        // Loading the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleControlsScreen()
    {
        if (isControlsScreenActive)
            ft.Descend();
        else
            ft.Ascend();

        controlsScreen.SetActive(!isControlsScreenActive);
        titleScreen.SetActive(isControlsScreenActive);

        isControlsScreenActive = !isControlsScreenActive;
    }

    public void ToggleAboutScreen()
    {
        if (isAboutScreenActive)
            ft.Descend();
        else
            ft.Ascend();

        aboutScreen.SetActive(!isAboutScreenActive);
        titleScreen.SetActive(isAboutScreenActive);

        isAboutScreenActive = !isAboutScreenActive;
    }

    public void Quit()
    {
        // Closing the game
        Application.Quit();
    }

}
