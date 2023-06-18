using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGamePlaying;
    private bool isGameOver;
    private Rigidbody2D playerRB;
    private Vector2 jumpStrength;
    private float playerPos;

    public GameObject featherParticles;

    // Start is called before the first frame update
    void Start()
    {
        isGamePlaying = false;
        playerRB = GetComponent<Rigidbody2D>();
        jumpStrength = new Vector2(0f, 500f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isGameOver)
        {
            if (!isGamePlaying)
            {
                isGamePlaying = true;
                playerRB.isKinematic = false;
            }

            playerRB.velocity = new Vector2(0f, 0f);
            playerRB.AddForce(jumpStrength);

            GameObject particle = Instantiate(featherParticles);
            Vector3 offsetPos = this.transform.position + new Vector3(0, 1f, 0);
            particle.transform.position = offsetPos;
        }

        playerPos = Camera.main.WorldToScreenPoint(transform.position).y;

        if (playerPos > Screen.height)
        {
            isGameOver = true;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, playerRB.velocity.y * 3f);
    }
}
