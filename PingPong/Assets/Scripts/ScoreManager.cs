using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public GameObject ball;

    int p1 = 0;
    int p2 = 0;
    int winScore = 5;
    public bool gameOver = false;

    public void AddScore(int player)
    {
        if (player == 1)
        {
            p1++;
        }
        else if (player == 2)
        {
            p2++;
        }

        // Update score display
        scoreText.text = p1.ToString() + " | " + p2.ToString();

        // Check for win condition
        if (p1 >= winScore)
        {
            winText.text = "Player 1 Wins!";
            ball.SetActive(false);
            gameOver = true;
        }
        else if (p2 >= winScore)
        {
            winText.text = "Player 2 Wins!";
            ball.SetActive(false);
            gameOver = true;
        }
    }
}