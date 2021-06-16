using System.Collections.Generic;
using UnityEngine;

public class SecondLevel : MonoBehaviour
{
    public ColorCube ColorCube;
    public Player Player;
    public TrainingTips Tips;

    public GameObject colorButtons;
    public GameObject GameMap;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject SwipeController;

    private bool isFirstTime = true;
    private bool win = false;
    private bool finish = false;

    private readonly List<Color> spriteForHighlight = new List<Color>
    {
        new Color(0.4156863f, 1, 1, 0.5f), new Color(0.4156863f, 1, 1, 0.5f), new Color(0f, 1f, 0f, 0.5f),
        new Color(0.4156863f, 1, 1, 0.5f), new Color(0.4156863f, 1, 1, 0.5f), new Color(0f, 1f, 0f, 0.5f),
        new Color(0.4156863f, 1, 1, 0.5f), new Color(0.4156863f, 1, 1, 0.5f), new Color(0f, 1f, 0f, 0.5f)
    };

    public void GameWin()
    {
        GameMap.SetActive(false);
        FinishGame.SetActive(true);
        ContinueButton.SetActive(false);
    }

    public void ContinueButton_Click()
    {
        if (isFirstTime && Player.GetCurrentColor() == new Color(0.4156863f, 1, 1))
        {
            ChangeColorCubes();
            isFirstTime = false;
        }
        Tips.ChangeTip();

        if (win)
        {
            GameMap.SetActive(false);
            ContinueButton.SetActive(false);
            Tips.gameObject.SetActive(false);
            FinishGame.SetActive(true);
            colorButtons.SetActive(false);
            ContinueButton.SetActive(false);
            finish = true;
        }
        if (Tips.GetNumberTip() == 3)
        {
            Player.SetBlockChancgeColor(false);
            SwipeController.SetActive(true);
        }
        if (Tips.GetNumberTip() == 2)
            Player.SetBlockChancgeColor(false);
    }

    void Start()
    {
        Player.ChangeColor(Color.red);
        SwipeController.SetActive(false);
        ContinueButton.SetActive(true);
        Player.SetBlockChancgeColor(true);
    }

    void Update()
    {
        if (((Tips.GetNumberTip() == 2 && Tips.GetCurrentStatus()) ||
            (Tips.GetNumberTip() == 1) ||
            (Tips.GetNumberTip() == 3 && Tips.GetCurrentStatus())) && !finish)
            ContinueButton.SetActive(true);
        else
            ContinueButton.SetActive(false);

        if (isFirstTime && Tips.GetNumberTip() == 2 && Player.GetCurrentColor() == new Color(0.4156863f, 1, 1))
        {
            Tips.CompletTip();
            Player.SetBlockChancgeColor(true);
        }

        if (ColorCube.CheckWin() && !Player.InMove())
        {
            SwipeController.SetActive(false);
            Tips.CompletTip();
            win = true;
            Player.SetBlockChancgeColor(true);
        }
    }

    private void ChangeColorCubes()
    {
        for (var i = 1; i < ColorCube.transform.childCount; i++)
            ColorCube.transform.GetChild(i).GetComponent<SpriteRenderer>().color = spriteForHighlight[i];
    }
}
