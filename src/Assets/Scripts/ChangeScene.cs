using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SwitchScene(int scenceNumber)
    {
        SceneManager.LoadScene(scenceNumber);
    }
}
