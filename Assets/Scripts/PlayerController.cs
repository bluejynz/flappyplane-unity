using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Vector2 jumpStrength;
    private float playerPosMax;
    private float playerPosMin;

    public GameObject featherParticles;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.isGamePlaying = false;
        playerRB = GetComponent<Rigidbody2D>();
        jumpStrength = new Vector2(0f, 500f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GameManager.isGameOver)
        {
            if (!GameManager.isGamePlaying)
            {
                GameManager.isGamePlaying = true;
                playerRB.isKinematic = false;
                GetComponent<Collider2D>().enabled = true;
            }

            playerRB.velocity = Vector2.zero;
            playerRB.AddForce(jumpStrength);

            GameObject particle = Instantiate(featherParticles);
            Vector3 offsetPos = this.transform.position + new Vector3(0, 1f, 0);
            particle.transform.position = offsetPos;
        }

        playerPosMax = Camera.main
            .WorldToScreenPoint(
                transform.position + (GetComponent<SpriteRenderer>().bounds.size / 2f)
            )
            .y;
        playerPosMin = Camera.main
            .WorldToScreenPoint(
                transform.position - (GetComponent<SpriteRenderer>().bounds.size / 2f)
            )
            .y;

        if (playerPosMax - 40f > Screen.height || playerPosMin + 40f < 0 && GameManager.isGamePlaying)
        {
            Debug.Log(
                $"Player position max: {playerPosMax} | Screen height: {Screen.height}\nPlayer position min: {playerPosMin} | 0"
            );
            KillPlayer();
        }

        transform.rotation = Quaternion.Euler(0f, 0f, playerRB.velocity.y * 3f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        if (!GameManager.isGameOver)
        {
            Debug.Log("Game Over");
            GameManager.isGameOver = true;
            GameManager.isGamePlaying = false;

            GetComponent<Collider2D>().enabled = false;
            playerRB.velocity = Vector2.zero;
            playerRB.AddForce(new Vector2(-300f, 0f));
            playerRB.AddTorque(300f);
            GetComponent<SpriteRenderer>().color = new Color(1f, .35f, .35f);
        }
    }

    void Score() {
      GameManager.score++;
      scoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {GameManager.score}";
    }
}
