using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    private bool GameIsOn;

    public Timer Timer;
    public ColorCube ColorCube; // �������������, ���-�� ���� ������ ���������� ��� �.�.
    public Prompts Prompts;
    public Player player;

    public GameObject GameMap;
    public GameObject StartGame;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject ColorButtons;
    public GameObject RedyButton;
    public GameObject TouchController;


    public void GameWin()
    {
        Prompts.Activate(false);
        GameMap.SetActive(false);
        if (StartGame != null)
            StartGame.SetActive(false);
        FinishGame.SetActive(true);
        ContinueButton.SetActive(false);
        GameIsOn = false;

    }

    public void PressWhenRedy()
    {
        RedyButton.SetActive(false);
        ColorCube.ReturnToInitState();
        player.gameObject.SetActive(true);
        ColorButtons.SetActive(true);
        GameIsOn = true;
        Prompts.Activate(true);
        Timer.Init();
        Timer.Run();
    }

    public void GetPrompt()
    {
        if (!player.InMove() && GameIsOn)
        {
            Prompts.GetPrompt();
            Timer.IncreaseTimer(10);
        }
    }

    public void ActivateContinueButton()
    {
        ContinueButton.SetActive(true);
    }

    void Start()
    {
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
        }
        if (player.InMove())
        {
            Prompts.ReturnToInitState();
        }
    }
}