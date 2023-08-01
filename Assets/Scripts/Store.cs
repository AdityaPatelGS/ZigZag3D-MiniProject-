using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameManager gameManager;
    public Button MainMenuButton;

    public Button Player1;
    public Button Player2;
    public Button Player3;
    public Button Player4;
    public Button Player5;
    public Button Player6;  

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.onClick.AddListener(GoToMainMenu);

        Player1.onClick.AddListener(SetPlayer1);
        Player2.onClick.AddListener(SetPlayer2);
        Player3.onClick.AddListener(SetPlayer3);
        Player4.onClick.AddListener(SetPlayer4);
        Player5.onClick.AddListener(SetPlayer5);
        Player6.onClick.AddListener(SetPlayer6);

    }

    public void GoToMainMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void SetPlayer1()
    {
        gameManager.SelectedPlayerIndex = 1;
    }
    public void SetPlayer2()
    {
        gameManager.SelectedPlayerIndex = 2;
    }
    public void SetPlayer3()
    {
        gameManager.SelectedPlayerIndex = 3;
    }
    public void SetPlayer4()
    {
        gameManager.SelectedPlayerIndex = 4;
    }
    public void SetPlayer5()
    {
        gameManager.SelectedPlayerIndex = 5;
    }
    public void SetPlayer6()
    {
        gameManager.SelectedPlayerIndex = 6;
    }
}
