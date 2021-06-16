using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Timer Timer;
    public ColorCube ColorCube;
    public Prompts Prompts;
    public Player Player;
    public BuyTip BuyTip;

    public Text MoneyText;
    public GameObject GameMap;
    public GameObject StartGame;
    public GameObject FinishGame;
    public GameObject ContinueButton;
    public GameObject ColorButtons;
    public GameObject RedyButton;
    public GameObject TouchController;
    public GameObject Prompt;

    private bool gameIsOn;

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
        Timer.gameObject.transform.localPosition = new Vector3(0f, 10f, 0f);
    }

    public void PressWhenRedy()
    {
        RedyButton.SetActive(false);
        ColorCube.ReturnToInitState();
        Player.gameObject.SetActive(true);
        ColorButtons.SetActive(true);
        gameIsOn = true;
        Prompts.SetActive(true);
        MoneyText.gameObject.SetActive(true);
        MoneyText.text = PlayerPrefs.GetInt("money").ToString();
        Prompt.SetActive(true);

        Timer.Init();
        Timer.Run();
    }

    public void GetPrompt()
    {
        if (!Player.InMove() && gameIsOn)
        {
            BuyTip.gameObject.SetActive(true);
            Timer.Stop();
            TouchController.SetActive(false);
        }
    }

    void Start()
    {
        Player.ChangeColor(ColorCube.CorrectSprite[0]);
        MoneyText.gameObject.SetActive(false);
        ColorButtons.SetActive(false);
        Player.gameObject.SetActive(false);
        ColorCube.PaintInCorrectColors();
        gameIsOn = false;
    }

    void Update()
    {
        if (ColorCube.CheckWin() && gameIsOn && !Player.InMove())
        {
            Player.SetBlockChancgeColor(true);
            ContinueButton.SetActive(true);
            Timer.Stop();
            TouchController.SetActive(false);
            gameIsOn = false;
        }
        if (Player.InMove())
            Prompts.ReturnToInitState();
    }
}
