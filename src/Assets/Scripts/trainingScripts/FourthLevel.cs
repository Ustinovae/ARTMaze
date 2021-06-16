using UnityEngine;
using UnityEngine.UI;

public class FourthLevel : MonoBehaviour
{
    public Timer Timer;
    public ColorCube ColorCube;
    public Prompts Prompts;
    public Player Player;
    public BuyTip BuyTip;
    public TrainingTips Tips;

    public Text MoneyText;
    public GameObject GameMap;
    public GameObject StartGame;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject ColorButtons;
    public GameObject RedyButton;
    public GameObject SwipeController;
    public GameObject Prompt;

    private bool win = false;
    private bool isTrainig = true;
    private bool GameIsOn;

    public void GameWin()
    {
        Prompts.SetActive(false);
        GameMap.SetActive(false);
        if (StartGame != null)
            StartGame.SetActive(false);
        FinishGame.SetActive(true);
        ContinueButton.SetActive(false);
        var money = PlayerPrefs.GetInt("money");
        PlayerPrefs.SetInt("money", money + 500);
        MoneyText.text = (money + 500).ToString();
        Timer.gameObject.transform.localPosition = new Vector3(0f, 10f, 0f);
    }

    public void ContinueButton_Click()
    {
        if (win)
            GameWin();
        else
        {
            if (Tips.TipsFinished())
            {
                BuyTip.isTraining = false;
                Tips.gameObject.SetActive(false);
                ContinueButton.SetActive(false);
                SwipeController.SetActive(true);
                Timer.Run();
                Player.SetBlockChancgeColor(false);
                GameIsOn = true;
            }

            Tips.ChangeTip();

            if (Tips.GetNumberTip() == 4)
            {
                MoneyText.gameObject.SetActive(true);
                MoneyText.text = PlayerPrefs.GetInt("money").ToString();
                Prompt.SetActive(true);
                ContinueButton.SetActive(false);
            }
        }
    }

    public void PressWhenRedy()
    {
        RedyButton.SetActive(false);
        ColorCube.ReturnToInitState();
        Player.gameObject.SetActive(true);
        ColorButtons.SetActive(true);
        GameIsOn = false;
        Prompts.SetActive(true);

        SwipeController.SetActive(false);
        Tips.ChangeTip();
        ContinueButton.SetActive(true);

        Timer.Init();
    }

    public void GetPrompt()
    {
        if (isTrainig)
        {
            isTrainig = false;
            Tips.ChangeTip();
            BuyTip.gameObject.SetActive(true);
            Timer.Stop();
            SwipeController.SetActive(false);
        }
        if (!Player.InMove() && GameIsOn)
        {
            BuyTip.gameObject.SetActive(true);
            Timer.Stop();
            SwipeController.SetActive(false);
        }
    }

    void Start()
    {
        Player.ChangeColor(ColorCube.CorrectSprite[0]);
        MoneyText.gameObject.SetActive(false);
        ColorButtons.SetActive(false);
        Player.gameObject.SetActive(false);
        ColorCube.PaintInCorrectColors();
        GameIsOn = false;
        Player.SetBlockChancgeColor(true);
    }

    void Update()
    {
        if (Tips.GetNumberTip() == 5 && SwipeController.activeSelf)
        {
            Timer.Stop();
            SwipeController.SetActive(false);
            ContinueButton.SetActive(true);
            Tips.ChangeTip();

        }

        if (ColorCube.CheckWin() && GameIsOn && !Player.InMove())
        {
            win = true;
            ContinueButton.SetActive(true);
            Timer.Stop();
            SwipeController.SetActive(false);
            Player.SetBlockChancgeColor(true);
            GameIsOn = false;
        }

        if (Player.InMove())
            Prompts.ReturnToInitState();
    }
}
