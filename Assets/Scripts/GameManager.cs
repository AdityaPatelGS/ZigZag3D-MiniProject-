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

    public int CrystalCount;
    public FollowCam FC;

    public GameObject MainMenuPanel;
    //public GameObject PauseMenuPanel;

    public GameObject StorePanel;


    public Button StartGameButton;
    public Button QuitGameButton;
    //public Button PauseButton;
    public Button StoreButton;
    public Button MainMenuButton;
    public Button ResumeButton;

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
        SelectedPlayerIndex=0;
        if(PlayerPrefs.HasKey("CrystalCount"))
        {
            CrystalCount = PlayerPrefs.GetInt("CrystalCount");
        }
        else
        {
            CrystalCount = 0;
        }        

        highScoreText.text = "best : " + getHighScore().ToString();
        Application.targetFrameRate = 144;
        MainMenuPanel.SetActive(true);
        StorePanel.SetActive(false);
        //PauseMenuPanel.SetActive(false); 
        Time.timeScale = 0f;
       
    }

    private void Start()
    {
        StartGameButton.onClick.AddListener(StartGame);
        QuitGameButton.onClick.AddListener(QuitGame);

        StoreButton.onClick.AddListener(GoToStore);
        MainMenuButton.onClick.AddListener(GoToMainMenu);
        //PauseButton.onClick.AddListener(PauseGame);
        //ResumeButton.onClick.AddListener(ResumeGame);

        //StartGame();       
    }
    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
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

        //GameObject player = Instantiate(DefaultPlayer, PlayerStart.transform.position, PlayerStart.transform.rotation);
        FC.StartGame(SpawnedPlayer.transform);

        Time.timeScale = 1.0f;
    }   

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
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

    public void GoToStore()
    {
        Debug.Log("Store Button Clicked");
        MainMenuPanel.SetActive(false);
        StorePanel.SetActive(true);
    }
    public void GoToMainMenu()
    {
        StorePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        //PauseMenuPanel.SetActive(true);

    }

    public void ResumeGame()
    {
        //PauseMenuPanel.SetActive(false);
        Time.timeScale=1f;
    }
}
