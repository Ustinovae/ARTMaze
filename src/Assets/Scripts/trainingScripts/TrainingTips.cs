using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingTips : MonoBehaviour
{
    private int indexChild =1;
    private bool currentComleted = false;

    public void CompletTip()
    {
        transform.GetChild(indexChild - 1).GetComponent<Image>().color = Color.green;
        currentComleted = true;
    }

    public void ChangeTip()
    {
        if (indexChild < transform.childCount)
        {
            transform.GetChild(indexChild - 1).gameObject.SetActive(false);
            transform.GetChild(indexChild).gameObject.SetActive(true);
            indexChild += 1;
            currentComleted = false;
        }
    }

    public bool GetCurrentStatus() =>
        currentComleted;

    public bool TipsFinished()
    {
        return indexChild == transform.childCount;
    }

    public int GetNumberTip()
    {
        return indexChild;
    }
}
