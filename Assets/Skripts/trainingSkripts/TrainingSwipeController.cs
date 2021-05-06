using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrainingSwipeController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public TrainingPlayer trainingPlayer;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!trainingPlayer.InMove())
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > 0)
                    trainingPlayer.Move(Vector3.right);
                else
                    trainingPlayer.Move(Vector3.left);
            }
            else
            {
                if (eventData.delta.y > 0)
                    trainingPlayer.Move(Vector3.up);
                else
                    trainingPlayer.Move(Vector3.down);
            }
        }

    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
