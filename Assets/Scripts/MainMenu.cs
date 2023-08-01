using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  public Button PlayGameButton;
  public Button QuitGameButton;

  private void Start() 
  {
      PlayGameButton.onClick.AddListener(PlayGame);
      QuitGameButton.onClick.AddListener(QuitGame);
  }
  public void PlayGame()
    {
        SceneManager.LoadScene("Main");
        
    }
    private void QuitGame()
    {
      Application.Quit();
    }
}