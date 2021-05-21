using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SwipeController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Player player;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!player.InMove())
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > 0)
                    player.Move(Vector3.right);
                else
                    player.Move(Vector3.left);
            }
            else
            {
                if (eventData.delta.y > 0)
                    player.Move(Vector3.up);
                else
                    player.Move(Vector3.down);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
