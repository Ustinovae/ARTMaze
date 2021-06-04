using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTip : MonoBehaviour
{
    public Text MoneyText;
    public Text MainMoneyText;
    public SwipeController TouchComtroller;
    public Prompts Prompts;
    public Timer Timer;

    private int money;

    // Start is called before the first frame update
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        MoneyText.text = money.ToString();
        PlayerPrefs.SetInt("money", money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        if (money - 100>=0)
        {
            money -= 100;
            PlayerPrefs.SetInt("money", money);
            MoneyText.text = money.ToString();
            Prompts.GetPrompt();
            gameObject.SetActive(false);
            Timer.Run();
            TouchComtroller.gameObject.SetActive(true);
            MainMoneyText.text = money.ToString();
        }
    }

    public void No()
    {
        gameObject.SetActive(false);
        TouchComtroller.gameObject.SetActive(true);
        Timer.Run();
    }
}
