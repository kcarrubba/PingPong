using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    public ScoreManager score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized; //(1,1)

        // Find the ScoreManager object
        score = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreManager>();
    }

    void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Right Paddle") || collision.gameObject.CompareTag("Left Paddle"))
        {
            direction.x = -direction.x; // bounce horizontally on paddle
        }
        else if (collision.gameObject.CompareTag("Right Wall"))
        {
            score.AddScore(1); // Player 1 scores
            ResetBall();       // reset instead of disabling
        }
        else if (collision.gameObject.CompareTag("Left Wall"))
        {
            score.AddScore(2); // Player 2 scores
            ResetBall();       // reset instead of disabling
        }
        else if (collision.gameObject.CompareTag("Top Wall") || collision.gameObject.CompareTag("Bottom Wall"))
        {
            direction.y = -direction.y; // bounce vertically
        }
    }

    void ResetBall()
    {
        // Stop current movement
        rb.linearVelocity = Vector2.zero;

        // Reset the position to center
        transform.position = Vector2.zero;

        // Reset trail
        GetComponent<TrailRenderer>().Clear();

        // Randomize starting direction: either (1,1) or (-1,1)
        int rand = Random.Range(0, 2); // 0 or 1
        if (rand == 0)
            direction = new Vector2(1f, 1f).normalized;
        else
            direction = new Vector2(-1f, 1f).normalized;

        // Relaunch after a short delay
        Invoke(nameof(LaunchBall), 3f);
    }

    void LaunchBall()
    {
        rb.linearVelocity = direction * speed;
    }
}
