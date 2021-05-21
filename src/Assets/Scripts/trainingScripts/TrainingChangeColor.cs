using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingChangeColor : MonoBehaviour
{
    public TrainingPlayer trainingPlayer;
    public GameObject ColorCube;
    public bool isLevel2;

    private List<Color> highlightColor = new List<Color>()
    {
        new Color(1, 0, 0, 0.4f), new Color(0, 1, 0, 0.4f), new Color(0, 0, 1, 0.4f),
        new Color(1, 0, 0, 0.4f), new Color(0, 1, 0, 0.4f), new Color(0, 0, 1, 0.4f),
        new Color(1, 0, 0, 0.4f), new Color(0, 1, 0, 0.4f), new Color(0, 0, 1, 0.4f)
    };

    public void ChangeColor()
    {
        if (gameObject.name == "Red")
            trainingPlayer.ChangeColor(Color.red);
        if (gameObject.name == "Green")
            trainingPlayer.ChangeColor(Color.green);
        if (gameObject.name == "Blue")
        {
            if (isLevel2)
            {
                for(var i = 0; i<ColorCube.transform.childCount; i++)
                {
                    ColorCube.transform.GetChild(i).GetComponent<SpriteRenderer>().color = highlightColor[i];
                }
                isLevel2 = false;
            }
            trainingPlayer.ChangeColor(Color.blue);
        }
    }
}
