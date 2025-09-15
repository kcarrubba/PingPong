using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D pad;
    public float displacement;
    private bool isRightPaddle;
    public ScoreManager scoreManager;

    void Start()
    {
        pad = GetComponent<Rigidbody2D>();

        // Decide which paddle based on tag
        if (gameObject.CompareTag("Right Paddle"))
            isRightPaddle = true;
        else if (gameObject.CompareTag("Left Paddle"))
            isRightPaddle = false;
    }

    void FixedUpdate()
    {
        // stop paddle movement if game over
        if (scoreManager != null && scoreManager.gameOver)
            return;

        // Get paddle position
        Vector2 pos = pad.position;

        // Right paddle logic
        if (isRightPaddle)
        {
            // Up/Down arrows
            if (Input.GetKey(KeyCode.UpArrow) && pos.y <= 4f)
            {
                pos.y += displacement * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && pos.y >= -4f)
            {
                pos.y -= displacement * Time.deltaTime;
            }
        }
        // Left paddle logic
        else
        {
            // A/Z keys
            if (Input.GetKey(KeyCode.A) && pos.y <= 4f)
            {
                pos.y += displacement * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.Z) && pos.y >= -4f)
            {
                pos.y -= displacement * Time.deltaTime;
            }
        }

        pad.MovePosition(pos);
    }
}
