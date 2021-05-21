using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompts : MonoBehaviour
{
    public List<Color> horizontalPrompt;
    public List<Color> verticalPrompt;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Activate(bool flag)
    {
        gameObject.SetActive(flag);
    }

    public void GetPrompt()
    {
        for (var i = 0; i < transform.GetChild(0).childCount; i++)
            transform.GetChild(0).GetChild(i).GetComponent<Text>().color = horizontalPrompt[i];
        for (var i = 0; i < transform.GetChild(1).childCount; i++)
            transform.GetChild(1).GetChild(i).GetComponent<Text>().color = verticalPrompt[i];
    }

    public void ReturnToInitState()
    {
        for (var i = 0; i < transform.GetChild(0).childCount; i++)
            transform.GetChild(0).GetChild(i).GetComponent<Text>().color = Color.white;
        for (var i = 0; i < transform.GetChild(1).childCount; i++)
            transform.GetChild(1).GetChild(i).GetComponent<Text>().color = Color.white;
    }
}
