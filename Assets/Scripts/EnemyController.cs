using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D enemyRB;
    private bool scoredPoint;
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        scoredPoint = false;
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyRB.velocity.y == 0 && GameManager.isGamePlaying && !GameManager.isGameOver)
        {
            enemyRB.velocity = new Vector2(-4, 0);
        }

        if (transform.position.x < -GameManager.screenWidthRatio)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.x < player.transform.position.x && !scoredPoint)
        {
            scoredPoint = true;
            player.SendMessage("Score");
        }
    }
}
