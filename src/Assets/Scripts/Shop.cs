using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text Money;

    private int money;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        Money.text = money.ToString();
        PlayerPrefs.SetInt("money", money);
    }

    public void Buy()
    {
        if (money - 20 >= 0)
        {
            money -= 20;
            PlayerPrefs.SetInt("money", money);
            Money.text = money.ToString();
        }
    }
}
