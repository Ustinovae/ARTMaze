using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingColorCube : MonoBehaviour
{
    public List<Color> correctSprite;
    public GameObject gameMap;
    public GameObject startGame;
    public GameObject finishGame;
    public GameObject continueButton;
    public GameObject trainingTexts;
    private int indexChild = 1;


    public void GameWin()
    {
        continueButton.SetActive(false);
        gameMap.SetActive(false);
        if (startGame != null)
            startGame.SetActive(false);
        finishGame.SetActive(true);
    }

    public void ActivateContinueButton()
    {
        continueButton.SetActive(true);
    }

    public void ContinueHandler()
    {
        if (indexChild < trainingTexts.transform.childCount)
        {
            trainingTexts.transform.GetChild(indexChild - 1).gameObject.SetActive(false);
            trainingTexts.transform.GetChild(indexChild).gameObject.SetActive(true);
            indexChild += 1;
        }
        else if (CheckWin())
        {
            trainingTexts.transform.GetChild(indexChild - 1).gameObject.SetActive(false);
            GameWin();
        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (CheckWin())
        {
            continueButton.SetActive(true);
        }
    }

    private bool CheckWin()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var s = transform.GetChild(i).GetComponent<SpriteRenderer>();
            if (s.color != correctSprite[i])
                return false;
        }
        return true;
    }
}
