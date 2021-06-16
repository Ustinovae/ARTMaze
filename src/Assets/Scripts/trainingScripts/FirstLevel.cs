using UnityEngine;

public class FirstLevel : MonoBehaviour
{
    public ColorCube ColorCube;
    public Player Player;
    public TrainingTips Tips;

    public GameObject GameMap;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject SwipeController;

    private bool isFirstTime = true;

    public void GameWin()
    {
        GameMap.SetActive(false);
        FinishGame.SetActive(true);
        ContinueButton.SetActive(false);
    }

    public void ContinueButton_Click()
    {
        Tips.ChangeTip();

        if (Tips.GetNumberTip() == 3 && !Tips.GetCurrentStatus())
        {
            ContinueButton.SetActive(false);
            SwipeController.SetActive(true); ;
        }

        if (Tips.TipsFinished() && ColorCube.CheckWin() && !Player.InMove())
        {
            GameMap.SetActive(false);
            ContinueButton.SetActive(false);
            Tips.gameObject.SetActive(false);
            FinishGame.SetActive(true);
        }
    }

    private void Start()
    {
        Player.ChangeColor(ColorCube.CorrectSprite[0]);
    }

    void Update()
    {
        if (isFirstTime && ColorCube.transform.GetChild(6).GetComponent<SpriteRenderer>().color == new Color(1f, 0.03137255f, 0.03137255f))
        {
            Tips.CompletTip();
            ContinueButton.SetActive(true);
            isFirstTime = false;
            SwipeController.SetActive(false);
        }

        if (ColorCube.CheckWin() && !Player.InMove())
        {
            if (!Tips.GetCurrentStatus())
                ContinueButton.SetActive(true);
            SwipeController.SetActive(false);
            Tips.CompletTip();
        }
    }
}
