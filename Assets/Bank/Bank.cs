using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance =150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI _bankScore;


    public int CurrentBalance { get { return currentBalance; } }

    

    private void Awake()
    {
        currentBalance = startingBalance;
        BankScoreUI();


    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        BankScoreUI();


    }

    public void WithDraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        BankScoreUI();


        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void BankScoreUI()
    {
     _bankScore.text = " Coin:" + currentBalance;

    }
}
