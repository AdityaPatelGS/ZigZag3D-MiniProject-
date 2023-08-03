using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameManager gameManager;
    public Text NotEnoughCoinsObj;
    public Text CrystalsAvailable;

    public Button Player1;
    public Button Player2;
    public Button Player3;
    public Button Player4;

    void Start()
    {
        CrystalsAvailable.text = gameManager.score.ToString();
        NotEnoughCoinsObj.gameObject.SetActive(false);
        //CrystalsAvailable.text = gameManager.score.ToString();

        Player1.onClick.AddListener(SetPlayer1);
        Player2.onClick.AddListener(SetPlayer2);
        Player3.onClick.AddListener(SetPlayer3);
        Player4.onClick.AddListener(SetPlayer4);


    }
    public void SetPlayer1()
    {
        Debug.Log("Clicked Select Player 1");
        if(gameManager.score>=10)
        {
            Debug.Log("Clicked Select Player 1 inside f");
            gameManager.SelectedPlayerIndex = 1;
            gameManager.score-=10;
            CrystalsAvailable.text = gameManager.score.ToString();
        }
        else
        {
            NotEnoughCoinsObj.gameObject.SetActive(true);
            StartCoroutine(MessageShowTime());
        }
    }
    public void SetPlayer2()
    {
        if(gameManager.score>=20)
        {
            gameManager.SelectedPlayerIndex = 2;
            gameManager.score-=20;
            CrystalsAvailable.text = gameManager.score.ToString();
        }
        else
        {
            NotEnoughCoinsObj.gameObject.SetActive(true);
            StartCoroutine(MessageShowTime());
        }

    }
    public void SetPlayer3()
    {
        if(gameManager.score>=30)
        {
            gameManager.SelectedPlayerIndex = 3;
            gameManager.score-=30;
            CrystalsAvailable.text = gameManager.score.ToString();
        }
        else
        {
            NotEnoughCoinsObj.gameObject.SetActive(true);
            StartCoroutine(MessageShowTime());
        }
        
    }
    public void SetPlayer4()
    {
        if(gameManager.score>=40)
        {
            gameManager.SelectedPlayerIndex = 4;
            gameManager.score-=40;
            CrystalsAvailable.text = gameManager.score.ToString();
        }
        else
        {
            NotEnoughCoinsObj.gameObject.SetActive(true);
            StartCoroutine(MessageShowTime());
        }
    }

    public IEnumerator MessageShowTime()
    {
        yield return new WaitForSecondsRealtime(1f);

        NotEnoughCoinsObj.gameObject.SetActive(false);
        
    }
}
