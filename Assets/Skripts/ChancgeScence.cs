using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChancgeScence : MonoBehaviour
{
    public void NextScence(int scenceNumber)
    {
        SceneManager.LoadScene(scenceNumber);
    }
}
