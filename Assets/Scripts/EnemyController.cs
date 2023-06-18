using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyRB.velocity.y == 0 && GameManager.isGamePlaying && !GameManager.isGameOver) {
          enemyRB.velocity = new Vector2(-4, 0);
        }

        if(transform.position.x < -GameManager.screenWidthRatio) {
          Destroy(this.gameObject);
        }
    }
}
