using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text ScoreText;
    public Text highScoreText;

    public Transform PlayerStart;

    public int SelectedPlayerIndex;

    public FollowCam FC;

    public GameObject MainMenuPanel;
    public GameObject PauseMenuPanel;

    public GameObject DefaultPlayer;
    public GameObject SelectedPlayer;
    public GameObject SpawnedPlayer;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Player5;
    public GameObject Player6;
    private void Awake()
    {
        highScoreText.text = "best : " + getHighScore().ToString();
        Application.targetFrameRate = 144;
        MainMenuPanel.SetActive(true);
        PauseMenuPanel.SetActive(false); 
        Time.timeScale = 0f;
       
    }

    private void Start()
    {
        StartGame();
       
    }
    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();

        switch(SelectedPlayerIndex)
        {
            case 1: SpawnedPlayer = Instantiate(Player1, PlayerStart.transform.position, PlayerStart.transform.rotation);
            break;

            case 2: SpawnedPlayer = Instantiate(Player2, PlayerStart.transform.position, PlayerStart.transform.rotation);
            break;

            case 3:SpawnedPlayer = Instantiate(Player3, PlayerStart.transform.position, PlayerStart.transform.rotation);
            break;

            case 4:SpawnedPlayer = Instantiate(Player4, PlayerStart.transform.position, PlayerStart.transform.rotation);
            break;

            case 5:SpawnedPlayer = Instantiate(Player5, PlayerStart.transform.position, PlayerStart.transform.rotation);
            break;

            case 6:SpawnedPlayer = Instantiate(Player6, PlayerStart.transform.position, PlayerStart.transform.rotation);
            break;

            default:SpawnedPlayer = Instantiate(DefaultPlayer, PlayerStart.transform.position, PlayerStart.transform.rotation);
            break;
        }

        GameObject player = Instantiate(DefaultPlayer, PlayerStart.transform.position, PlayerStart.transform.rotation);
        FC.StartGame(player.transform);

        Time.timeScale = 1.0f;
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
