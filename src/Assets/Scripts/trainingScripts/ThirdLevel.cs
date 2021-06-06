using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLevel : MonoBehaviour
{
    private bool GameIsOn;

    public ColorCube ColorCube; // переименовать, что-то типа клетки лабиритнат или т.п.
    public TrainingPlayer player;
    public TrainingTips Tips;
    public Prompts prompts;

    public GameObject GameMap;
    public GameObject StartGame;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject ColorButtons;
    public GameObject RedyButton;
    public GameObject TouchController;

    private List<Color> correctSprite = new List<Color>
    {
        new Color(1f, 0.03137255f, 0.03137255f, 0.5f), new Color(1f, 0.03137255f, 0.03137255f, 0.5f), new Color(0.4156863f, 1f, 1f, 0.5f), new Color(0.4156863f, 1f, 1f, 0.5f),
        new Color(1f, 0.03137255f, 0.03137255f, 0.5f), new Color(1f, 0.03137255f, 0.03137255f, 0.5f), new Color(0.4156863f, 1f, 1f, 0.5f), new Color(0.4156863f, 1f, 1f, 0.5f), 
        new Color(0.0627451f, 0.8862745f, 0.09411765f, 0.5f), new Color(0.0627451f, 0.8862745f, 0.09411765f, 0.5f), new Color(0.0627451f, 0.8862745f, 0.09411765f, 0.5f), new Color(0.0627451f, 0.8862745f, 0.09411765f, 0.5f),
        new Color(0.0627451f, 0.8862745f, 0.09411765f, 0.5f), new Color(0.0627451f, 0.8862745f, 0.09411765f, 0.5f), new Color(0.0627451f, 0.8862745f, 0.09411765f, 0.5f), new Color(0.0627451f, 0.8862745f, 0.09411765f, 0.5f)
    };

    public void GameWin()
    {
        GameMap.SetActive(false);
        if (StartGame != null)
            StartGame.SetActive(false);
        FinishGame.SetActive(true);
        ContinueButton.SetActive(false);
    }

    public void ContinueButton_Click()
    {
        GameMap.SetActive(false);
        if (StartGame != null)
            StartGame.SetActive(false);
        FinishGame.SetActive(true);
        ContinueButton.SetActive(false);
        prompts.gameObject.SetActive(false);
        Tips.gameObject.SetActive(false);
    }

    public void PressWhenRedy()
    {
        player.gameObject.SetActive(true);
        RedyButton.SetActive(false);
        ColorButtons.SetActive(true);
        GameIsOn = true;
        Tips.ChangeTip();
        ChangeColorCubes();
        prompts.gameObject.SetActive(true);
        player.ChangeColor(Color.green);
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
            TouchController.SetActive(false);
            GameIsOn = false;
            Tips.CompletTip();
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
