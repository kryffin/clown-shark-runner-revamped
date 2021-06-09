using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{

    public GameObject gameOverScreen;
    public TMPro.TextMeshProUGUI distanceCount;
    public TMPro.TextMeshProUGUI hitsCount;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void UpdateDistance(float distance)
    {
        distanceCount.text = "Distance : " + distance.ToString(".##") + " m";
    }

    public void UpdateHits(int hits)
    {
        hitsCount.text = "Hits : " + hits;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
