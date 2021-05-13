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
    private int indexChild = 1;
    private bool isStart = false;
    private List<Color> correctCrossword = new List<Color>
    {
        Color.blue, Color.red, Color.red,Color.red,
        Color.blue, Color.blue,Color.blue,Color.blue,Color.blue,
        Color.red, Color.red,Color.red,Color.red, Color.red
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
    }

    public void GetPrompt()
    {
        if(!player.moved)
            for (var i = 0; i < crossword.transform.childCount; i++)
                crossword.transform.GetChild(i).GetComponent<Text>().color = correctCrossword[i];
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
        if (!redyButton.activeInHierarchy && !finishGame.activeInHierarchy && !continueButton.activeInHierarchy)
        {
            timerCount += Time.deltaTime;
            timer.text = Math.Truncate(timerCount).ToString();
        }
        
        if (CheckWin() && isStart)
        {
            continueButton.SetActive(true);
        }
        if (player.moved)
            for (var i = 0; i < crossword.transform.childCount; i++)
                crossword.transform.GetChild(i).GetComponent<Text>().color = Color.white; 
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
