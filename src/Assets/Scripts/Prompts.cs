using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompts : MonoBehaviour
{
    public List<Color> HorizontalPrompt;
    public List<Color> VerticalPrompt;

    void Start() =>
        gameObject.SetActive(false);

    public void SetActive(bool flag) =>
        gameObject.SetActive(flag);
    

    public void GetPrompt()
    {
        for (var i = 0; i < transform.GetChild(0).childCount; i++)
        {
            transform.GetChild(0).GetChild(i).GetComponent<Text>().color = HorizontalPrompt[i];
            transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Outline>().effectColor = HorizontalPrompt[i];
        }
        for (var i = 0; i < transform.GetChild(1).childCount; i++)
        {
            transform.GetChild(1).GetChild(i).GetComponent<Text>().color = VerticalPrompt[i];
            transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<Outline>().effectColor = VerticalPrompt[i];
        }
    }

    public void ReturnToInitState()
    {
        for (var i = 0; i < transform.GetChild(0).childCount; i++)
        {
            transform.GetChild(0).GetChild(i).GetComponent<Text>().color = Color.white;
            transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Outline>().effectColor = Color.white;
        }
        for (var i = 0; i < transform.GetChild(1).childCount; i++)
        {
            transform.GetChild(1).GetChild(i).GetComponent<Text>().color = Color.white;
            transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<Outline>().effectColor = Color.white;
        }
    }
}
