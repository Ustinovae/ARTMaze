using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    private bool GameIsOn;

    public Timer Timer;
    public ColorCube ColorCube; // переименовать, что-то типа клетки лабиринта или т.п.
    public Prompts Prompts;
    public Player player;
    public BuyTip BuyTip;

    public Text MoneyText;
    public GameObject GameMap;
    public GameObject StartGame;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject ColorButtons;
    public GameObject RedyButton;
    public GameObject TouchController;
    public GameObject Prompt;


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
        Timer.gameObject.transform.localPosition = new Vector3(0f, 10f, 0f);
    }

    public void PressWhenRedy()
    {
        RedyButton.SetActive(false);
        ColorCube.ReturnToInitState();
        player.gameObject.SetActive(true);
        ColorButtons.SetActive(true);
        GameIsOn = true;
        Prompts.Activate(true);
        MoneyText.gameObject.SetActive(true);
        MoneyText.text = PlayerPrefs.GetInt("money").ToString();
        Prompt.SetActive(true); 

        Timer.Init();
        Timer.Run();

    }

    public void GetPrompt()
    {
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
    }

    void Update()
    {
        if (ColorCube.CheckWin() && GameIsOn && !player.InMove())
        {
            ContinueButton.SetActive(true);
            Timer.Stop();
            TouchController.SetActive(false);
            GameIsOn = false;
        }
        if (player.InMove())
        {
            Prompts.ReturnToInitState();
        }
    }
}
