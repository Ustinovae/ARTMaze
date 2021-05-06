using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Player charcter;

    public void ChangeColor()
    {
        if (gameObject.name == "Red")
            charcter.ChangeColor(Color.red);
        if (gameObject.name == "Green")
            charcter.ChangeColor(Color.green);
        if (gameObject.name == "Blue")
            charcter.ChangeColor(Color.blue);

    }
}
