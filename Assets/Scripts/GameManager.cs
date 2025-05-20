using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    private int score;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject getReady;
    public GameObject playButton;
    public GameObject resetButton;

    private void Awake()
    {
        gameOver.SetActive(false);
        resetButton.SetActive(false);
        getReady.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
    public void Play()
    {
        getReady.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
    }
    public void Restart()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        resetButton.SetActive(false);
        getReady.SetActive(true);
        playButton.SetActive(true);
        player.ResetPosition();

        Pipes[] pipes = Object.FindObjectsByType<Pipes>(FindObjectsSortMode.None);
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Scoring()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        resetButton.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
}
