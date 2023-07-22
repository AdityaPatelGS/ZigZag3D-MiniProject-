using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text ScoreText;
    public Text CurrentText;
    public Text highScoreText;

    private void Awake()
    {
        highScoreText.text = "best : " + getHighScore().ToString();
        Application.targetFrameRate = 144;
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        score++;
        ScoreText.text = score.ToString();

        if(score > getHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "Best : " + score.ToString();
        }
    }

    public int getHighScore()
    {        
        return PlayerPrefs.GetInt("Highscore");
    }
}
