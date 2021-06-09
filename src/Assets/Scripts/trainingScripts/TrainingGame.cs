using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TrainingGame : MonoBehaviour
{
    private bool GameIsOn;

    public Timer Timer;
    public ColorCube ColorCube; // переименовать, что-то типа клетки лабиринта или т.п.
    public Prompts Prompts;
    public TrainingPlayer player;
    public BuyTip BuyTip;
    public TrainingTips Tips;

    public Text MoneyText;
    public GameObject GameMap;
    public GameObject StartGame;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject ColorButtons;
    public GameObject RedyButton;
    public GameObject TouchController;
    public GameObject Prompt;

    private bool win = false;
    private bool isTrainig = true;


    public void GameWin()
    {
        Prompts.Activate(false);
        GameMap.SetActive(false);
        if (StartGame != null)
            StartGame.SetActive(false);
        FinishGame.SetActive(true);
        ContinueButton.SetActive(false);
        var money = PlayerPrefs.GetInt("money");
        PlayerPrefs.SetInt("money", money + 500);
        MoneyText.text = (money + 500).ToString();

    }

    public void ContinueButton_Click()
    {
        if (win)
            GameWin();
        else
        {
            if (Tips.TipsFinished())
            {
                BuyTip.isTraining = false;
                Tips.gameObject.SetActive(false);
                ContinueButton.SetActive(false);
                TouchController.SetActive(true);
                Timer.Run();
                player.SetBlockChancgeColor(false);
                GameIsOn = true;
            }

            Tips.ChangeTip();

            if (Tips.GetNumberTip() == 4)
            {
                MoneyText.gameObject.SetActive(true);
                MoneyText.text = PlayerPrefs.GetInt("money").ToString();
                Prompt.SetActive(true);
                ContinueButton.SetActive(false);
            }
        }
    }

    public void PressWhenRedy()
    {
        RedyButton.SetActive(false);
        ColorCube.ReturnToInitState();
        player.gameObject.SetActive(true);
        ColorButtons.SetActive(true);
        GameIsOn = false;
        Prompts.Activate(true);
        
        TouchController.SetActive(false);
        Tips.ChangeTip();
        ActivateContinueButton();

        Timer.Init();
    }

    public void GetPrompt()
    {
        if (isTrainig)
        {
            isTrainig = false;
            Tips.ChangeTip();
            BuyTip.gameObject.SetActive(true);
            Timer.Stop();
            TouchController.SetActive(false);
        }
        if (!player.InMove() && GameIsOn)
        {
            BuyTip.gameObject.SetActive(true);
            Timer.Stop();
            TouchController.SetActive(false);
        }
    }

    public void ActivateContinueButton()
    {
        ContinueButton.SetActive(true);
    }

    void Start()
    {
        MoneyText.gameObject.SetActive(false);
        ColorButtons.SetActive(false);
        player.gameObject.SetActive(false);
        ColorCube.PaintInCorrectColors();
        GameIsOn = false;
        player.SetBlockChancgeColor(true);
    }

    void Update()
    {
        if(Tips.GetNumberTip() == 5 && TouchController.activeSelf)
        {
            Timer.Stop();
            TouchController.SetActive(false);
            ContinueButton.SetActive(true);
            Tips.ChangeTip();
            
        }

        if (ColorCube.CheckWin() && GameIsOn && !player.InMove())
        {
            win = true;
            ContinueButton.SetActive(true);
            Timer.Stop();
            TouchController.SetActive(false);
            GameIsOn = false;
        }

        //if (!GameIsOn)
        //    Timer.Stop();

        if (player.InMove())
        {
            Prompts.ReturnToInitState();
        }
    }
}
