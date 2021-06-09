using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingChangeColor : MonoBehaviour
{
    public TrainingPlayer trainingPlayer;

    public void ChangeColor()
    {
        if(!trainingPlayer.InMove())
            trainingPlayer.ChangeColor(gameObject.GetComponent<Image>().color);
    }
}
