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
        gameObject.SetActive(false);
        TouchController.SetActive(true);
        Timer.Run();
    }
}
