using UnityEngine;

public class GameClock : MonoBehaviour
{

    public float time = 0f;
    private float timeScale = 1f;

    private bool isGameSlowed = false;
    private bool isGameAccelerated = false;

    private bool isGameOver = false;

    private void Update()
    {
        if (isGameOver)
            return;

        time += timeScale * Time.deltaTime;

        timeScale = 0.0166667f * time + 1; //formula to obtain 1.5x tS at 30s and 2x tS at 60s (and so on)
    }

    public void SlowTime()
    {
        isGameSlowed = true;
    }

    public void UnslowTime()
    {
        isGameSlowed = false;
    }

    public void AccelerateTime()
    {
        isGameAccelerated = true;
    }

    public void DecelerateTime()
    {
        isGameAccelerated = false;
    }

    public float GetScale()
    {
        if (isGameOver)
            return 0f;
        if (isGameSlowed)
            return timeScale / 2f;
        if (isGameAccelerated)
            return timeScale * 1.5f;

        return timeScale;
    }

    public float GetUnscaledScale()
    {
        if (isGameOver)
            return 0f;
        return 1f;
    }

    public void GameOver()
    {
        isGameOver = true;
    }

}
