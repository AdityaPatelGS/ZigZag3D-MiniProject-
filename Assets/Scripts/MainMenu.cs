using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  public Button PlayGameButton;
  public Button QuitGameButton;

  public Button StoreButton;

    public GameManager gameManager;

    public GameObject PauseMenuPanel;

  private void Start() 
  {
    PlayGameButton.onClick.AddListener(PlayGame);
    QuitGameButton.onClick.AddListener(QuitGame);
  }
    public void PlayGame()
    {
        this.gameObject.SetActive(false);
        gameManager.StartGame();

    }
  private void QuitGame()
  {
    Application.Quit();
  }
  public void Store()
  {
    PauseMenuPanel.SetActive(true);
  }
}