using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text ScoreText;

    public Transform PlayerStart;

    public int SelectedPlayerIndex;

    public FollowCam FC;

    public GameObject MainMenuPanel;


    public GameObject StorePanel;


    public Button StartGameButton;
    public Button QuitGameButton;
    public Button StoreButton;
    public Button MainMenuButton;



    public Button JumpButton;

    public GameObject DefaultPlayer;
    public GameObject SelectedPlayer;
    public GameObject SpawnedPlayer;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;


    private void Awake()
    {
        SelectedPlayerIndex=0;
        if(PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        else
        {
            score = 0;
        }        

        Application.targetFrameRate = 144;
        MainMenuPanel.SetActive(true);
        StorePanel.SetActive(false);
        Time.timeScale = 0f;

        Player1.SetActive(false);   
        Player2.SetActive(false);   
        Player3.SetActive(false);
        Player4.SetActive(false);
       
    }

    private void Start()
    {
        StartGameButton.onClick.AddListener(StartGame);
        QuitGameButton.onClick.AddListener(QuitGame);

        StoreButton.onClick.AddListener(GoToStore);
        MainMenuButton.onClick.AddListener(GoToMainMenu);


        //StartGame();       
    }
    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();

        switch(SelectedPlayerIndex)
        {

            case 1:SpawnedPlayer = Player1;
                Player1.SetActive(true);
            break;

            case 2:SpawnedPlayer = Player2;
                Player2.SetActive(true); 
            break;


            case 3:
                SpawnedPlayer = Player3;
                Player3.SetActive(true);
            break;

            case 4:SpawnedPlayer = Player4;
                Player4.SetActive(true);
            break;



            default:
                SpawnedPlayer = DefaultPlayer;
                DefaultPlayer.SetActive(true);
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
        PlayerPrefs.SetInt("score", score);
    }

    public void IncreaseScore()
    {
        score++;
        PlayerPrefs.Save();
        ScoreText.text = score.ToString();
    }



    public void GoToStore()
    {
        MainMenuPanel.SetActive(false);
        StorePanel.SetActive(true);
    }
    public void GoToMainMenu()
    {
        StorePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }


}
