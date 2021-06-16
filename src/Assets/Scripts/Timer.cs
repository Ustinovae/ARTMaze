using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer;
    private bool timerRun;

    void Start()
    {
        timerRun = false;
        timer = 0f;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (timerRun)
        {
            timer += Time.deltaTime;
            gameObject.GetComponent<Text>().text = TimeSpan.FromSeconds(timer).ToString("mm':'ss");
        }
    }

    public void Init()
    {
        transform.GetComponent<Text>().text = "00:00";
        gameObject.SetActive(true);
    }

    public void Stop() =>
        timerRun = false;


    public void Run() =>
        timerRun = true;


    public void IncreaseTimer(float deltaTime) =>
        timer += deltaTime;
}
