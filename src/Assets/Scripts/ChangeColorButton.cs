using UnityEngine;
using UnityEngine.UI;

public class ChangeColorButton : MonoBehaviour
{
    public Player Player;

    public void ChangeColor()
    {
        if (!Player.InMove())
            Player.ChangeColor(gameObject.GetComponent<Image>().color);
    }
}
