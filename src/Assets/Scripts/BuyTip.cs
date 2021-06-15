using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTip : MonoBehaviour
{
    public Text MoneyText;
    public Text MainMoneyText;
    public GameObject TouchController;
    public Prompts Prompts;
    public Timer Timer;
    public int Price;
    public bool isTraining;

    private int money;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        MoneyText.text = money.ToString();
        PlayerPrefs.SetInt("money", money);
    }

    public void Yes()
    {
        if (money - Price>=0)
        {
            money -= Price;
            PlayerPrefs.SetInt("money", money);
            MoneyText.text = money.ToString();
            Prompts.GetPrompt();
            gameObject.SetActive(false);
            Timer.Run();
            TouchController.SetActive(true);
            MainMoneyText.text = money.ToString();
        }
    }

    public void No()
    {
        if (isTraining)
            return;
        gameObject.SetActive(false);
        TouchController.SetActive(true);
        Timer.Run();
    }
}
