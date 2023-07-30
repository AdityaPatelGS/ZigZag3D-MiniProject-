using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  public Button PlayGameButton;
  public Button QuitGameButton;

  public Button StoreButton;

  private void Start() 
  {
      PlayGameButton.onClick.AddListener(PlayGame);
      QuitGameButton.onClick.AddListener(QuitGame);
      StoreButton.onClick.AddListener(GoToStore);
  }
  public void PlayGame()
    {
        SceneManager.LoadScene("Main");
        
    }
    public void QuitGame()
    {
      Application.Quit();
    }

    public void GoToStore()
    {
      SceneManager.LoadScene("Store");
    }
}