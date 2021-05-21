using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorCube : MonoBehaviour
{
    public List<Color> correctSprite;
    public GameObject gameMap;
    public GameObject startGame;
    public GameObject finishGame;
    public GameObject continueButton;
    public GameObject colorButtons;
    public GameObject character;
    public Player player;
    public Text timer;
    private float timerCount = 0f;
    public GameObject redyButton;
    public GameObject crossword;
    public GameObject TouchController;
    private bool isStart = false;
    private bool TimerRun = false;

    private List<Color> horizontalPrompt = new List<Color>
    {
         Color.red, Color.red,Color.red,Color.red, Color.red,
        Color.blue, Color.blue,Color.blue,Color.blue,Color.blue
    };
    private List<Color> verticalPrompt = new List<Color>
    {
        Color.red, Color.red,Color.red, Color.blue
    };


    public void GameWin()
    {
        crossword.SetActive(false);
        continueButton.SetActive(false);
        gameMap.SetActive(false);
        if (startGame != null)
            startGame.SetActive(false);
        finishGame.SetActive(true);
    }

    public void PressWhenRedy()
    {
        redyButton.SetActive(false);
        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(0.754717f, 0.4236383f, 0.7085454f);
        }
        character.SetActive(true);
        colorButtons.SetActive(true);
        isStart = true;
        crossword.SetActive(true);
        crossword.SetActive(true);
        timer.text = "00:00.00";
        TimerRun = true;

    }

    public void GetPrompt()
    {
        if (!player.moved)
        {
            for (var i = 0; i < crossword.transform.GetChild(0).childCount; i++)
                crossword.transform.GetChild(0).GetChild(i).GetComponent<Text>().color = horizontalPrompt[i];
            for (var i = 0; i < crossword.transform.GetChild(1).childCount; i++)
                crossword.transform.GetChild(1).GetChild(i).GetComponent<Text>().color = verticalPrompt[i];
            timerCount += 10;
        }
    }

    public void ActivateContinueButton()
    {
        continueButton.SetActive(true);
    }

    void Start()
    {
        crossword.SetActive(false);
        colorButtons.SetActive(false);
        character.SetActive(false);
        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = correctSprite[i];                
        }
    }

    void Update()
    {
        if (TimerRun)
        {
            timerCount += Time.deltaTime;
            timer.text = TimeSpan.FromSeconds(timerCount).ToString("mm':'ss','ff" );
        }
        
        if (CheckWin() && isStart)
        {
            continueButton.SetActive(true);
            TimerRun = false;
            TouchController.SetActive(false);
        }
        if (player.moved)
        {
            for (var i = 0; i < crossword.transform.GetChild(0).childCount; i++)
                crossword.transform.GetChild(0).GetChild(i).GetComponent<Text>().color = Color.white;
            for (var i = 0; i < crossword.transform.GetChild(1).childCount; i++)
                crossword.transform.GetChild(1).GetChild(i).GetComponent<Text>().color = Color.white;
        }
            
    }

    private bool CheckWin()
    {
        for(var i = 0; i< transform.childCount; i++)
        {
            var s = transform.GetChild(i).GetComponent<SpriteRenderer>();
            if (s.color != correctSprite[i])
                return false;
        }
        return true;
    }
}
