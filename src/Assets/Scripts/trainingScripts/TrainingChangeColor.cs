using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingChangeColor : MonoBehaviour
{
    public TrainingPlayer trainingPlayer;
    public GameObject ColorCube;


    public void ChangeColor()
    {
        if (gameObject.name == "Red")
            trainingPlayer.ChangeColor(Color.red);
        if (gameObject.name == "Green")
            trainingPlayer.ChangeColor(Color.green);
        if (gameObject.name == "Blue")
        {
            trainingPlayer.ChangeColor(Color.blue);
        }
    }
}
