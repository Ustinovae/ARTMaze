using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
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
}
