using System.Collections.Generic;
using UnityEngine;

public class ThirdLevel : MonoBehaviour
{
    public ColorCube ColorCube;
    public Player Player;
    public TrainingTips Tips;
    public Prompts Prompts;

    public GameObject GameMap;
    public GameObject StartGame;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject ColorButtons;
    public GameObject RedyButton;
    public GameObject SwipeController;

    private bool GameIsOn;

    private readonly List<Color> spriteForHighlight = new List<Color>
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
        if (Tips.GetNumberTip() == 2)
        {
            SwipeController.SetActive(true);
            Player.SetBlockChancgeColor(false);
            Tips.ChangeTip();
            ContinueButton.SetActive(false);
            return;
        }

        GameMap.SetActive(false);
        if (StartGame != null)
            StartGame.SetActive(false);
        FinishGame.SetActive(true);
        ContinueButton.SetActive(false);
        Prompts.gameObject.SetActive(false);
        Tips.gameObject.SetActive(false);
    }

    public void PressWhenRedy()
    {
        SwipeController.SetActive(false);
        Player.SetBlockChancgeColor(true);
        ContinueButton.SetActive(true);
        Player.gameObject.SetActive(true);
        RedyButton.SetActive(false);
        ColorButtons.SetActive(true);
        GameIsOn = true;
        Tips.ChangeTip();
        ChangeColorCubes();
        Prompts.gameObject.SetActive(true);
        Player.ChangeColor(Color.green);
    }

    void Start()
    {
        Player.ChangeColor(ColorCube.CorrectSprite[0]);
        ColorButtons.SetActive(false);
        Player.gameObject.SetActive(false);
        ColorCube.PaintInCorrectColors();
        GameIsOn = false;
    }

    void Update()
    {
        if (ColorCube.CheckWin() && GameIsOn && !Player.InMove())
        {
            ContinueButton.SetActive(true);
            SwipeController.SetActive(false);
            GameIsOn = false;
            Player.SetBlockChancgeColor(true);
            Tips.CompletTip();
        }
    }

    private void ChangeColorCubes()
    {
        for (var i = 1; i < ColorCube.transform.childCount; i++)
            ColorCube.transform.GetChild(i).GetComponent<SpriteRenderer>().color = spriteForHighlight[i];
    }
}
