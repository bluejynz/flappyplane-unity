using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startText;
    public static int score;
    public static bool isGamePlaying;
    public static bool isGameOver;
    public static float screenWidthRatio;
    public static float screenHeightRatio;
    public GameObject enemy;
    private float rngHeight;
    private float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isGamePlaying = false;
        score = 0;

        screenHeightRatio = Camera.main.orthographicSize * 2f;
        screenWidthRatio = screenHeightRatio / Screen.height * Screen.width;
        maxHeight = screenHeightRatio - enemy.GetComponent<SpriteRenderer>().bounds.size.y;

        InvokeRepeating("SpawnEnemy", 1f, 1.5f);
    }

    void Update()
    {
        if (!isGamePlaying && !isGameOver)
        {
            startText.active = true;
        }
        else
        {
            startText.active = false;
        }

        if (!isGamePlaying && isGameOver)
        {
            RestartGame();
        }
    }

    void SpawnEnemy()
    {
        if (GameManager.isGamePlaying && !GameManager.isGameOver)
        {
            rngHeight = maxHeight * Random.value - (maxHeight / 2f);

            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector2(screenWidthRatio + 2f, rngHeight);
        }
    }

    public void RestartGame()
    {
        StartCoroutine(WaitAndRestart(3));
    }

    IEnumerator WaitAndRestart(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainScene");
    }
}
