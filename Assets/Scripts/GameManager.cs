using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        screenHeightRatio = Camera.main.orthographicSize * 2f;
        screenWidthRatio = screenHeightRatio / Screen.height * Screen.width;
        maxHeight = screenHeightRatio - enemy.GetComponent<SpriteRenderer>().bounds.size.y;

        InvokeRepeating("SpawnEnemy", 1f, 1.5f);
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
}
