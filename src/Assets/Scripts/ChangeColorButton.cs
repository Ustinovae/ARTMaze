using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorButton : MonoBehaviour
{
    public Player charcter;

    public void ChangeColor()
    {
        charcter.ChangeColor(gameObject.GetComponent<Image>().color);
    }
}
