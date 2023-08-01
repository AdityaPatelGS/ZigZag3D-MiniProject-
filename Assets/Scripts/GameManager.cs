using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text ScoreText;
    public Text highScoreText;

    public GameObject SelectedPlayer;

    public GameObject DefaultPlayer;

    public Transform PlayerStart;

    public GameObject Player;

    private void Awake()
    {
        highScoreText.text = "best : " + getHighScore().ToString();
        Application.targetFrameRate = 144;
        SelectedPlayer = DefaultPlayer;
        Player = Instantiate(SelectedPlayer,PlayerStart.position,Quaternion.Euler(0,45,0));

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
        // if(PlayerPrefs.HasKey("HighScore"))
        // {
        //     return PlayerPrefs.GetInt("Highscore");
        // }
        // else
        // {
        //     return 0;
        // }        
        return PlayerPrefs.HasKey("HighScore")?PlayerPrefs.GetInt("Highscore"):0;
    }
}
