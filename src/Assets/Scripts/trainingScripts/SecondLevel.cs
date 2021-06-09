using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevel : MonoBehaviour
{
    public TrainingColorCube ColorCube; // переименовать, что-то типа клетки лабиритнат или т.п.
    public TrainingPlayer player;
    public TrainingTips Tips;

    public GameObject colorButtons;
    public GameObject GameMap;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject TouchController;

    private bool isFirstTime = true;
    private bool win = false;
    private bool finish = false;

    private List<Color> correctSprite = new List<Color>
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

    public void ActivateContinueButton()
    {
        ContinueButton.SetActive(true);
    }

    public void ContinueButton_Click()
    {
        if (isFirstTime && player.GetCurrentColor() == new Color(0.4156863f, 1, 1)) 
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
            player.SetBlockChancgeColor(false);
            player.SetBlock(false);
        }
        if (Tips.GetNumberTip() == 2)
            player.SetBlockChancgeColor(false);

    }

    void Start()
    {
        player.SetBlock(true);
        ActivateContinueButton();
        player.SetBlockChancgeColor(true);
    }

    void Update()
    {
        if (((Tips.GetNumberTip() == 2 && Tips.GetCurrentStatus()) ||
            (Tips.GetNumberTip() == 1) ||
            (Tips.GetNumberTip() == 3 && Tips.GetCurrentStatus())) && !finish)
            ContinueButton.SetActive(true);
        else
            ContinueButton.SetActive(false);

        if (isFirstTime && Tips.GetNumberTip() == 2 && player.GetCurrentColor() == new Color(0.4156863f, 1, 1))
        {
            Tips.CompletTip();
            player.SetBlockChancgeColor(true);
            //player.SetBlock(true);
        }

        if (ColorCube.CheckWin() && !player.InMove())
        {
            TouchController.SetActive(false);
            Tips.CompletTip();
            win = true;
        }
    }

    private void ChangeColorCubes()
    {
        for (var i = 1; i < ColorCube.transform.childCount; i++)
        {
            ColorCube.transform.GetChild(i).GetComponent<SpriteRenderer>().color = correctSprite[i];
        }

    }
}
