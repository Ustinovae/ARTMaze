using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel : MonoBehaviour
{
    public TrainingColorCube ColorCube; // �������������, ���-�� ���� ������ ���������� ��� �.�.
    public TrainingPlayer player;
    public TrainingTips Tips;

    public GameObject GameMap;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject TouchController;

    private bool isFirstTime = true;

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
        Tips.ChangeTip();
        if (Tips.GetNumberTip() == 3)
            player.SetBlock(false);

        if (Tips.TipsFinished() && ColorCube.CheckWin() && !player.InMove())
        {
            GameMap.SetActive(false);
            ContinueButton.SetActive(false);
            Tips.gameObject.SetActive(false);
            FinishGame.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isFirstTime && ColorCube.transform.GetChild(6).GetComponent<SpriteRenderer>().color == Color.red)
        {
            Tips.CompletTip();
            ActivateContinueButton();
            isFirstTime = false;
            player.SetBlock(true);
        }

        if (ColorCube.CheckWin() && !player.InMove())
        {
            TouchController.SetActive(false);
            Tips.CompletTip();
        }
    }
}
