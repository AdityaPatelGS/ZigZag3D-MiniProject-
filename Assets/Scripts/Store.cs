using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject NotEnoughCoinsObj;
    public Text CrystalsAvailable;

    public Button Player1;
    public Button Player2;
    public Button Player3;
    public Button Player4;
    public Button Player5;
    public Button Player6;  

    // Start is called before the first frame update
    void Start()
    {
        NotEnoughCoinsObj.SetActive(false);
        CrystalsAvailable.text = gameManager.CrystalCount.ToString();

        Player1.onClick.AddListener(SetPlayer1);
        Player2.onClick.AddListener(SetPlayer2);
        Player3.onClick.AddListener(SetPlayer3);
        Player4.onClick.AddListener(SetPlayer4);
        Player5.onClick.AddListener(SetPlayer5);
        Player6.onClick.AddListener(SetPlayer6);

    }
    public void SetPlayer1()
    {
        if(gameManager.CrystalCount>=10)
        {
            gameManager.SelectedPlayerIndex = 1;
            gameManager.CrystalCount-=10;
            CrystalsAvailable.text = gameManager.CrystalCount.ToString();
        }
        else
        {
            NotEnoughCoinsObj.SetActive(true);
            MessageShowTime();
        }
    }
    public void SetPlayer2()
    {
        if(gameManager.CrystalCount>=20)
        {
            gameManager.SelectedPlayerIndex = 2;
            gameManager.CrystalCount-=20;
            CrystalsAvailable.text = gameManager.CrystalCount.ToString();
        }
        else
        {
            NotEnoughCoinsObj.SetActive(true);
            MessageShowTime();
        }

    }
    public void SetPlayer3()
    {
        if(gameManager.CrystalCount>=30)
        {
            gameManager.SelectedPlayerIndex = 3;
            gameManager.CrystalCount-=30;
            CrystalsAvailable.text = gameManager.CrystalCount.ToString();
        }
        else
        {
            NotEnoughCoinsObj.SetActive(true);
            MessageShowTime();
        }
        
    }
    public void SetPlayer4()
    {
        if(gameManager.CrystalCount>=40)
        {
            gameManager.SelectedPlayerIndex = 4;
            gameManager.CrystalCount-=40;
            CrystalsAvailable.text = gameManager.CrystalCount.ToString();
        }
        else
        {
            NotEnoughCoinsObj.SetActive(true);
            MessageShowTime();
        }
        gameManager.SelectedPlayerIndex = 4;
    }
    public void SetPlayer5()
    {
        if(gameManager.CrystalCount>=50)
        {
            gameManager.SelectedPlayerIndex = 5;
            gameManager.CrystalCount-=50;
            CrystalsAvailable.text = gameManager.CrystalCount.ToString();
        }
        else
        {
            NotEnoughCoinsObj.SetActive(true);
            MessageShowTime();
        }

    }
    public void SetPlayer6()
    {
        if(gameManager.CrystalCount>=60)
        {
            gameManager.SelectedPlayerIndex = 6;
            gameManager.CrystalCount-=60;
            CrystalsAvailable.text = gameManager.CrystalCount.ToString();
        }
        else
        {
            NotEnoughCoinsObj.SetActive(true);
            MessageShowTime();
        }
    }


    public IEnumerator MessageShowTime()
    {
        yield return new WaitForSeconds(5f);
        NotEnoughCoinsObj.SetActive(false);
        
    }
}
