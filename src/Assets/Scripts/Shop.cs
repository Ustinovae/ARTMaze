using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text Money;
    private int money;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        Money.text = "Money:" + money.ToString();
        PlayerPrefs.SetInt("money", money);
    }

    void Update()
    {

    }

    public void Buy()
    {
        if (money - 20 >= 0)
        {
            money -= 20;
            PlayerPrefs.SetInt("money", money);
            Money.text = "Money:" + money.ToString();
        }
    }
}
