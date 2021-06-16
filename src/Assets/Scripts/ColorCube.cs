using System.Collections.Generic;
using UnityEngine;

public class ColorCube : MonoBehaviour
{
    public List<Color> CorrectSprite;

    public void ReturnToInitState()
    {
        for (var i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(0.754717f, 0.4236383f, 0.7085454f);
    }

    public void PaintInCorrectColors()
    {
        for (var i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = CorrectSprite[i];
    }

    public bool CheckWin()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var currentCell = transform.GetChild(i).GetComponent<SpriteRenderer>();
            if (currentCell.color != CorrectSprite[i])
                return false;
        }
        return true;
    }
}
